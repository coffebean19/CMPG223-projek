using cmpg223_final_project.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cmpg223_final_project
{
    public partial class verify : Form
    {
        public verify()
        {
            this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void verify_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public static int sfloat;
        private void btn_Login_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();
            string[] admin = db.ReadFromEmployees(int.Parse(db.GetAdminId()));

            if(txb_float.Text != "" && txb_PwdAdmin.Text == admin[5])
            {
                sfloat = Convert.ToInt32(txb_float.Text);
                sales sales = new sales();
                sales.Show();
                this.Hide();
            }
            else if(txb_float.Text == "")
            {
                lblMessage.Text = "Please fill in the float";
                lblMessage.Visible = true;
            }
            else if(txb_PwdAdmin.Text != "admin")
            {
                lblMessage.Text = "Admin validation required!";
                lblMessage.Visible = true;
            }
        }

        private void txb_float_TextChanged(object sender, EventArgs e)
        {

        }

        private void txb_float_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
