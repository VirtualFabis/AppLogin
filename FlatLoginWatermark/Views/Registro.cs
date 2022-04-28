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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
        }
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
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                txtuser.Text = "Usuario";
                txtuser.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "")
            {
                txtpass.Text = "Contraseña";
                txtpass.ForeColor = Color.Silver;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        #endregion

        private void btnlogin_Click(object sender, EventArgs e)
        {
            SendData data = new SendData();
            data.User = txtuser.Text;
            data.Email = textEmail.Text;
            data.Name = textName.Text;
            data.Phone = textPhone.Text;
            data.Password = txtpass.Text;
            RegistroController controller = new RegistroController();
            controller.registrar(data);
            if (data.send != true)
            {
                this.Hide();
            }
        }

        private void btncerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            registro obj = new registro();
            obj.Show();
            this.Hide();
        }
    }
}
