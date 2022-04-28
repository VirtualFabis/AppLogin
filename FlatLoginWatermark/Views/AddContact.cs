using FlatLoginWatermark.Controller;
using FlatLoginWatermark.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlatLoginWatermark.Views
{
  
    public partial class AddContact : Form
    {
        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        #endregion
        #region Placeholder or WaterMark
        private void txtnombre_Enter(object sender, EventArgs e)
        {
            if (textName.Text == "Nombre Completo")
            {
                textName.Text = "";
                textName.ForeColor = Color.LightGray;
            }
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                textName.Text = "Nombre Completo";
                textName.ForeColor = Color.Silver;
            }
        }
        private void txtemail_Enter(object sender, EventArgs e)
        {
            if (textEmail.Text == "Email")
            {
                textEmail.Text = "";
                textEmail.ForeColor = Color.LightGray;
            }
        }

        private void txtemail_Leave(object sender, EventArgs e)
        {
            if (textEmail.Text == "")
            {
                textEmail.Text = "Email";
                textEmail.ForeColor = Color.Silver;
            }
        }
        private void txttelefono_Enter(object sender, EventArgs e)
        {
            if (textPhone.Text == "Telefono")
            {
                textPhone.Text = "";
                textPhone.ForeColor = Color.LightGray;
            }
        }

        private void txttelefono_Leave(object sender, EventArgs e)
        {
            if (textPhone.Text == "")
            {
                textPhone.Text = "Telefono";
                textPhone.ForeColor = Color.Silver;
            }
        }

        #endregion

        public AddContact()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            ContactClass contat = new ContactClass();
            contat.Name = textName.Text;
            contat.Email = textEmail.Text;
            contat.Phone= textPhone.Text;
            RegistrarContactController controller = new RegistrarContactController();
            controller.registrarContactos(contat);
            textName.Clear();
            textEmail.Clear();
            textPhone.Clear();


        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            Crud obj = new Crud();
            obj.Show();
            this.Hide();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
