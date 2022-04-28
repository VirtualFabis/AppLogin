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
    public partial class UpdateAndDelete : Form
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
        public UpdateAndDelete()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Crud obj = new Crud();
            obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            SelectController controller = new SelectController();
            Contact data = new Contact();
            ContactClass contacts = new ContactClass();
            data.Email = textEmail.Text;
            contacts = controller.GetContact(data);
            textEmail.Text = contacts.Email;
            textName.Text = contacts.Name;
            textPhone.Text = contacts.Phone;
        }

        private void borrar_Click(object sender, EventArgs e)
        {
            DeleteController controller = new DeleteController();
            Contact contact = new Contact();
            contact.Email = textEmail.Text;
            controller.Delete(contact);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textEmail.Text = "";
            textName.Text = "";
            textPhone.Text = "";
        }
    }
}
