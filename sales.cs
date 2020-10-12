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
    public partial class sales : Form
    {
        public sales()
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            InitializeComponent();
        }

        private void sales_Load(object sender, EventArgs e)
        {
            txbCash.Text = verify.sfloat.ToString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void btnPay_Click(object sender, EventArgs e)
        {

            int Ttotal = 0, Ptotal = 0;
            Ptotal = Convert.ToInt32(txbPayCash.Text) - Convert.ToInt32(txbTotal.Text);
            txbChange.Text = Ptotal.ToString();
            Ttotal = Convert.ToInt32(txbCash.Text);
            if (Ptotal >= 0)
            {
                Ttotal += Convert.ToInt32(txbTotal.Text);
                txbCash.Text = Ttotal.ToString();
                txbPayCash.Text = "0";
                txbTotal.Text = "0";
            }
            else if (Ptotal < 0)
            {
                MessageBox.Show("The amount payed is not enough!!");
                txbPayCash.Text = "0";
            }
            price = 0;
            listBox1.Items.Clear();
        }

        private void txbPayCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            txbChange.Text = "0";
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

        }
        private void btnVodka_Click(object sender, EventArgs e)
        {
            sales_Load(null, EventArgs.Empty);
            DbConnection db = new DbConnection();
            string qu = "SELECT * FROM `paris_pub`.`stock` WHERE (`prod_type` = '" + btnVodka.Text + "');";
            db.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();
            int x = 10, y = 130;
            while (reader.Read())
            {
                PictureBox pic = new PictureBox();
                //PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                if (x > 1285)
                    y += 135;

                pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = reader[5].ToString();
                pic.Size = new Size(130,125);

                Controls.Add(pic);
                x += 140;
            }
            db.Connection.Close();

            


            /*P1.ImageLocation = null;
            DbConnection db = new DbConnection();
            db.Connection.Open();
            string qu = "SELECT * FROM `paris_pub`.`stock` WHERE (`prod_type` = '" + btnVodka.Text + "');";
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();
            reader.Read();
            P1.ImageLocation = reader[5].ToString();
            //Image img = Image.FromFile.Location(reader[5].ToString());
            P1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //P1.Image = img;
            //listBox1.Items.Add(reader[5].ToString());
            //listBox1.Items.Add(img.ToString());
            db.Connection.Close();*/
            
        }
        public int price;
        /*private void P1_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();
            string path = P1.ImageLocation;
            //listBox1.Items.Add(path);
            try
            {
                //string qu = "SELECT * FROM `paris_pub`.`stock` WHERE (`Picture` = @'" + path + "');";
                string qu = "SELECT * FROM `paris_pub`.`stock`";
                MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
                db.Connection.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetValue(5).ToString() == path)
                    {
                        listBox1.Items.Add(reader.GetValue(2).ToString() + " @ R" + reader.GetValue(4).ToString());
                        price += Convert.ToInt32(reader.GetValue(4));
                    }
                }
            }
            catch (Exception d)
            {
                MessageBox.Show(d.ToString());
            }
            finally
            {
                txbTotal.Text = price.ToString();
                db.Connection.Close();
            }
        }*/

        private void btnBrandy_Click(object sender, EventArgs e)
        {
            sales_Load(null, EventArgs.Empty);
            DbConnection db = new DbConnection();
            string qu = "SELECT * FROM `paris_pub`.`stock` WHERE (`prod_type` = '" + btnBrandy.Text + "');";
            db.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();
            int x = 10, y = 130;
            while (reader.Read())
            {
                PictureBox pic = new PictureBox();
                pic.Location = new Point(x, y);
                if (x > 1285)
                    y += 135;
                pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pic.ImageLocation = reader[5].ToString();
                pic.Size = new Size(130, 125);

                Controls.Add(pic);
                x += 140;
            }
            db.Connection.Close();
            /*P1.ImageLocation = null;
            DbConnection db = new DbConnection();
            db.Connection.Open();
            string qu = "SELECT * FROM `paris_pub`.`stock` WHERE (`prod_type` = '" + btnBrandy.Text + "');";
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();
            reader.Read();
            P1.ImageLocation = reader[5].ToString();
            //Image img = Image.FromFile(reader[5].ToString());
            P1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            //P1.Image = img;
            //listBox1.Items.Add(reader[5].ToString());
            db.Connection.Close();*/
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            txbTotal.Text = "0";
        }
    }
}
