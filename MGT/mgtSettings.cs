using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace MGT
{
    public partial class mgtSettings : Form
    {
        private static string XmlStatFileName = @"stat.xml";
        private static string XmlStatFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MGT\";
        private static string XmlStatFilePath = XmlStatFolderPath + XmlStatFileName;

        //модифицировал конструтктор: передаём сюда форму MGTS_Form чтобы topmost-свойство менять
        private mgtMainForm parent;
        public mgtSettings(mgtMainForm parent)
        {
            this.parent = parent;
            InitializeComponent();
        }


        public static void createMgtFolder()
        {
            Directory.CreateDirectory(XmlStatFolderPath);
        }

        public static void createXmlStatFile()
        {
            if (!File.Exists(XmlStatFilePath))
            {
                XmlDocument xmlCreator = new XmlDocument();
                XmlDeclaration xmlDecl = xmlCreator.CreateXmlDeclaration("1.0", "utf-8", null);
                xmlCreator.AppendChild(xmlDecl);
                XmlElement root = xmlCreator.CreateElement("root");
                xmlCreator.AppendChild(root);
                xmlCreator.Save(XmlStatFilePath);
            }
        }

        public static void fillXMLStatFile()
        {
            string[] xPaths = {
            "/root/stat/mgtGeneral/mgtStarts",
            "/root/stat/ramCacheQueries/ramCacheQueriesDaily",
            "/root/stat/localSQLiteQueries/localSQLiteQueriesDaily",
            "/root/stat/networkSQLiteQueries/networkSQLiteQueriesDaily",
            "/root/stat/apiQueries/apiQueriesDaily", 
            "/root/stat/clipboardQueries/clipboardQueriesDaily" };

            for (int i = 0; i < xPaths.Count(); i++)
            {
                checkNodeExistance(xPaths[i]);
            }
        }

        private static void checkNodeExistance(string xpath)
        {
            XmlDocument document = new XmlDocument();
            document.Load(XmlStatFilePath);
            //инициализируем рутовую ноду, чтобы сработало условие ниже, если есть только рутовая нода
            XmlNode currentNode = document.SelectSingleNode("/root");

            string[] steps = xpath.Split('/');
            string newPath = null;

            for (int i = 1; i < steps.Length; i++)
            {
                newPath += "/" + steps[i];
                //если ты ноде скажешь parent.selectSingleNode("child"); то она выделит child внутри
                XmlNode check = document.SelectSingleNode(newPath);
                if (check != null)
                {
                    //запоминаем последнюю существующую ноду
                    currentNode = check;
                }
                else
                {
                    //если нода не найдена, то создаем такую ноду
                    XmlElement newNode = document.CreateElement(steps[i]);
                    currentNode.AppendChild(newNode);
                    document.Save(XmlStatFilePath);
                    checkNodeExistance(xpath);
                    break;
                }
            }
        }

        public static void xmlUpd_mgtStarts()
        {
            if (File.Exists(XmlStatFilePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlStatFilePath);
                XmlNodeList starts = doc.GetElementsByTagName("mgtStarts");
                //doc.SelectSingleNode("/root/stat/mgtGeneral/mgtStarts").InnerText = "0";

                if (starts[0].InnerText == "")
                {
                    starts[0].InnerText = "1";
                }
                else
                {
                    string stringStarts = starts[0].InnerText;
                    int intStarts = Convert.ToInt32(stringStarts);
                    intStarts++;
                    starts[0].InnerText = intStarts.ToString();
                }
                doc.Save(XmlStatFilePath);
            }
        }

        public static void xmlUpdQueries(string node)
        {
            if (File.Exists(XmlStatFilePath))
            {
                xml_CheckAttributes(node);
                xml_CheckActualDates(node);


                XmlDocument doc = new XmlDocument();
                doc.Load(XmlStatFilePath);


                XmlNodeList updQueryNode = doc.GetElementsByTagName(node);

                string stringValue = updQueryNode[updQueryNode.Count - 1].Attributes["count"].Value;
                int intValue = Convert.ToInt32(stringValue);
                intValue++;
                updQueryNode[updQueryNode.Count - 1].Attributes["count"].Value = intValue.ToString();
                doc.Save(XmlStatFilePath);
            }

        }

        public static void checkStatNodesAtStart()
        {
            string[] checkStatNodes = { "ramCacheQueriesDaily", "apiQueriesDaily", "clipboardQueriesDaily" };

            foreach (string node in checkStatNodes)
            {
                xml_CheckAttributes(node);
                xml_CheckActualDates(node);
            }

        }

        private static void xml_CheckAttributes(string node)
        {
            if (File.Exists(XmlStatFilePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlStatFilePath);

                XmlNodeList nodeToAddAttribute = doc.GetElementsByTagName(node);
                XmlAttributeCollection attributes = nodeToAddAttribute[0].Attributes;

                //если аттрибутов нет (первый запуск проги), то создаём аттрибуты
                if (attributes.Count < 2)
                {
                    XmlAttribute date = doc.CreateAttribute("date");
                    date.Value = DateTime.Today.ToShortDateString();
                    nodeToAddAttribute[0].Attributes.Append(date);

                    XmlAttribute count = doc.CreateAttribute("count");
                    count.Value = "0";
                    nodeToAddAttribute[0].Attributes.Append(count);
                }



                doc.Save(XmlStatFilePath);
            }
        }



        private static void xml_CheckActualDates(string node)
        {
            if (File.Exists(XmlStatFilePath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(XmlStatFilePath);


                XmlNodeList nodeToCheck = doc.GetElementsByTagName(node);

                //если настал следующий день
                if (nodeToCheck[nodeToCheck.Count - 1].Attributes["date"].Value != DateTime.Today.ToShortDateString())
                {
                    //MessageBox.Show(ramCacheQueriesDaily[ramCacheQueriesDaily.Count - 1].Attributes["date"].Value);
                    XmlElement newNode = doc.CreateElement(node);

                    newNode.SetAttribute("date", DateTime.Today.ToShortDateString());
                    newNode.SetAttribute("count", "0");
                    nodeToCheck[nodeToCheck.Count - 1].ParentNode.AppendChild(newNode);
                }

                doc.Save(XmlStatFilePath);

            }
        }

        private void linkLabel_W_Tools_MGT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(mgtGlobals.getDiskWUpdatePath());
        }

        private static bool checkBox_postToVitkBaseState = true;
        public static bool checkBox_postToVitkBase_GetState()
        {
            if (checkBox_postToVitkBaseState)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mgtRamCache.showLocalCache();
        }
    }
}
