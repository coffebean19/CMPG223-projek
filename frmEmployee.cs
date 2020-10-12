using cmpg223_final_project.classes;
using MySql.Data.MySqlClient;
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
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();
            string qu = "SELECT * FROM `paris_pub`.`employee`;";
            db.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();
            int x = 10;
            int y = 10;
            while (reader.Read())
            {
                Panel panel = new Panel();
                panel.Location = new Point(x += 160, y);
                panel.Size = new Size(150, 200);
                panel.BackColor = Color.Azure;

                PictureBox image = new PictureBox();
                image.ImageLocation = reader[6].ToString();
                image.SizeMode = PictureBoxSizeMode.StretchImage;
                image.Size = new Size(100, 100);
                image.Location = new Point(10, 10);

                Label name = new Label();
                Label surname = new Label();
                name.Text = reader[1].ToString();
                surname.Text = reader[2].ToString();
                name.Location = new Point(10, 120);
                surname.Location = new Point(10, 140);
                name.Size = new Size(100, 20);
                surname.Size = new Size(100, 20);

                panel.Controls.Add(name);
                panel.Controls.Add(surname);
                panel.Controls.Add(image);
                panel.Click += new EventHandler(Employee_Click);

                Controls.Add(panel);
            }
        }

        private void Employee_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            MessageBox.Show(control.Controls[0].Text);
        }
    }
}
