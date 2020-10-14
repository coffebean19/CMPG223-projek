namespace cmpg223_final_project
{
    partial class frmEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpDates = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.btnCalc = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.pnlReport = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSaveReport = new System.Windows.Forms.Button();
            this.btnBackReport = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlAdd.SuspendLayout();
            this.grpDates.SuspendLayout();
            this.pnlTransactions.SuspendLayout();
            this.pnlReport.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(3, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlAdd
            // 
            this.pnlAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pnlAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdd.Controls.Add(this.txbPassword);
            this.pnlAdd.Controls.Add(this.label5);
            this.pnlAdd.Controls.Add(this.dtpBirthday);
            this.pnlAdd.Controls.Add(this.label4);
            this.pnlAdd.Controls.Add(this.cmbGender);
            this.pnlAdd.Controls.Add(this.label3);
            this.pnlAdd.Controls.Add(this.txbSurname);
            this.pnlAdd.Controls.Add(this.label2);
            this.pnlAdd.Controls.Add(this.txbName);
            this.pnlAdd.Controls.Add(this.btnAdd);
            this.pnlAdd.Controls.Add(this.label1);
            this.pnlAdd.Location = new System.Drawing.Point(5, 614);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(1201, 34);
            this.pnlAdd.TabIndex = 1;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(1059, 6);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(124, 20);
            this.txbPassword.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(997, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password:";
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(782, 7);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(200, 20);
            this.dtpBirthday.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(707, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date of Birth:";
            // 
            // cmbGender
            // 
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(572, 6);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(121, 21);
            this.cmbGender.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(521, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Gender:";
            // 
            // txbSurname
            // 
            this.txbSurname.Location = new System.Drawing.Point(367, 6);
            this.txbSurname.Name = "txbSurname";
            this.txbSurname.Size = new System.Drawing.Size(138, 20);
            this.txbSurname.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname:";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(155, 6);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(138, 20);
            this.txbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(1333, 618);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(75, 23);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(14, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label7";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBack.Location = new System.Drawing.Point(7, 429);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpDates
            // 
            this.grpDates.Controls.Add(this.dtpEndDate);
            this.grpDates.Controls.Add(this.lblTotalSales);
            this.grpDates.Controls.Add(this.btnCalc);
            this.grpDates.Controls.Add(this.lblTotal);
            this.grpDates.Controls.Add(this.label6);
            this.grpDates.Controls.Add(this.dtpBeginDate);
            this.grpDates.Controls.Add(this.label7);
            this.grpDates.Location = new System.Drawing.Point(7, 83);
            this.grpDates.Name = "grpDates";
            this.grpDates.Size = new System.Drawing.Size(524, 372);
            this.grpDates.TabIndex = 9;
            this.grpDates.TabStop = false;
            this.grpDates.Text = "Transaction Date Selection";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(98, 82);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 4;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSales.Location = new System.Drawing.Point(343, 263);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(0, 17);
            this.lblTotalSales.TabIndex = 7;
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(32, 257);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 23);
            this.btnCalc.TabIndex = 8;
            this.btnCalc.Text = "Calculate";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(251, 263);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(44, 17);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Begin Date:";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.Location = new System.Drawing.Point(98, 40);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBeginDate.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "End Date:";
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransactions.AutoSize = true;
            this.pnlTransactions.Controls.Add(this.grpDates);
            this.pnlTransactions.Controls.Add(this.btnBack);
            this.pnlTransactions.Controls.Add(this.lblName);
            this.pnlTransactions.Location = new System.Drawing.Point(5, 6);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Size = new System.Drawing.Size(997, 458);
            this.pnlTransactions.TabIndex = 3;
            this.pnlTransactions.Visible = false;
            // 
            // pnlReport
            // 
            this.pnlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReport.Controls.Add(this.groupBox1);
            this.pnlReport.Controls.Add(this.btnBackReport);
            this.pnlReport.Location = new System.Drawing.Point(1185, 411);
            this.pnlReport.Name = "pnlReport";
            this.pnlReport.Size = new System.Drawing.Size(227, 237);
            this.pnlReport.TabIndex = 10;
            this.pnlReport.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(9, 32);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(9, 94);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Start Date:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "End Date:";
            // 
            // btnSaveReport
            // 
            this.btnSaveReport.Location = new System.Drawing.Point(9, 135);
            this.btnSaveReport.Name = "btnSaveReport";
            this.btnSaveReport.Size = new System.Drawing.Size(135, 23);
            this.btnSaveReport.TabIndex = 4;
            this.btnSaveReport.Text = "Create Report";
            this.btnSaveReport.UseVisualStyleBackColor = true;
            this.btnSaveReport.Click += new System.EventHandler(this.btnSaveReport_Click);
            // 
            // btnBackReport
            // 
            this.btnBackReport.Location = new System.Drawing.Point(9, 205);
            this.btnBackReport.Name = "btnBackReport";
            this.btnBackReport.Size = new System.Drawing.Size(75, 23);
            this.btnBackReport.TabIndex = 5;
            this.btnBackReport.Text = "Back";
            this.btnBackReport.UseVisualStyleBackColor = true;
            this.btnBackReport.Click += new System.EventHandler(this.btnBackReport_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnSaveReport);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 164);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Timeline";
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1420, 649);
            this.Controls.Add(this.pnlReport);
            this.Controls.Add(this.pnlTransactions);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.pnlAdd);
            this.MinimumSize = new System.Drawing.Size(1436, 688);
            this.Name = "frmEmployee";
            this.Text = "Employees";
            this.Load += new System.EventHandler(this.frmEmployee_Load);
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.grpDates.ResumeLayout(false);
            this.grpDates.PerformLayout();
            this.pnlTransactions.ResumeLayout(false);
            this.pnlTransactions.PerformLayout();
            this.pnlReport.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grpDates;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpBeginDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.Panel pnlReport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSaveReport;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button btnBackReport;
    }
}