using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MGT
{
    public partial class mgtRamCache : Form
    {
        public mgtRamCache()
        {
            InitializeComponent();
        }

        private static List<ISPdatatable> cacheList = new List<ISPdatatable>();

        public static void setInRamCache(
            string ip_address,
            string country,
            string city,
            string carrier,
            string organization,
            string ccode,
            string state,
            string sld)
        {
            ISPdatatable cacheElementsClass = new ISPdatatable();
            //получаем long ip
            long longIp = mgtCore.IPToLong(ip_address);
            //получаем из long ip обычный по маске 24 путем вычитания из long IP остатка от деления на 256
            ip_address = mgtCore.LongToIP(longIp - (longIp % 256));

            //вносим ip *.*.*.0
            cacheElementsClass.ip = ip_address;
            cacheElementsClass.country = country;
            cacheElementsClass.city = city;
            cacheElementsClass.carrier = carrier;
            cacheElementsClass.organization = organization;
            cacheElementsClass.ccode = ccode;
            cacheElementsClass.state = state;
            cacheElementsClass.sld = sld;
            cacheList.Add(cacheElementsClass);
        }

        public static string[] getFromRamCache(string ip)
        {
            string[] returnResult = new string[11];
            //получаем long ip
            long longIp = mgtCore.IPToLong(ip);
            //получаем из long ip обычный по маске 24 путем вычитания из long IP остатка от деления на 256
            ip = mgtCore.LongToIP(longIp - (longIp % 256));

            //ищем по ip *.*.*.0
            for (int i = 0; i < cacheList.Count; i++)
            {
                if (cacheList[i].ip == ip)
                {
                    returnResult[0] = "something found in local cache";
                    returnResult[1] = cacheList[i].ip;
                    returnResult[2] = cacheList[i].country;
                    returnResult[3] = cacheList[i].city;
                    returnResult[4] = cacheList[i].carrier;
                    returnResult[5] = cacheList[i].organization;
                    returnResult[6] = cacheList[i].ccode;
                    returnResult[7] = cacheList[i].state;
                    returnResult[8] = cacheList[i].sld;
                    return returnResult;
                }
            }
            returnResult[0] = "nothing found in local cache";
            return returnResult;
        }


        public static void showLocalCache()
        {
            mgtRamCache localCacheForm = new mgtRamCache();
            localCacheForm.ShowDialog();
        }

        private static bool findIp(ISPdatatable dbtable, string ip)
        {
            if (dbtable.ip == ip)
            {
                return true;
            }
            {
                return false;
            }

        }

        private void button_GetCacheData_Click_1(object sender, EventArgs e)
        {
            button_GetCacheData.Enabled = false;

            for (int i = 0; i < cacheList.Count; ++i)
            {
                dataGridView_localCache.Rows.Add(
                    cacheList[i].ip,
                    cacheList[i].country,
                    cacheList[i].city,
                    cacheList[i].carrier,
                    cacheList[i].organization,
                    cacheList[i].ccode,
                    cacheList[i].state,
                    cacheList[i].sld);
            }

            dataGridView_localCache.AutoResizeColumns();

            this.Height = dataGridView_localCache.Height = dataGridView_localCache.Size.Height;
            this.Height += 65;


            this.Width = 0;

            for (int i = 0; i < dataGridView_localCache.Columns.Count; i++)
            {
                this.Width += dataGridView_localCache.Columns[i].Width;
            }

            dataGridView_localCache.Width = this.Width + 25;
            this.Width += 45;
            button_GetCacheData.Left = this.Width / 2 - button_GetCacheData.Size.Width / 2;

            dataGridView_localCache.AutoResizeColumns();
            dataGridView_localCache.AutoResizeRows();
        }
    }



    public class ISPdatatable
    {
        public string ip { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string carrier { get; set; }
        public string organization { get; set; }
        public string ccode { get; set; }
        public string state { get; set; }
        public string sld { get; set; }
    }
}

