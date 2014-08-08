using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MGT
{
    class mgtCore
    {
        #region start functions to protect program: checkPcName, checkLocation, checkLicence;
        static public void checkPcName()
        {
            string machineName = Environment.MachineName;
            machineName = machineName.ToLower();
            char[] machineNameSplitted = machineName.ToCharArray();

            string machineNameToCheck = null;
            for (int i = 0; i < 6; i++)
            {
                machineNameToCheck += machineNameSplitted[i];
            }

            if (!(machineNameToCheck == "v1user" || machineNameToCheck == "n1user"))
            {
                Environment.Exit(0);
            }
        }
        static public void checkLicence()
        {
            int currentUnixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            int licenceExpireTime = 1378190609; //03.09.2013 10:43
            
            if ((currentUnixTime) > (licenceExpireTime + (68 * 604800))) //множимое - неделя, прибавляем по 4 к множителю - это ещё месяц
            {
                MessageBox.Show("Пора обновиться : )");
                Environment.Exit(0);
            }
        }
        static public void checkLocation()
        {
            string programPath = Application.ExecutablePath.ToString();
            string[] programPathSplitted = programPath.Split(new Char[] { ':' });
            if ((programPathSplitted[0].ToLower() != "c") && (programPathSplitted[0].ToLower() != "d") && (programPathSplitted[0].ToLower() != "p") && (programPathSplitted[0].ToLower() != "e"))
            {
                MessageBox.Show("Сначала скопируйте на локальный диск.");
                Environment.Exit(0);
            }

        }
        #endregion


        private static void copyNetworkSQLiteFileToAppdata()
        {
            if (File.Exists(mgtGlobals.getSqliteFilePathNetwork()))
            {
                File.Copy(mgtGlobals.getSqliteFilePathNetwork(), mgtGlobals.getSqliteFilePathLocal(), true);
            }
        }

        public static void checklocalDbFileSize()
        {
            if (!File.Exists(mgtGlobals.getSqliteFilePathLocal()))
            {
                MessageBox.Show("Отсутствует локальная база.");
                Environment.Exit(0);
            }
            else
            {
                FileInfo local = new FileInfo(mgtGlobals.getSqliteFilePathLocal());
                //MessageBox.Show(local.Length.ToString());
                if (local.Length < 25602048)
                {
                    MessageBox.Show(@"Локальная база недостаточно наполнена.");
                    Environment.Exit(0);
                }
            }
        }

        public static void copyNetworkSQLiteFile()
        {
            if (!File.Exists(mgtGlobals.getSqliteFilePathLocal()))
            {
                copyNetworkSQLiteFileToAppdata();
            }
            else
            {
                if (File.Exists(mgtGlobals.getSqliteFilePathNetwork()))
                {
                    FileInfo network = new FileInfo(mgtGlobals.getSqliteFilePathNetwork());
                    FileInfo local = new FileInfo(mgtGlobals.getSqliteFilePathLocal());
                    long networkFileSize = network.Length;
                    long localFileSize = local.Length;
                    if (localFileSize < networkFileSize)
                    {
                        copyNetworkSQLiteFileToAppdata();
                    }
                }
            }
        }

        //больше не используется
        static public uint stringIpToInt(string stringAddress)
        {
            uint intAddress = (uint)BitConverter.ToInt32(IPAddress.Parse(stringAddress).GetAddressBytes(), 0);
            return intAddress;
        }

        //больше не используется
        public static string intIpToString(uint intAddress)
        {
            string ipAddress = new IPAddress(BitConverter.GetBytes(intAddress)).ToString();
            return ipAddress;
        }


        public static long IPToLong(string ipAddress)
        {
            System.Net.IPAddress ip;
            if (System.Net.IPAddress.TryParse(ipAddress, out ip))
                return (((long)ip.GetAddressBytes()[0] << 24) | ((int)ip.GetAddressBytes()[1] << 16) | ((int)ip.GetAddressBytes()[2] << 8) | ip.GetAddressBytes()[3]);
            else return 0;
        }

        public static string LongToIP(long ipAddress)
        {
            System.Net.IPAddress tmpIp;
            if (System.Net.IPAddress.TryParse(ipAddress.ToString(), out tmpIp))
            {
                try
                {
                    Byte[] bytes = tmpIp.GetAddressBytes();
                    long addr = (long)BitConverter.ToInt32(bytes, 0);
                    return new System.Net.IPAddress(addr).ToString();
                }
                catch (Exception e) { return e.Message; }
            }
            else return String.Empty;
        }


        
        static public string getCorrectIP(string clipdata)
        {
            //функция проверяет корректный ли IP и возвращает его
            //получаем строку и проверяем, является ли она IP-адресом
            string ipPattern = @"(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)";
            Regex ipAddressOnly = new Regex(ipPattern, RegexOptions.Singleline);
            MatchCollection matches = ipAddressOnly.Matches(clipdata);

            
            //список исключений
            // http://ru.wikipedia.org/wiki/Частный_IP-адрес
            //    10.0.0.0 — 10.255.255.255 (Маска подсети 255.0.0.0 или для бесклассовой адресации /8)
            //    172.16.0.0 — 172.31.255.255 (Маска подсети 255.240.0.0 или для бесклассовой адресации /12)
            //    192.168.0.0 — 192.168.255.255 (Маска подсети 255.255.0.0 или для бесклассовой адресации /16)

            //Также для петлевых интерфейсов (не используется для обмена между узлами сети) зарезервирован диапазон 127.0.0.0 — 127.255.255.255.

            //Технология IP Multicast использует адреса с 224.0.0.0 до 239.255.255.255
            //http://ru.wikipedia.org/wiki/Multicast

            //169.254.0.0/16 — используется для автоматической настройки сетевого интерфейса в случае отсутствия DHCP.
            //http://ru.wikipedia.org/wiki/IP-адрес
            //http://ru.wikipedia.org/wiki/IPv4
            
            string[] exclusionsOneByte = new string[] 
            { 
                "10.", 
                "127.", 
                "0.", 
                "01.", "02.", "03.", "04.", "05.", "06.", "07.", "08.", "09.",
                "224.", "225.", "226.", "227.", "228.", "229.", "230.", "231.", "232.", "233.", "234.", "235.", "236.", "237.", "238.", "239.",
                "240.", "241.", "242.", "243.", "244.", "245.", "246.", "247.", "248.", "249.", "250.", "251.", "252.", "253.", "254.", "255."
            };
            string[] exclusionsTwoByte = new string[] 
            { 
                "198.18.", "198.19.", 
                "192.168.", 
                "172.16.", "172.17.", "172.18.", "172.19.", "172.20.", "172.21.", "172.22.", "172.23.", "172.24.", "172.25.", "172.26.",
                "172.27.", "172.28.", "172.29.", "172.30.", "172.31.", 

                "169.254.",

                "100.64.", "100.65.", "100.66.", "100.67.", "100.68.", "100.69.", "100.70.", "100.71.", "100.72.", "100.73.", "100.74.", 
                "100.75.", "100.76.", "100.77.", "100.78.", "100.79.", "100.80.", "100.81.", "100.82.", "100.83.", "100.84.", "100.85.", 
                "100.86.", "100.87.", "100.88.", "100.89.", "100.90.", "100.91.", "100.92.", "100.93.", "100.94.", "100.95.", "100.96.", 
                "100.97.", "100.98.", "100.99.", "100.100.", "100.101.", "100.102.", "100.103.", "100.104.", "100.105.", "100.106.", 
                "100.107.", "100.108.", "100.109.", "100.110.", "100.111.", "100.112.", "100.113.", "100.114.", "100.115.", "100.116.",
                "100.117.", "100.118.", "100.119.", "100.120.", "100.121.", "100.122.", "100.123.", "100.124.", "100.125.", "100.126.", 
                "100.127."
            };
            string[] exclusionsThreeByte = new string[] 
            {
                "192.0.2.", "198.51.100.", "203.0.113."
            };
            string[] exclusionsFourByte = new string[] 
            { 
                "127.0.0.1", "255.255.255.255"
            };

            //если в буфере обмена есть попадающее значение:
            if (ipAddressOnly.IsMatch(clipdata))
            {
                string ipToCheck = matches[0].Value;
                //проверяем по четырем байтам:

                foreach (string value in exclusionsFourByte)
                {
                    //проверяем целый IP (*.*.*.*)
                    if (value == ipToCheck)
                    {
                        return null;
                    }
                }

                //проверяем по двум байтам:
                string[] twoByteExclusions = ipToCheck.Split((new Char[] { '.' }));
                string twoByteExclusionsMerged = twoByteExclusions[0] + "." + twoByteExclusions[1] + ".";

                foreach (string value in exclusionsTwoByte)
                {
                    if (value == twoByteExclusionsMerged)
                    {
                        return null;
                    }
                }

                //проверяем по трём байтам:
                string[] threeByteExclusions = ipToCheck.Split((new Char[] { '.' }));
                string threeByteExclusionsMerged = threeByteExclusions[0] + "." + threeByteExclusions[1] + "." + threeByteExclusions[2] + ".";

                foreach (string value in exclusionsThreeByte)
                {
                    if (value == threeByteExclusionsMerged)
                    {
                        return null;
                    }
                }

                //проверяем по одному байту:
                string[] oneByteExclusions = ipToCheck.Split((new Char[] { '.' }));
                string oneByteExclusionsMerged = oneByteExclusions[0] + ".";

                foreach (string value in exclusionsOneByte)
                {
                    if (value == oneByteExclusionsMerged)
                    {
                        return null;
                    }
                }

                // иногда бывают строки вида: "5.02.08.2014". Такие строки не поддаются переводу в long ip
                //такие строки совсем не нужны. Никто так не пишет IP-адреса.

                foreach (string byteToCheck in ipToCheck.Split('.'))
                {
                    if (byteToCheck.StartsWith("0") && byteToCheck.Length > 1)
                    {
                        return null;
                    }
                }

                return ipToCheck;
            }
            else
            {
                return null;
            }
        }
    }
}