using FlatLoginWatermark.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
    using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Windows.Forms;

namespace FlatLoginWatermark.Controller
{
    internal class RegistrarContactController
    {
        private readonly string cnx = "datasource=127.0.0.1;port=3306;username=root;password=;database=db;";


        public void registrarContactos([FromBody] ContactClass data)
        {
            using (MySqlConnection databaseConnection = new MySqlConnection(cnx))
            {
                try
                {
                    if (data.Email != "Email" && data.Name != "Nombre Completo" && data.Phone.ToString() != "Telefono")
                    {
                        string user = "";
                        string key = "user";
                        CacheItemPolicy policy = new CacheItemPolicy()
                        {
                            AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1000)
                        };
                        var cacheContainer = MemoryCache.Default;
                        var cachedItem = cacheContainer.AddOrGetExisting(key, user, policy) as string;
                        string query = "INSERT INTO contactos (Id_User,Name,Email,Phone) VALUES " +
                            "('" + cachedItem + "','" + data.Name + "','" + data.Email + "','" + data.Phone + "')";
                        databaseConnection.Open();
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 100;
                        MySqlDataReader reader = commandDatabase.ExecuteReader();
                        MessageBox.Show("Agregaste a un nuevo usuario");
                    }

                    else
                    {
                        MessageBox.Show("Ingrese los datos");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    databaseConnection.Close();

                }
            }
        }

    }
}
