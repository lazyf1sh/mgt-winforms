using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MGT
{
    static class mgtQuova
    {
        private static int z = 0;
        static public string getXML(string ipAddress)
        {
            string service = "http://api.quova.com/"; //old
            //string service = "http://api.neustar.biz/ipi/std/"; //new
            string version = "v1/";
            string method = "ipinfo/";

            //old lazyf1sh for me
            //string[] secrets = { "NnwYmg7Q" };
            //string[] keys = { "100.ubufqdrug5knqdmyxdxp" };

            //new cbb22e4d4d for all
            /*
            string[] secrets = { "GBXkznkJ" }; //зашкварен из-за программной ошибки после изменения функции Get Correct IP. Теперь ебашится весь буфер обмена как IP
            string[] keys = { "100.3r9g5efsd8h4kfw8qvba" }; //зашкварен из-за программной ошибки после изменения функции Get Correct IP. Теперь ебашится весь буфер обмена как IP
            */
            string[] secrets = { "jYgmW3Ze" };
            string[] keys = { "100.jbdmhr5nqm8y3wne2rru" };
             

            //proxyuse:

            //HideMe.Ru Russia, Saint Petersburg
            //string[] secrets = { "dAjKtuBA", "a75RNPyf", "HcbHfKFU" };
            //string[] keys = { "100.2s9tsmp9v7t8p9pap26p", "100.8drcugwh45d6x572a4ky", "100.4y9uqpuf66gvsm59bxfa" };

            //HideMe.Ru Russia, Saratov
            //string[] secrets = { "kPPA9mwH", "EcbTuTS3", "RSUzpfbZ" };
            //string[] keys = { "100.tpfqgb96xwuujrfnr69q", "100.h29zqwjp4tfc59esdajp", "100.k4dax8s3dr95ckyssg55" };


            //Riga 1:
            //string[] secrets = { "AEeaVEQC", "aAHUyQrX", "Mj2bxbg2" };
            //string[] keys = { "100.84tjy98wz9ftk6zqfzz5", "100.5r33c836n9ytpv7p77ta", "100.dcegs6eetmepqc6wana8" };

            //riga 2:
            //string[] secrets = { "t8uB9TSd", "BR7DjYw7", "DuJaa9Fv" };
            //string[] keys = { "100.7hw378hk79wq3gkp367s", "100.dwtxsawanztu8es6n89v", "100.be2e4zrfjxyrhj7d7f52" };

            //riga3:
            //string[] secrets = { "xnjqkjY2", "fX4czkT6", "evzuG9KW" };
            //string[] keys = { "100.kbru6ews6zgwv4cmd8bh", "100.47gx373gj9befp9y6d83", "100.re9vpsh3b4sercz5bgrf" };

            string apikey;
            string secret;
            if (z == secrets.Count())
            {
                z = 0;
                apikey = keys[z];
                secret = secrets[z];
                z++;
            }
            else
            {
                apikey = keys[z];
                secret = secrets[z];
                z++;
            }

            string sig = MD5GenerateHash(apikey + secret + (Int32)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds);
            string fullURL = service + version + method + ipAddress + "?apikey=" + apikey + "&sig=" + sig + "&format=xml";
            
            try
            {
                var request1 = (HttpWebRequest)WebRequest.Create(fullURL);
                //use it only on riga
                //request1.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:18.0) Gecko/20100101 Firefox/18.0";
                using (var response1 = request1.GetResponse())
                {
                    using (var responseStream = response1.GetResponseStream())
                    {
                        //Get the response stream
                        StreamReader reader = new StreamReader(response1.GetResponseStream());
                        //mgtSettings.xmlUpdQueries("apiQueriesDaily");
                        // Write response to the console
                        //File.AppendAllText("1.html", reader.ReadToEnd());
                        //Environment.Exit(0);


                        //for (int i = 0; i < 1; i++) reader.ReadLine();
                        return reader.ReadLine();
                    }
                }

            }
            //обработка исключений
            catch (WebException ex)
            {
                //if (ex.Status == WebExceptionStatus.ProtocolError && ex.Response != null)
                //{
                //    var resp = (HttpWebResponse)ex.Response;
                //    if (resp.StatusCode == HttpStatusCode.NotFound)
                //    {

                //    }
                //    else
                //    {
                //        // Do something else
                //    }
                //}
                //else
                //{
                //    // Do something else
                //}
                return "there's some error with WebRequest";
            }

        }

        private static string MD5GenerateHash(string strInput)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strInput));

            // Create a new Stringbuilder to collect the bytes and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data and format each one as a hexadecimal string.
            for (int nIndex = 0; nIndex < data.Length; ++nIndex)
            {
                sBuilder.Append(data[nIndex].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}