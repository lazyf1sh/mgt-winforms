using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MGT
{
    class mgtGlobals
    {
        public static bool isCarrierButtonEnabled = false;

        private const string currentMgtVerison = "0.0.74"; //+returner
        private const string networkLogPath = @"W:\Tools\resources\mgt_log.txt"; //+returner
        private static string appdataMgtFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MGT\"; //+returner


        private static string appdataMgtLogFile = @"mgtLog.log";
        private static string appdataMgtLogFilePath = appdataMgtFolderPath + appdataMgtLogFile; //+returner

        //
        private static string sqliteFileNameLocal = @"mgt3.sqlite";
        private static string sqliteFilePathLocal = appdataMgtFolderPath + sqliteFileNameLocal; //+returner
        //
        private static string sqliteFileNameNetWork = @"mgt_network4.sqlite";
        private static string sqliteFolderNameNetWork = @"\\v1user018.mail.msk\mgt_public\";
        private static string sqliteFilePathNetWork = sqliteFolderNameNetWork + sqliteFileNameNetWork;

        private static string diskWUpdatePath = @"W:\Tools\";

        public static string getDiskWUpdatePath()
        {
            return diskWUpdatePath;
        }

        private static List<string> lineMatchesToRun;

        public static List<string> getLineMatchesToRun()
        {
            return lineMatchesToRun;
        }

        public static void setLineMatchesToRun(List<string> lines)
        {
            lineMatchesToRun = lines;
        }

        private static int batchProgress;

        public static int getBatchProgress()
        {
            return batchProgress;
        }

        public static void setBatchProgress(int progress)
        {
            batchProgress = progress;
        }


        private static int linesWasCopiedToBatchProccess;

        public static void setLinesWasCopiedToBatchProccess(int lines)
        {
            linesWasCopiedToBatchProccess = lines;
        }

        public static int getLinesWasCopiedToBatchProccess()
        {
            return linesWasCopiedToBatchProccess;
        }

        public static string getSqliteFilePathNetwork()
        {
            return sqliteFilePathNetWork;
        }

        public static string getSqliteFilePathLocal()
        {
            return sqliteFilePathLocal;
        }

        public static string getAppdataMgtLogFilePath()
        {
            return appdataMgtLogFilePath;
        }

        public static string getNetworkLogPath()
        {
            return networkLogPath;
        }

        public static string getAppdataMgtFolderPath()
        {
            return appdataMgtFolderPath;
        }

        public static string getCurrentMgtVerison()
        {
            return currentMgtVerison;
        }


        private static List<batchFormData> batchArray = new List<batchFormData>();

        public static void setBatchArray(List<batchFormData> array)
        {
            batchArray = array;
        }

        public static List<batchFormData> getBatchArray()
        {
            return batchArray;
        }

    }


    

    public class batchFormData
    {
        public string clipdata;
        public string ip;
        public string country;
        public string city;
        public string carrier;
        public string organization;
        public string ccode;
        public string state;
        public string sld;
    }
}
