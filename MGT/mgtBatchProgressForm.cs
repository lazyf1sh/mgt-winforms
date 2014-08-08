using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MGT
{
    public partial class mgtBatchProgressForm : Form
    {

        int totalTime = 0;
        int iteration = 0;
        int previousTime = 0;

        public mgtBatchProgressForm()
        {
            InitializeComponent();
        }

        public void setSleepTime(int time)
        {

            label_sleepTime.Text = @"api request timeout: " + time.ToString() + " ms.";

            //averagetime code block:
            //если время не совпадает с предыдущем, значит был выполнен запрос к api, поэтому прибавляем итерацию
            if (time != previousTime)
            {
                totalTime += time;
                iteration++;
            label_averageTime.Text = @"Average api request timeout: " + (totalTime / iteration).ToString() + " ms.";
            previousTime = time;
            }
            
        }

        public void setApiRequestsPercent(int sqliteLocal, int sqliteNetwork, int api)
        {
            int localQueries = sqliteLocal + sqliteNetwork;
            if (localQueries != 0)
            {
                double apiPercent = (double) api / localQueries * 100;
                //MessageBox.Show(apiPercent.ToString());
                if (apiPercent < 1)
                {
                    label_apiQueriesPercent.Text = @"api percent: less than percent";
                }
                else
                {
                    label_apiQueriesPercent.Text = @"api percent: " + ((int) apiPercent).ToString() + "%";
                }
                
            }
        }

        public void setProgressValue(int newValue)
        {
            
            progressBar.Value = newValue;
        }

        public void setProgressMax(int max)
        {
            progressBar.Maximum = max;
        }

        public void setLabelProgress(int current)
        {
            label_progress.Text = "Total: " + current + " / " + progressBar.Maximum;
        }

        public void setRamQueries(int ramQueries)
        {
            label_ramQueriesVar.Text = "RAM: " + ramQueries.ToString();
        }

        public void setSQLiteQueriesLocal(int SQLiteQueriesLocal)
        {
            label_SQLiteQueriesLocalVar.Text = "SQLite Local: " + SQLiteQueriesLocal.ToString();
        }
        public void setSQLiteQueriesNetwork(int SQLiteQueriesNetwork)
        {
            label_SQLiteQueriesNetworkVar.Text = "SQLite Network: " + SQLiteQueriesNetwork.ToString();
        }
        public void setquovaApiQueries(int queries)
        {
            label_quovaApiQueriesVar.Text = "api total: " + queries.ToString();
        }

    }
}
