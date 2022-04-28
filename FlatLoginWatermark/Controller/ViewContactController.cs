using FlatLoginWatermark.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatLoginWatermark.Controller
{
    internal class ViewContactController
    {
        private readonly string cnx = "datasource=127.0.0.1;port=3306;username=root;password=;database=db;";
        public DataTable GetContact()
        {
            DataTable contacts = new DataTable();
            using (MySqlConnection databaseConnection = new MySqlConnection(cnx))
            {
                try
                {
                    string user = String.Empty;
                    string key = "user";
                    CacheItemPolicy policy = new CacheItemPolicy()
                    {
                        AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1000)
                    };
                    var cacheContainer = MemoryCache.Default;
                    var cachedItem = cacheContainer.AddOrGetExisting(key, user, policy) as string;
                    string query = "SELECT Name, Email, Phone FROM `contactos` WHERE Id_User = '"+ cachedItem + "';";
                        databaseConnection.Open();
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 100;
                        MySqlDataReader reader = commandDatabase.ExecuteReader();
                          contacts.Load(reader);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    databaseConnection.Close();
                }
                return contacts;
            }
        }
    }
}
