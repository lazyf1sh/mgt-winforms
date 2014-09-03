using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net;


namespace MGT
{
    public partial class mgtMainForm : Form
    {
        KeyboardHook hook = new KeyboardHook();

        private static List<string> linesToBatchProccess = new List<string>();
        private mgtBatchForm batch = new mgtBatchForm();
        private string previousIP = null;


        public mgtMainForm()
        {
            mgtCore.checkPcName();
            mgtCore.checkLicence();
            mgtCore.checkLocation();
            InitializeComponent();
            setStartFormData();
            mgtSettings.createMgtFolder();
            mgtSettings.createXmlStatFile();
            mgtSettings.fillXMLStatFile();
            mgtSettings.xmlUpd_mgtStarts();
            mgtSettings.checkStatNodesAtStart();
            mgtCore.checklocalDbFileSize();
            
            mgtSqliteCache.createBaseFile(mgtGlobals.getSqliteFilePathLocal());


            // register the event that is fired after the key press.
            //hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            //hook.RegisterHotKey(MGT.ModifierKeys.Win | MGT.ModifierKeys.Control, Keys.Z);
            //hook.RegisterHotKey(MGT.ModifierKeys.Alt, Keys.C);

            startAndStopMonitoring();
            writeToDiskWLog("The program successfully executed.");
            SetWindowStartVisualParameters();
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            //show the keys pressed in a label.
           //MessageBox.Show(e.Modifier.ToString() + " + " + e.Key.ToString());
            runAll4();
        }

        #region general functions
        private void setStartFormData()
        {
            label_GeoDynamic.Text = null;
            label_IPDynamic.Text = null;
            label_sldDynamic.Text = null;
            label_StateDynamic.Text = null;
            label_CarrierDynamic.Text = null;
            label_OrgDynamic.Text = null;

        }
        private void writeToDiskWLog(string stringToLog)
        {
            if (File.Exists(mgtGlobals.getNetworkLogPath()))
            {
                stringToLog = "\"" + DateTime.Now + "\", \"" + Environment.UserName + "\", \"" + mgtGlobals.getCurrentMgtVerison() + "\", \"" + stringToLog + "\"" + Environment.NewLine;
                File.AppendAllText(mgtGlobals.getNetworkLogPath(), stringToLog, Encoding.UTF8);
            }
        }

        private void writeToAppdataLog(string stringToLog)
        {
            if (File.Exists(mgtGlobals.getAppdataMgtLogFilePath()))
            {
                stringToLog = "\"" + DateTime.Now + "\", \"" + Environment.UserName + "\", \"" + mgtGlobals.getCurrentMgtVerison() + "\", \"" + stringToLog + "\"" + Environment.NewLine;
                File.AppendAllText(mgtGlobals.getAppdataMgtLogFilePath(), stringToLog, Encoding.UTF8);
            }
            else
            {
                File.CreateText(mgtGlobals.getAppdataMgtLogFilePath());
            }
        }
        #endregion

        #region imported winapi clipboard functions
        //The messages we shall need to monitor
        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;

        //A handle of the next clipboard viewer we should send the message to
        private IntPtr nextClipboardViewer;

        //Register a window handle as a clipboard viewer
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWnd);

