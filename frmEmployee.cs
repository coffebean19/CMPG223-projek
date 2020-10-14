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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.IO.Image;

namespace cmpg223_final_project
{
    public partial class frmEmployee : Form
    {
        private int id_in_use;

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
            //Remove previous panels
            for (int i = this.Controls.Count - 1; i >= 0 ; i--)
            {
                if (this.Controls[i] is Panel)
                { 
                    if(this.Controls[i].Name != "pnlAdd" && this.Controls[i].Name != "pnlTransactions" && this.Controls[i].Name != "pnlReport")
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

                //Start coordinates for first panel
                int x = 10;
                int y = 10;
                while (reader.Read())
                {
                    //Panel
                    Panel panel = new Panel();
                    panel.Location = new Point(x, y);
                    panel.Size = new Size(151, 300);
                    panel.BackColor = Color.Azure;
                    panel.BorderStyle = BorderStyle.FixedSingle;

                    //Profile picture
                    PictureBox image = new PictureBox();
                    image.ImageLocation = reader[6].ToString();
                    image.SizeMode = PictureBoxSizeMode.StretchImage;
                    image.Size = new Size(125, 125);
                    image.Location = new Point(12, 13);

                    //Name, surname and id labels
                    Label name = new Label();
                    Label surname = new Label();
                    Label id = new Label();
                    id.Text = reader[0].ToString();
                    name.Text = reader[1].ToString();
                    surname.Text = reader[2].ToString();
                    id.Location = new Point(10, 120);
                    name.Location = new Point(10, 140);
                    surname.Location = new Point(10, 160);
                    id.Size = new Size(55, 20);
                    name.Size = new Size(55, 13);
                    surname.Size = new Size(55, 13);

                    //Delete button
                    Button delete = new Button();
                    delete.Text = "Delete";
                    delete.Location = new Point(15, 180);
                    delete.Size = new Size(75, 23);
                    delete.Click += new EventHandler(DeleteEmployee_Click);

                    //Making or unmaking an employee admin
                    Button adminIt = new Button();
                    adminIt.Text = "admin";
                    adminIt.Location = new Point(15, 210);
                    adminIt.Size = new Size(75, 23);
                    adminIt.Click += new EventHandler(Admin_Click);

                    //Adding or changing profile picture button
                    Button addImage = new Button();
                    addImage.Text = "Image";
                    addImage.Location = new Point(15, 240);
                    addImage.Size = new Size(75, 23);
                    addImage.Click += new EventHandler(ChangeImage);

                    //Viewing employee transactions button
                    Button transaction = new Button();
                    transaction.Text = "Transactions";
                    transaction.Location = new Point(15, 270);
                    transaction.Size = new Size(75, 23);
                    transaction.Click += new EventHandler(View_Transactions);

                    //Adds to the controls
                    panel.Controls.Add(id);
                    panel.Controls.Add(name);
                    panel.Controls.Add(surname);
                    panel.Controls.Add(image);
                    panel.Controls.Add(delete);
                    panel.Controls.Add(adminIt);
                    panel.Controls.Add(addImage);
                    panel.Controls.Add(transaction);

                    //Adding to the form
                    Controls.Add(panel);

                    //Setting position for next panel. If going over edge reset x and change y position
                    x += 160;
                    if (x > this.Size.Width - 170)
                    {
                        x = 10;
                        y += 310;
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

        //Adds and employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();
            try
            {
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
            catch (Exception)
            {

            }

        }

        //Changes profile picture
        private void ChangeImage(object sender, EventArgs e)
        {
            OpenFileDialog image = new OpenFileDialog();
            try
            {
                //Only searches for image type files
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
            catch (Exception)
            {
                MessageBox.Show("Error in changing employee picture.");
            }

        }

        //Function to make an employee admin
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
                MessageBox.Show("Error has occured. Contact IT department." +
                    "\nError occured when trying to change a employee's admin position.");
            }
            
        }

        //Function to view the transactions an employee has made
        private void View_Transactions(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            string id = control.Parent.Controls[0].Text;
            id_in_use = int.Parse(id);
            lblName.Text = control.Parent.Controls[1].Text;
            pnlReport.Visible = false;
            pnlAdd.Enabled = true;
            pnlTransactions.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlTransactions.Visible = false;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();
            //MessageBox.Show(dtpBeginDate.Value.Date.ToString());
            //MessageBox.Show(dtpEndDate.Value.Date.ToString());
            string qu = "SELECT * FROM `paris_pub`.`transaction` WHERE (`date_of_transac` BETWEEN '" + dtpBeginDate.Value.Date + "' AND '" + dtpEndDate.Value.Date + "' AND `employee_id` = '" + id_in_use + "');" ;
            db.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();
            int total = 0;
            while (reader.Read())
            {
                total += int.Parse(reader[2].ToString());
            }

            lblTotalSales.Text = "R " +  total.ToString();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            pnlReport.Visible = true;
            pnlAdd.Enabled = false;
        }

        private void btnBackReport_Click(object sender, EventArgs e)
        {
            pnlReport.Visible = false;
            pnlAdd.Enabled = true;
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();

            //string qu = "SELECT * FROM `paris_pub`.`transaction` WHERE (`date_of_transac` BETWEEN '" + dtpBeginDate.Value.Date + "' AND '" + dtpEndDate.Value.Date + "' AND `employee_id` = '" + id_in_use + "');";

            PdfWriter writer = new PdfWriter(@"C:\Users\Coffeebean\Documents\Project_Pdf\test.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("EMPLOYEES").SetTextAlignment(TextAlignment.CENTER).SetFontSize(20);
            document.Add(header);

            Paragraph subheader = new Paragraph(DateTime.Now.Date.ToString()).SetTextAlignment(TextAlignment.CENTER).SetFontSize(15);
            document.Add(subheader);

            LineSeparator ls = new LineSeparator(new SolidLine());
            document.Add(ls);

            string qu = "SELECT * FROM `paris_pub`.`employee`;";
            db.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(qu, db.Connection);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Paragraph id = new Paragraph("ID:\t" + reader[0].ToString());
                Paragraph name = new Paragraph("Name:\t" + reader[1].ToString());
                Paragraph surname = new Paragraph("Surname:\t" + reader[2].ToString());
                string gender;

                if (int.Parse(reader[3].ToString()) == 0)
                {
                    gender = "Female";
                }
                else
                {
                    gender = "Male";
                }

                Paragraph pGender = new Paragraph("Gender:\t" + gender);
                //Sales to sales needs adding

                document.Add(id);
                document.Add(name);
                document.Add(surname);
                document.Add(pGender);
                document.Add(ls);
            }


            document.Close();
        }
    }
}
