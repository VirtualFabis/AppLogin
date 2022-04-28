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
    public partial class Crud : Form
    {
        public Crud()
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddContact obj = new AddContact();
            obj.Show();
            this.Hide();
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Crud_Load(object sender, EventArgs e)
        {
            ViewContactController view = new ViewContactController();
            DataTable dt = new DataTable();
            dt = view.GetContact();
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            labeldate.Text = DateTime.Now.ToString("hh:mm");




        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UpdateAndDelete obj = new UpdateAndDelete();
            obj.Show();
            this.Hide();
        }
    }
}
