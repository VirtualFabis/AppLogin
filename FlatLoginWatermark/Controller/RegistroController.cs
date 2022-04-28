using FlatLoginWatermark.Models;
using FlatLoginWatermark.Views;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatLoginWatermark.Controller
{

    internal class RegistroController
    {
        private readonly string cnx = "datasource=127.0.0.1;port=3306;username=root;password=;database=db;";
        public void registrar([FromBody] SendData data)
        {
            using (MySqlConnection databaseConnection = new MySqlConnection(cnx))
            {
                try
                {
                    validaruser(data);
                    if ( data.User !=  "Usuario" && data.Email != "Email" && data.Name != "Nombre Completo" && data.Phone != "Telefono" && data.Password != "Contraseña")
                    {
                        if (data.send != true)
                        {
                            string query = "INSERT INTO users (User, Name,Email,Phone,Password) VALUES " +
                                "('" + data.User + "','" + data.Name + "','" + data.Email + "','" + data.Phone + "','" + data.Password + "')";
                            databaseConnection.Open();
                            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                            commandDatabase.CommandTimeout = 100;
                            MySqlDataReader reader = commandDatabase.ExecuteReader();
                            registro login = new registro();
                            login.Show();
                            data.send = false;
                        }
                        else
                        {
                            MessageBox.Show("Usuario Ocupado, Usa otro ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese los datos");
                        data.send = true;
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
        public void validaruser([FromBody] SendData data )
        {
            using (MySqlConnection databaseConnection = new MySqlConnection(cnx))
            {
                try
                {
                   
                        string query = "select * from users where user='" + data.User + "';";
                        databaseConnection.Open();
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 100;
                        MySqlDataReader reader = commandDatabase.ExecuteReader();
                        if (reader.HasRows)
                        {
                            data.send = true;
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