        //Remove a window handle from the clipboard viewers chain
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(
            IntPtr hWndRemove,  // handle to window to remove
            IntPtr hWndNewNext  // handle to next window
            );

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    //the contents of the clipboard have changed
                    {
                        //Process clipboard change
                        ClipboardChanged();
                        //Send the message to the next window
                        SendMessage(nextClipboardViewer, WM_DRAWCLIPBOARD, IntPtr.Zero, IntPtr.Zero);
                        break;
                    }
                case WM_CHANGECBCHAIN:
                    //the clipboard chain has changed and we have to pass the news along
                    {
                        if (m.WParam == nextClipboardViewer)
                        {
                            //the window we've been passing WM_DRAWCLIPBOARD to has been removed
                            //from the chain, so we have to update our message target
                            nextClipboardViewer = m.LParam;
                        }
                        else
                        {
                            //just pass along the message
                            SendMessage(nextClipboardViewer, WM_CHANGECBCHAIN, m.WParam, m.LParam);
                        }
                        m.Result = IntPtr.Zero;
                        break;
                    }
                default:
                    {
                        base.WndProc(ref m);
                        break;
                    }
            }
        }
        //основная функция, запускает весь процесс
        private int iterations = 0;
        private bool batchProccessActive = false;
        private void ClipboardChanged()
        {
            if (batchProccessActive)
            {
                return;
            }
            else
            {

                batchAddToolStripMenuItem.Enabled = true;
                mgtSettings.xmlUpdQueries("clipboardQueriesDaily");
                currentIteration0ToolStripMenuItem.Text = String.Format("Current iteration: [{0}]", iterations++.ToString());
                
                //Output("The clipboard content has been changed.");
                string s = null;
                if (Clipboard.ContainsText())
                {
                    s += Clipboard.GetText();

                    Regex lines = new Regex(".+$", RegexOptions.Multiline);
                    MatchCollection linesMatches = lines.Matches(s);
                    label_linesInClipBoard.Text = string.Format("Lines in clipboard: {0}", linesMatches.Count.ToString());
                    /*
                    //если больше 1 строки
                
                    if (linesMatches.Count > 1)
                    {
                        List<string> lineMatchesToRun = new List<string>();
                        if (linesMatches.Count >= 1000)
                        {
                            for (int i = 0; i < 1000; i++)
                            {
                                lineMatchesToRun.Add(linesMatches[i].Value);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < linesMatches.Count; i++)
                            {
                                lineMatchesToRun.Add(linesMatches[i].Value);
                            }
                        }
                            button_mgtBatchForm.Enabled = true;
                            button_mgtBatchForm.Text = "Обработка...";
                            button_mgtBatchForm.Enabled = false;
                            mgtBatchForm.runMulti(lineMatchesToRun);
                            button_mgtBatchForm.Text = "Показать";
                            button_mgtBatchForm.Enabled = true;
                    }
                    */


                    //если одна строка:
                    if (linesMatches.Count == 1)
                    {
                        s = linesMatches[0].Value;

                        const int maxLength = 999;

                        if (s.Length > maxLength)
                        {
                            s = s.Substring(0, maxLength);
                            runSingleLine(s);
                        }
                        else
                        {
                            runSingleLine(s);
                        }
                    }
                }
                else
                {
                    s += "[non-text]";
                    label_linesInClipBoard.Text = string.Format("Lines in clipboard: {0}", "0");
                }

            }
        }


        #endregion

        #region interface actions

        bool isClipBoardMonitorActive = false;

        private void startAndStopMonitoring()
        {
            if (isClipBoardMonitorActive)
            {
                ChangeClipboardChain(this.Handle, nextClipboardViewer);
                startMonitoringToolStripMenuItem.Text = "Start Monitoring";
                isClipBoardMonitorActive = false;
                //Output("Unregistered clipboard viewer.");
            }
            //если неактивен, включить
            else
            {
                nextClipboardViewer = SetClipboardViewer(this.Handle);
                startMonitoringToolStripMenuItem.Text = "Stop Monitoring";
                isClipBoardMonitorActive = true;
                //Output("Registered clipboard viewer.");
            }
        }
        private void setDataToForm(string ip_address, string country, string city, string carrier, string organization, string state, string sld)
        {
            label_GeoDynamic.Text = city + ", " + country;
            label_CarrierDynamic.Text = carrier;
            label_IPDynamic.Text = ip_address;
            label_OrgDynamic.Text = organization;
            label_StateDynamic.Text = state;
            label_sldDynamic.Text = sld;
        }
        private void setDataToHistoryBox(string ip_address, string country, string city, string carrier, string organization, string state, string sld)
        {
            Font fnt = new Font("Verdana", 8F, FontStyle.Bold, GraphicsUnit.Point);
            string outputString =
            @"IP: " + ip_address +
            "\ncountry: " + country +
            "\ncity: " + city +
            "\ncarrier: " + carrier +
            "\norg: " + organization +
            "\nstate: " + state +
            "\nsld: " + sld +
            "\n___________________\n";

            richTextBox_requestsHistory.Text = outputString + richTextBox_requestsHistory.Text;

            richTextBox_requestsHistory.SelectAll();

            richTextBox_requestsHistory.SelectionFont = RichTextBox.DefaultFont;

            string[] dataArray = { "IP:", "country:", "city:", "carrier:", "org:", "state:", "sld:", "IP routing type:", "Connection Type:" };


            for (int i = 0; i < dataArray.Count(); i++)
            {

                Regex reg = new Regex(dataArray[i]); //textBox1 - поле для ввода искомого текста
                MatchCollection match = reg.Matches(richTextBox_requestsHistory.Text);

                foreach (Match mat in match)
                {
                    richTextBox_requestsHistory.Select(mat.Index, mat.Length);
                    richTextBox_requestsHistory.SelectionFont = fnt;

                }
            }



            richTextBox_requestsHistory.DeselectAll();

            richTextBox_requestsHistory.SelectionStart = 0;
            richTextBox_requestsHistory.ScrollToCaret();
        }
        private void setFlagToForm(string ccode)
        {

            string tempPath = Path.GetTempPath(); // /temp/
            string pathToMgtsTempFolder = tempPath + @"mgts/"; // temp/mgts/

            string downloadFlagURL = @"http://whois.domaintools.com/images/flags/" + ccode + @".gif"; // http://...ru.gif
            string pathForDownloadFlag = pathToMgtsTempFolder + ccode + @".gif"; // /temp/mgts/ru.gif

            Directory.CreateDirectory(pathToMgtsTempFolder);

            bool checkFlagExists = File.Exists(pathForDownloadFlag);

            if (checkFlagExists)
            {
                pictureBox_CountryFlag.Load(pathForDownloadFlag);
            }
            else
            {
                WebClient downloadFlagWebClient = new WebClient();
                downloadFlagWebClient.DownloadFile(downloadFlagURL, pathForDownloadFlag);
                pictureBox_CountryFlag.Load(pathForDownloadFlag);
            }
        }
        private void setAllDataToClipBoard()
        {
            //в слове Информация о и а английские
            if (label_IPDynamic.Text != "")
            {
                string data =
                "Инфoрмaция об IP: " + Environment.NewLine +
                "ip: " + label_IPDynamic.Text + Environment.NewLine +
                "geo: " + label_GeoDynamic.Text + Environment.NewLine +
                "isp: " + label_CarrierDynamic.Text + Environment.NewLine +
                "org: " + label_OrgDynamic.Text + Environment.NewLine +
                "state: " + label_StateDynamic.Text + Environment.NewLine +
                "sld: " + label_sldDynamic.Text + Environment.NewLine;
                Clipboard.SetText(data);
            }
        }
        private void pictureBox_CountryFlag_Click(object sender, EventArgs e)
        {
            setAllDataToClipBoard();
        }
        private void setWindowName(string name)
        {
            this.Text = name;
        }

        private void showBatchForm()
        {
            if (batch.bw.IsBusy)
            {
                richTextBox_requestsHistory.Text = "Выполняется обработка, ожидайте." + Environment.NewLine + richTextBox_requestsHistory.Text;
                return;
            }
            mgtBatchForm.showBatchForm();
        }


        #endregion




        private void runSingleLine(string clipdata)
        {
            #region 1. проверка корректности IP [Single]

            string correctIp = mgtCore.getCorrectIP(clipdata);
            if (null == correctIp)
            {
                return;
            }   

            #endregion

            if (correctIp == previousIP)
            {
                return;
            }

            #region 2. проверка наличия в RAM-кэше
            //cacheSR == cacheSearchResult
            string[] cacheSR = mgtRamCache.getFromRamCache(correctIp);
            if (cacheSR[0] == "something found in local cache")
            {
                mgtSettings.xmlUpdQueries("ramCacheQueriesDaily");
                setFlagToForm(cacheSR[6]);
                //cacheSR[1] - вернёт IP по 24 маске, т.к. в локальный кэш он вносится по 24 маске, поэтому берём IP который
                //пришёл сверху
                setDataToForm(correctIp, cacheSR[2], cacheSR[3], cacheSR[4], cacheSR[5], cacheSR[7], cacheSR[8]);
                setDataToHistoryBox(correctIp, cacheSR[2], cacheSR[3], cacheSR[4], cacheSR[5], cacheSR[7], cacheSR[8]);
                setWindowName(@"MGT# [ram]");
                showGeoDataBallon(correctIp, cacheSR[2], cacheSR[3], cacheSR[4], cacheSR[5], cacheSR[7], cacheSR[8]);
                previousIP = correctIp;

                return;
            }

            #endregion

            #region 3. проверка наличия в локальном SQLite-кэше [Single]
            //если нет инфы в локальном кэше, проверяем локальную SQLite-базу
            //sqliteRL - sqliteResultLocal
            
            string[] sqliteRL = mgtSqliteCache.getDataFromSQLite(mgtGlobals.getSqliteFilePathLocal(), correctIp);
            
            switch (sqliteRL[0])
            {
                case "nothing found":
                    break;
                case "something found":
                    mgtSettings.xmlUpdQueries("localSQLiteQueriesDaily");
                    setDataToForm(correctIp, sqliteRL[1], sqliteRL[2], sqliteRL[3], sqliteRL[4], sqliteRL[6], sqliteRL[7]);
                    setDataToHistoryBox(correctIp, sqliteRL[1], sqliteRL[2], sqliteRL[3], sqliteRL[4], sqliteRL[6], sqliteRL[7]);
                    setFlagToForm(sqliteRL[5]);
                    mgtRamCache.setInRamCache(correctIp, sqliteRL[1], sqliteRL[2], sqliteRL[3], sqliteRL[4], sqliteRL[5], sqliteRL[6], sqliteRL[7]);
                    setWindowName("MGT# [sqlite_Local]");
                    showGeoDataBallon(correctIp, sqliteRL[1], sqliteRL[2], sqliteRL[3], sqliteRL[4], sqliteRL[6], sqliteRL[7]);
                    previousIP = correctIp;
                    return;
            }

            #endregion

            #region N. запрос данных у api
            string quovaXML = mgtQuova.getXML(correctIp);

            
            //File.WriteAllText(@"xml" + qq++.ToString() + ".xml", quovaXML);
            //если обработчик исключений сработал. Особая ситуация, которую надо бы разобрать по-хорошему ; )
            //либо внести в список исключений внутир функции-проверки правильности ip: MGTS.isCorrectIP
            if (quovaXML == "there's some error with WebRequest")
            {
                setDataToForm("", "", "", "there's some error with WebRequest", "", "", "");
                setDataToHistoryBox("", "", "", "", "there's some error with WebRequest", "", "");
                //ну и запишу в лог
                writeToDiskWLog("incorrect ip: " + correctIp + " (there's some error with WebRequest).");
                return;
            }


            string[] quovaTempArray = mgtQuovaXmlParse.getDataFromXML(quovaXML);
            switch (quovaTempArray[0])
            {
                case "Reserved":
                    MessageBox.Show("Reserved");
                    return;
                case "Incorrect XML IP":
                    MessageBox.Show("Incorrect XML IP");
                    return;
            }

            string ip = quovaTempArray[1];
            string country = quovaTempArray[2];
            string city = quovaTempArray[3];
            string carrier = quovaTempArray[4];
            string org = quovaTempArray[5];
            string ccode = quovaTempArray[6];
            string state = quovaTempArray[7];
            string sld = quovaTempArray[8];

            setDataToForm(ip, country, city, carrier, org, state, sld);
            setDataToHistoryBox(ip, country, city, carrier, org, state, sld);
            setFlagToForm(ccode);
            mgtRamCache.setInRamCache(ip, country, city, carrier, org, ccode, state, sld);
            mgtSqliteCache.setDataToSQLite(mgtGlobals.getSqliteFilePathLocal(), ip, country, city, carrier, org, ccode, state, sld);
            //наполнение сетевой базы, выкл, сам буду наполнять
            //mgtSqliteCache.setDataToSQLite(mgtGlobals.getSqliteFilePathNetwork(), ip, country, city, carrier, org, ccode, state, sld);
            setWindowName(@"MGT [api]");

            showGeoDataBallon(ip, country, city, carrier, org, state, sld);
            previousIP = ip;
            #endregion
        }

        private void clearlinesToBatchProccess()
        {
            linesToBatchProccess.Clear();
            label_batchProccessLinesDynamic.Text = string.Format("Lines to parse: {0}", "0");
            batchAddToolStripMenuItem.Enabled = false;
            
        }

        private void getLinesFromClipboardToLinesToBatchProccess()
        {
            string s = null;
            if (Clipboard.ContainsText())
            {

                s = Clipboard.GetText();

                Regex lines = new Regex(".+$", RegexOptions.Multiline);
                MatchCollection linesMatches = lines.Matches(s);

                for (int i = 0; i < linesMatches.Count; i++)
                {
                    linesToBatchProccess.Add(linesMatches[i].Value);
                }
            }

            label_batchProccessLinesDynamic.Text = string.Format("Lines to parse: {0}", linesToBatchProccess.Count.ToString());
            batchAddToolStripMenuItem.Enabled = false;
        }



        private void batchProccessParseStart()
        {
            if (batch.bw.IsBusy)
            {
                richTextBox_requestsHistory.Text = "Обработка уже выполняется" + Environment.NewLine + richTextBox_requestsHistory.Text;
                return;
            }


            mgtGlobals.setLinesWasCopiedToBatchProccess(linesToBatchProccess.Count);
            batchShowToolStripMenuItem.Enabled = true;
            batchShowToolStripMenuItem.Text = "Обработка...";
            batchShowToolStripMenuItem.Enabled = false;
            batchAddToolStripMenuItem.Enabled = false;
            batchCleanToolStripMenuItem.Enabled = false;
            batchParseToolStripMenuItem.Enabled = false;

            #region 1. проверка корректности IP и выборка только строк с правильными IP [batch]
            List<batchFormData> batchArray = new List<batchFormData>();
            for (int i = 0; i < linesToBatchProccess.Count; i++)
            {
                string correctIp = mgtCore.getCorrectIP(linesToBatchProccess[i]);

                if (null == correctIp)
                {
                    continue;
                }

                batchFormData batchData = new batchFormData();

                batchData.clipdata = linesToBatchProccess[i];
                batchData.ip = correctIp;
                batchArray.Add(batchData);
            }
            #endregion

            mgtGlobals.setBatchArray(batchArray);

            
            
            batch.runMultiDoWork();
            

            batchShowToolStripMenuItem.Text = "Показать";
            batchShowToolStripMenuItem.Enabled = true;
            batchAddToolStripMenuItem.Enabled = true;
            batchCleanToolStripMenuItem.Enabled = true;
            batchParseToolStripMenuItem.Enabled = true;

            batchProccessActive = false;
        }


        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(mgtGlobals.getDiskWUpdatePath());
        }

        private void notifyIcon_geoData_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void showGeoDataBallon(
            string ip_address, string country,
            string city, string carrier, string organization,
            string state, string sld)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {

                notifyIcon_geoData.BalloonTipTitle = ip_address;
                notifyIcon_geoData.BalloonTipText = country + ", " + city + Environment.NewLine +
                carrier + Environment.NewLine +
                organization + Environment.NewLine +
                state + Environment.NewLine +
                sld;


                notifyIcon_geoData.Icon = Icon;
                notifyIcon_geoData.Visible = true;
                notifyIcon_geoData.ShowBalloonTip(1000);
            }
        }

        private void runAll4()
        {
            clearlinesToBatchProccess();
            getLinesFromClipboardToLinesToBatchProccess();
            batchProccessParseStart();
            //4 действие прописано в bw completed
        }


        private void enableBatchHotkey()
        {
            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(MGT.ModifierKeys.Control | MGT.ModifierKeys.Alt, Keys.C);
            enableBatchHotkeyToolStripMenuItem.Enabled = false;
            richTextBox_requestsHistory.Text = @"
Горячая клавиша CTRL+ALT+C для кнопки all4 зарегистрирована.
Теперь можно выделить массив логов
нажать CTRL+C (скопировать, например логи) 
и, не отпуская CTRL нажать ALT+C (то есть дожать до CTRL+ALT+C)
Результатом будет открытое окно с обработанными IP
---------------------------------------" + Environment.NewLine + richTextBox_requestsHistory.Text;
        }



        private void startMonitoringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startAndStopMonitoring();
        }


        private void openSettingsWindow()
        {
            //передаём в конструктор окна настроек этот класс (чтобы модифицировать его свойства в классе окна настроек
            mgtSettings mgtSettingsWindow = new mgtSettings(this);
            mgtSettingsWindow.ShowDialog();
        }
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openSettingsWindow();
        }

        private void enableBatchHotkeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            enableBatchHotkey();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutWindow aboutwin = new aboutWindow();
            aboutwin.ShowDialog();
        }

        private void batchAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getLinesFromClipboardToLinesToBatchProccess();
        }

        private void batchCleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearlinesToBatchProccess();
        }

        private void batchParseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            batchProccessParseStart();
        }

        private void batchShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showBatchForm();
        }

        private void batchAll4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            runAll4();
        }

        private void label_batchProccessLinesDynamic_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox_requestsHistory_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void mgtMainForm_ResizeEnd(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainWindowLocation = this.Location;
            Properties.Settings.Default.MainWindowHeight = this.Height;
            Properties.Settings.Default.MainWindowWidth = this.Width;
            Properties.Settings.Default.Save();
        }

        private void SetWindowStartVisualParameters()
        {
            this.Location = Properties.Settings.Default.MainWindowLocation;
            this.Height = Properties.Settings.Default.MainWindowHeight;
            this.Width = Properties.Settings.Default.MainWindowWidth;

            this.TopMost = Properties.Settings.Default.MainWindowTopMost;
            alwaysOnTopToolStripMenuItem.Checked = Properties.Settings.Default.MainWindowTopMost;
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.TopMost)
            {
                this.TopMost = false;
                alwaysOnTopToolStripMenuItem.Checked = false;
                Properties.Settings.Default.MainWindowTopMost = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                this.TopMost = true;
                alwaysOnTopToolStripMenuItem.Checked = true;
                Properties.Settings.Default.MainWindowTopMost = true;
                Properties.Settings.Default.Save();
            }
        }

 

    }
}