using cmpg223_final_project.classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            LoadEmployeePanels();
        }

        private void DeleteEmployee_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string id = control.Parent.Controls[0].Text;
            DbConnection db = new DbConnection();
            db.RemoveFromRights(id);
            db.DeleteFromEmployees(id);
            LoadEmployeePanels();
        }


        private void LoadEmployeePanels()
        {
            //foreach (Control item in this.Controls)
            //{
            //    if (item is Panel)
            //    {
            //        if (item.Name != "pnlAdd")
            //        {
            //            this.Controls.Remove(item);
            //        }
            //    }
            //}

            for (int i = this.Controls.Count - 1; i >= 0 ; i--)
            {
                if (this.Controls[i] is Panel)
                { 
                    if(this.Controls[i].Name != "pnlAdd")
                    {
                        this.Controls[i].Dispose();
                    }
                }
            }

            DbConnection db = new DbConnection();
            string qu = "SELECT * FROM `paris_pub`.`employee`;";
            db.Connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
                var reader = cmd.ExecuteReader();
                int x = 10;
                int y = 10;
                while (reader.Read())
                {
                    Panel panel = new Panel();
                    panel.Location = new Point(x, y);
                    panel.Size = new Size(150, 280);
                    panel.BackColor = Color.Azure;

                    PictureBox image = new PictureBox();
                    image.ImageLocation = reader[6].ToString();
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    image.Size = new Size(100, 100);
                    image.Location = new Point(10, 10);

                    Label name = new Label();
                    Label surname = new Label();
                    Label id = new Label();
                    id.Text = reader[0].ToString();
                    name.Text = reader[1].ToString();
                    surname.Text = reader[2].ToString();
                    id.Location = new Point(10, 120);
                    name.Location = new Point(10, 140);
                    surname.Location = new Point(10, 160);
                    id.Size = new Size(55, 13);
                    name.Size = new Size(55, 13);
                    surname.Size = new Size(55, 13);

                    panel.Controls.Add(id);
                    panel.Controls.Add(name);
                    panel.Controls.Add(surname);
                    panel.Controls.Add(image);

                    Button delete = new Button();
                    delete.Text = "Delete";
                    delete.Location = new Point(10, 180);
                    delete.Size = new Size(75, 23);
                    delete.Click += new EventHandler(DeleteEmployee_Click);

                    Button adminIt = new Button();
                    adminIt.Text = "admin";
                    adminIt.Location = new Point(10, 210);
                    adminIt.Size = new Size(75, 23);
                    adminIt.Click += new EventHandler(Admin_Click);

                    Button addImage = new Button();
                    addImage.Text = "Image";
                    addImage.Location = new Point(10, 240);
                    addImage.Size = new Size(75, 23);
                    addImage.Click += new EventHandler(ChangeImage);

                    panel.Controls.Add(delete);
                    panel.Controls.Add(adminIt);
                    panel.Controls.Add(addImage);

                    Controls.Add(panel);
                    x += 160;
                    if (x > this.Size.Width - 170)
                    {
                        x = 10;
                        y += 290;
                    }
                }
            }
            catch (Exception)
            {

            }
            finally
            {

                db.Connection.Close();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();
            int gender;
            if (cmbGender.SelectedItem.ToString() == "Male")
            {
                gender = 1;
            }
            else
            {
                gender = 0;
            }
            db.InsertIntoEmployees(txbName.Text, txbSurname.Text, gender, dtpBirthday.Value.ToString(), txbPassword.Text);
            string id = db.GetLastEmployeeId();
            db.InsertIntoRights(id, 0);
            LoadEmployeePanels();
        }

        private void ChangeImage(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            image.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            Control control = (Control)sender;
            string id = control.Parent.Controls[0].Text;
            if (image.ShowDialog() == DialogResult.OK)
            {
                DbConnection db = new DbConnection();
                string file = image.FileName.Replace("\\", "\\\\");
                MessageBox.Show(file);
                db.UpdateEmployees(id, "image_path", file);
            }
            else
            {
                MessageBox.Show("Image failed bruv");
            }
            LoadEmployeePanels();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadEmployeePanels();
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string id = control.Parent.Controls[0].Text;
            MessageBox.Show(id);
            try
            {
                DbConnection db = new DbConnection();
                MessageBox.Show(db.ReadFromRights(id)[1]);
                if (db.ReadFromRights(id)[1].ToString() == "1")
                {
                    db.ChangeRights(id, 0);
                }
                else
                {
                    db.ChangeRights(id, 1);
                }
            }
            catch (Exception)
            {

            }
            
        }
    }
}
