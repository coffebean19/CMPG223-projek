using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using cmpg223_final_project.classes;

namespace cmpg223_final_project
{
    public partial class Login : Form
    {
        public Login()
        {
            this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();

            try
            {
                string[] user = db.ReadFromEmployees(int.Parse(txb_Username.Text));
                if (txb_Pwd.Text == user[5])
                {
                    txb_Pwd.Text = "";
                    txb_Username.Text = "";
                    verify validation = new verify();
                    validation.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                lblMessage.Text = "Incorrect login details!";
                lblMessage.Visible = true;
            }
        }
    }
}
