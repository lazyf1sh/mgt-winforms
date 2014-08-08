using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace MGT
{
    public static class mgtQuovaXmlParse
    {
        public static string[] getDataFromXML(string quovaXML)
        {
            string[] parsedData = new string[9];
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(quovaXML);

            XmlNodeList ip_type = xmlDoc.GetElementsByTagName("ip_type");

            //тоже можно по прецедентам вносить в исключения:
            if (ip_type[0].InnerText == "Reserved")
            {
                //outputDataToForm("invalid_ip2", "invalid_ip2", "invalid_ip2", "Если Вы это видите, сообщите", "разработчику");
                //outputInHistoryBox("invalid_ip2", "invalid_ip2", "invalid_ip2", "invalid_ip2", "invalid_ip2");
                //writeToLog("incorrect ip: " + ipAddress + " (reserved_ip).");
                parsedData[0] = "Reserved";
                return parsedData;
            }
            if (ip_type[0].InnerText == "Mapped")
            {
                parsedData[0] = "Correct IP";

                string[] targetNodes = { "", "ip_address", "country", "city", "organization", "carrier", "country_code", "state", "sld" };
                //начинаем с первого т.к. массив parsedData тоже начинает принимать нужную инфу с первого
                for (int i = 1; i < targetNodes.Length; i++)
                {
                    try
                    {
                        XmlNodeList targetNode = xmlDoc.GetElementsByTagName(targetNodes[i]);
                        parsedData[i] = targetNode[0].InnerText;
                    }
                    catch
                    {
                        parsedData[i] = "";
                    }
                }
                
                return parsedData;
            }
            else
            {
                parsedData[0] = "Incorrect XML IP";
                return parsedData;
            }
        }
    }
}