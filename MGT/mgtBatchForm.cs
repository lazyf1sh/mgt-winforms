using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGT
{
    public partial class mgtBatchForm : Form
    {
        private static List<batchFormData> batchArray = new List<batchFormData>();
        private static List<colorElements> colorDb = new List<colorElements>();
        public BackgroundWorker bw;
        mgtBatchProgressForm progressForm;
        int ramQueriesVar = 0;
        int SQLiteQueriesLocalVar = 0;
        int SQLiteQueriesNetworkVar = 0;
        int quovaApiQueriesVar = 0;
        int sleeptime;
        int averageTime;

        public mgtBatchForm()
        {

            

            InitializeComponent();
            if (!mgtGlobals.isCarrierButtonEnabled)
            {
                datagridToolStripMenuItem.Enabled = false;
            }
            fillDataGridBatchForm();

            bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);

            setWidthHeightLocation();
        }

        #region bw
        
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {


            batchArray.Clear();
            ramQueriesVar = 0;
            quovaApiQueriesVar = 0;
            SQLiteQueriesLocalVar = 0;
            SQLiteQueriesNetworkVar = 0;

            //имитирую долгую операцию
            //for (int i = 1; i < 101; i++)
            //{
            //    if (i % 2 == 0)
            //        ((BackgroundWorker)sender).ReportProgress(i);
            //   System.Threading.Thread.Sleep(100);
            //}
            batchArray = mgtGlobals.getBatchArray();

            for (int i = 0; i < batchArray.Count; i++)
            #region 2. проверка наличия в RAM-кэше [batch]
            {
                
                ((BackgroundWorker)sender).ReportProgress(i+1);
                //System.Threading.Thread.Sleep(1);
                //cacheSR == cacheSearchResult
                string[] cacheSR = mgtRamCache.getFromRamCache(batchArray[i].ip);
                if (cacheSR[0] == "something found in local cache")
                {
                    //mgtSettings.xmlUpdQueries("ramCacheQueriesDaily");
                    ramQueriesVar++;
                    batchArray[i].country = cacheSR[2];
                    batchArray[i].city = cacheSR[3];
                    batchArray[i].carrier = cacheSR[4];
                    batchArray[i].organization = cacheSR[5];
                    batchArray[i].ccode = cacheSR[6];
                    batchArray[i].state = cacheSR[7];
                    batchArray[i].sld = cacheSR[8];
                    continue;
                }

            #endregion

                #region 3. проверка наличия в локальном SQLite-кэше [batch]

                if (batchArray[i].country == null)
                {
                    string[] sqliteRL = mgtSqliteCache.getDataFromSQLite(mgtGlobals.getSqliteFilePathLocal(), batchArray[i].ip);
                    switch (sqliteRL[0])
                    {
                        case "nothing found":
                            break;
                        case "something found":
                            //mgtSettings.xmlUpdQueries("localSQLiteQueriesDaily");
                            SQLiteQueriesLocalVar++;
                            batchArray[i].country = sqliteRL[1];
                            batchArray[i].city = sqliteRL[2];
                            batchArray[i].carrier = sqliteRL[3];
                            batchArray[i].organization = sqliteRL[4];
                            batchArray[i].ccode = sqliteRL[5];
                            batchArray[i].state = sqliteRL[6];
                            batchArray[i].sld = sqliteRL[7];
                            mgtRamCache.setInRamCache(batchArray[i].ip, sqliteRL[1], sqliteRL[2], sqliteRL[3], sqliteRL[4], sqliteRL[5], sqliteRL[6], sqliteRL[7]);
                            continue;
                    }

                }
                #endregion

                #region N. запрос данных у api [batch]

                if (batchArray[i].country == null)
                {
                    Random sleepRandom = new Random();
                    sleeptime = sleepRandom.Next(1500, 2000); //for all
                    
                    System.Threading.Thread.Sleep(sleeptime);
                    string quovaXML = mgtQuova.getXML(batchArray[i].ip);
                    if (quovaXML == "there's some error with WebRequest")
                    {
                        MessageBox.Show("there's some error with WebRequest on " + batchArray[i].ip);
                        return;
                    }

                    string[] quovaTempArray = mgtQuovaXmlParse.getDataFromXML(quovaXML);

                    switch (quovaTempArray[0])
                    {
                        case "Reserved":
                            MessageBox.Show("Reserved " + batchArray[i].ip);
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

                    
                    mgtRamCache.setInRamCache(ip, country, city, carrier, org, ccode, state, sld);
                    mgtSqliteCache.setDataToSQLite(mgtGlobals.getSqliteFilePathLocal(), ip, country, city, carrier, org, ccode, state, sld);
                    //наполнение сетевой базы, выкл, сам буду наполнять
                    //mgtSqliteCache.setDataToSQLite(mgtGlobals.getSqliteFilePathNetwork(), ip, country, city, carrier, org, ccode, state, sld);

                    batchArray[i].country = country;
                    batchArray[i].city = city;
                    batchArray[i].carrier = carrier;
                    batchArray[i].organization = org;
                    batchArray[i].ccode = ccode;
                    batchArray[i].state = state;
                    batchArray[i].sld = sld;
                    quovaApiQueriesVar++;
                }

                #endregion
            }
            
        }

        //BackgroundWorker инициировал событие и передал прогресс выполнения (как сам придумаешь, можно в процентах передавать и т.д.)
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressForm.setProgressValue(e.ProgressPercentage);
            progressForm.setLabelProgress(e.ProgressPercentage);
            progressForm.setquovaApiQueries(quovaApiQueriesVar);
            progressForm.setRamQueries(ramQueriesVar);
            progressForm.setSQLiteQueriesLocal(SQLiteQueriesLocalVar);
            progressForm.setSQLiteQueriesNetwork(SQLiteQueriesNetworkVar);
            progressForm.setSleepTime(sleeptime);
            progressForm.setApiRequestsPercent(SQLiteQueriesLocalVar, SQLiteQueriesNetworkVar, quovaApiQueriesVar);
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressForm.setRamQueries(ramQueriesVar);
            progressForm.setSQLiteQueriesLocal(SQLiteQueriesLocalVar);
            progressForm.setSQLiteQueriesNetwork(SQLiteQueriesNetworkVar);
            progressForm.setquovaApiQueries(quovaApiQueriesVar);
            progressForm.Close();
            mgtBatchForm.showBatchForm();
            
        }
        public void runMultiDoWork()
        {
            progressForm = new mgtBatchProgressForm();
            progressForm.Show();
            progressForm.setProgressMax(mgtGlobals.getBatchArray().Count);

            bw.RunWorkerAsync();
            
        }

        #endregion


        private void fillDataGridBatchForm()
        {
             for (int i = 0; i < batchArray.Count; i++)
            {
                dataGridView_batchGrid.Rows.Add(
                    batchArray[i].clipdata,
                    batchArray[i].ip,
                    batchArray[i].country,
                    batchArray[i].city,
                    batchArray[i].carrier,
                    batchArray[i].organization,
                    batchArray[i].ccode,
                    batchArray[i].state,
                    batchArray[i].sld);
            }

            colorize_datagrid("organization");


            dataGridView_batchGrid.Height = dataGridView_ListOfISP.Height = this.Height - 80;
            label_linesContainsIPsDynamic.Text = batchArray.Count.ToString();
            label_linesWasDynamic.Text = mgtGlobals.getLinesWasCopiedToBatchProccess().ToString();

            
            dataGridView_ListOfISP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView_ListOfISP.AutoResizeColumns();
        }

        private void colorize_datagrid(string column)
        {
            List<string> tempArray = new List<string>();
           int cellId = 5;
            switch (column)
            {
                case "organization":
                    for (int i = 0; i < batchArray.Count; i++)
                    {
                        tempArray.Add(batchArray[i].organization);
                    }
                    cellId = 5;
                    break;
                case "carrier":
                    for (int i = 0; i < batchArray.Count; i++)
                    {
                        tempArray.Add(batchArray[i].carrier);
                    }
                    cellId = 4;
                    break;
            }


            //var unique = tempArray.Distinct();

            //http://stackoverflow.com/questions/454601/how-to-count-duplicates-in-list-with-linq

            var q = tempArray.GroupBy(x => x)
            .Select(g => new {Value = g.Key, Count = g.Count()})
            .OrderByDescending(x=>x.Count);

            //foreach (var x in q)
            //{
            //    MessageBox.Show("Value: " + x.Value + " Count: " + x.Count);
            //}

            Random random = new Random();
            colorDb.Clear();

            foreach (var crit in q)
            {
                colorElements colours = new colorElements();

                colours.criteria = crit.Value;
                colours.red = random.Next(150, 255);
                colours.green = random.Next(150, 255);
                colours.blue = random.Next(150, 255);
                colours.percent = Convert.ToInt32((double) crit.Count / (double) tempArray.Count * 100);
                colorDb.Add(colours);
            }

            dataGridView_ListOfISP.Rows.Clear();
            for (int i = 0; i < colorDb.Count; i++)
            {
                dataGridView_ListOfISP.Rows.Add(colorDb[i].percent, colorDb[i].criteria);
                dataGridView_ListOfISP.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, colorDb[i].red, colorDb[i].green, colorDb[i].blue);
            }

            for (int i = 0; i < dataGridView_batchGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < colorDb.Count; j++)
                {
                    if (dataGridView_batchGrid.Rows[i].Cells[cellId].Value.ToString() == colorDb[j].criteria)
                    {
                        dataGridView_batchGrid.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, colorDb[j].red, colorDb[j].green, colorDb[j].blue);
                    }
                }
            }
        }

        public static void showBatchForm()
        {
            mgtBatchForm batchForm = new mgtBatchForm();
            batchForm.Show();
        }




        public class colorElements
        {
            public string criteria;
            public int red;
            public int green;
            public int blue;
            public int percent;
        }

        private void mgtBatchForm_ResizeEnd(object sender, EventArgs e)
        {

            dataGridView_batchGrid.Height = this.Height - 100;
            dataGridView_ListOfISP.Height = this.Height - 120;
            


            Properties.Settings.Default.batchWindowHeight = this.Height;
            Properties.Settings.Default.batchWindowWidth = this.Width;
            Properties.Settings.Default.batchWindowLocation = this.Location;
            Properties.Settings.Default.Save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void highlightByCarrierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorize_datagrid("carrier");
        }

        private void highlightByOrgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorize_datagrid("organization");
        }

        private void setWidthHeightLocation()
        {
            this.Location = Properties.Settings.Default.batchWindowLocation;
            this.Height = Properties.Settings.Default.batchWindowHeight;
            this.Width = Properties.Settings.Default.batchWindowWidth;
        }

    }
}