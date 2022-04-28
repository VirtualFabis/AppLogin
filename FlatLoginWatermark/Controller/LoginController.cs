using FlatLoginWatermark.Models;
using FlatLoginWatermark.Views;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MySql.Data.MySqlClient;
using System;
using System.Runtime.Caching;
using System.Windows.Forms;
using static FlatLoginWatermark.Models.UserDataClass;

namespace FlatLoginWatermark.Controller
{
    internal class LoginController
    {
        private readonly string cnx = "datasource=127.0.0.1;port=3306;username=root;password=;database=db;";
        public void Login([FromBody] UserClass parametros)
        {
            using (MySqlConnection databaseConnection = new MySqlConnection(cnx))
            {
                try
                {
                    if (parametros.User != "usuario" && parametros.Password != "Contraseña")
                    {
                        UserData data = new UserData();
                        string query = "select * from users where user='" + parametros.User + "' and password='" + parametros.Password + "';";
                        databaseConnection.Open();
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 100;
                        MySqlDataReader reader = commandDatabase.ExecuteReader();
                        if (reader.HasRows)
                        {

                            reader.Read();
                            data.User = reader.GetString(0);
                            data.Name = reader.GetString(1);
                            data.Email = reader.GetString(2);
                            data.Phone = Convert.ToDouble(reader.GetString(3));
                            string key = "user";
                            string value =  data.User;

                            //Get a reference to the default MemoryCache instance.
                            var cacheContainer = System.Runtime.Caching.MemoryCache.Default;

                            var policy = new CacheItemPolicy()
                            {
                                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1000)
                            };
                            var itemToCache = new CacheItem(key, value); //Value is of type object.
                            cacheContainer.Set(itemToCache, policy);

                            MessageBox.Show("Bienvenido "+ data.Name);
                            Crud index = new Crud();
                            parametros.close = true;
                            index.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario/Contraseña Incorrectos");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese los datos Porfavor");
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
