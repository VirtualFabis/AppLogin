using FlatLoginWatermark.Models;
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
    internal class SelectController
    {
        private readonly string cnx = "datasource=127.0.0.1;port=3306;username=root;password=;database=db;";
        public ContactClass GetContact([FromBody] Contact parametos)
        {
            ContactClass contacts = new ContactClass();
            using (MySqlConnection databaseConnection = new MySqlConnection(cnx))
            {
                try
                {
                    if (parametos.Email != "Email" && parametos.Email != "")
                    {
                        string query = "SELECT Name, Email, Phone FROM `contactos` WHERE Email = '" + parametos.Email + "';";
                        databaseConnection.Open();
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 100;
                        MySqlDataReader reader = commandDatabase.ExecuteReader();
                        if (reader.HasRows)
                        {
                            reader.Read();
                            contacts.Name = reader.GetString(0);
                            contacts.Email = reader.GetString(1);
                            contacts.Phone = reader.GetString(2);

                        }
                        else
                        {
                            MessageBox.Show("No se encontro ningun contacto con ese email");

                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingresa un email para buscar un contacto");

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
                return contacts;
            }

        }
    }
}

