using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;

namespace MGT
{
    class mgtSqliteCache
    {
        public static void createBaseFile(string sqlitePath)
        {
            
            if (!File.Exists(sqlitePath))
            {
                SQLiteConnection.CreateFile(sqlitePath);
                SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder();
                connBuilder.DataSource = sqlitePath;
                connBuilder.Version = 3;
                connBuilder.DefaultTimeout = 400;

                SQLiteConnection connection = new SQLiteConnection(connBuilder.ToString());
                connection.Open();

                string ispdbcreate = @"CREATE TABLE 
                    [subnetGeoData] (
                    [subnet] INTEGER NOT NULL UNIQUE DEFAULT 1, 
                    [country] VARCHAR NOT NULL DEFAULT None, 
                    [city] VARCHAR NOT NULL DEFAULT None, 
                    [carrier] VARCHAR NOT NULL DEFAULT None, 
                    [org] VARCHAR NOT NULL DEFAULT None, 
                    [ccode] VARCHAR NOT NULL DEFAULT None, 
                    [state] VARCHAR NOT NULL DEFAULT None, 
                    [sld] VARCHAR NOT NULL DEFAULT None, 
                    [adder] VARCHAR NOT NULL DEFAULT None, 
                    [adddate] INTEGER NOT NULL DEFAULT 1,
                    [idx] INTEGER)";

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = ispdbcreate;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
                connection.Dispose();
            }
        }

        public static void setDataToSQLite(string sqlitePath, string ip_address, string country, string city, string carrier, string organization, string ccode, string state, string sld)
        {
            if (File.Exists(sqlitePath))
            {
                SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder();
                connBuilder.DataSource = sqlitePath;
                connBuilder.Version = 3;
                connBuilder.DefaultTimeout = 400;

                SQLiteConnection connection = new SQLiteConnection(connBuilder.ToString());
                connection.Open();

                ip_address = ip_address.Replace("'", @"");
                country = country.Replace("'", @"");
                city = city.Replace("'", @"");
                carrier = carrier.Replace("'", @"");
                organization = organization.Replace("'", @"");
                ccode = ccode.Replace("'", @"");
                state = state.Replace("'", @"");
                sld = sld.Replace("'", @"");

                int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
                //string adderName = Environment.UserName.Replace("'", @"");
                string adderName = "";
                long longIP = mgtCore.IPToLong(ip_address);
                
                long longSubnet = longIP - (longIP % 256);
                long idx = longIP - (longIP % 65536);
                string dataToPut =
                @"INSERT INTO [subnetGeoData] ([subnet], [country], [city], [carrier], [org], [ccode], [state], [sld], [adder], [adddate], [idx]) 
                            VALUES ( '" +
                            longSubnet + "',  '" +
                            country + "',  '" +
                            city + "',  '" +
                            carrier + "',  '" +
                            organization + "',  '" +
                            ccode + "',   '" +
                            state + "',   '" +
                            sld + "',   '" +
                            adderName + "',   '" +
                            unixTime + "',   '" +
                            idx + "')";

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {

                    command.CommandText = dataToPut;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }

                connection.Close();
                connection.Dispose();
            }
        }

        public static string[] getDataFromSQLite(string sqlitePath, string ip)
        {
            string[] searchQueryResult = new string[10];
            if (File.Exists(sqlitePath))
            {
                SQLiteConnectionStringBuilder connBuilder = new SQLiteConnectionStringBuilder();
                connBuilder.DataSource = sqlitePath;
                connBuilder.Version = 3;
                connBuilder.DefaultTimeout = 400;

                SQLiteConnection connection = new SQLiteConnection(connBuilder.ToString());
                connection.Open();

                long longIP = mgtCore.IPToLong(ip);
                long longSubnet = longIP - (longIP % 256);
                
                //string searchQuery = "SELECT * FROM subnetGeoData WHERE subnet LIKE '" + longSubnet + "';";
                string searchQuery =
                @"SELECT *
                FROM subnetGeoData
                WHERE idx = (" + longSubnet + "-(" + longSubnet + " % 65536)) AND subnet LIKE '" + longSubnet + "';";
                
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = searchQuery;
                    command.CommandType = CommandType.Text;
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        searchQueryResult[0] = "something found";
                        connection.Close();
                        connection.Dispose();

                        //т.к. поменял аргументы функции setdatatoform, тут придется поменять порядок возвращения в массве
                        //потом поправить в базе (!)

                        searchQueryResult[1] = dt.Rows[0].Field<string>(1).ToString(); //subnet
                        searchQueryResult[2] = dt.Rows[0].Field<string>(2).ToString(); //ccode
                        searchQueryResult[3] = dt.Rows[0].Field<string>(3).ToString(); //country
                        searchQueryResult[4] = dt.Rows[0].Field<string>(4).ToString(); //city
                        searchQueryResult[5] = dt.Rows[0].Field<string>(5).ToString(); //carrier
                        searchQueryResult[6] = dt.Rows[0].Field<string>(6).ToString(); //org
                        searchQueryResult[7] = dt.Rows[0].Field<string>(7).ToString(); //state
                        searchQueryResult[8] = dt.Rows[0].Field<string>(8).ToString(); //sld
                        return searchQueryResult;
                    }
                    else
                    {
                        searchQueryResult[0] = "nothing found";
                        return searchQueryResult;
                    }

                    /*
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    MessageBox.Show(dt.Rows[0].Field<string>(3).ToString());
                    if (reader[0].ToString() == "")
                    {
                        searchQueryResult[0] = "nothing found";
                        return searchQueryResult;
                    }
                    else
                    {
                        searchQueryResult[0] = "something found";
                        while (reader.Read())
                            for (int i = 1; i < 8; i++)
                            {
                                searchQueryResult[i] += reader[i].ToString();
                            }
                        connection.Close();
                        connection.Dispose();
                        return searchQueryResult;
                    }
                     * */
                }
            }
            else
            {
                searchQueryResult[0] = "nothing found";
                return searchQueryResult;
            }

        }
    }
}