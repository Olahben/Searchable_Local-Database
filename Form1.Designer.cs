    namespace Søkbar_Database3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable. test
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUtøver = new Label();
            btnTeam = new Label();
            btnBil = new Label();
            btnAlder = new Label();
            btnStartnr = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(135, 275); // Set the location
            pictureBox1.Size = new Size(100, 100); // Set the size
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Set the size mode
            Controls.Add(pictureBox1); // Add the PictureBox to the form's controls
            btnAdd = new Button();
            btnDel = new Button();
            btnUpdate = new Button();
            textBox6 = new TextBox();
            btnSearch = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnUtøver
            // 
            btnUtøver.AutoSize = true;
            btnUtøver.Font = new Font("Microsoft Sans Serif", 12F);
            btnUtøver.Location = new Point(43, 39);
            btnUtøver.Margin = new Padding(4, 0, 4, 0);
            btnUtøver.Name = "btnUtøver";
            btnUtøver.Size = new Size(56, 20);
            btnUtøver.TabIndex = 0;
            btnUtøver.Text = "Utøver";
            // 
            // btnTeam
            // 
            btnTeam.AutoSize = true;
            btnTeam.Font = new Font("Microsoft Sans Serif", 12F);
            btnTeam.Location = new Point(43, 90);
            btnTeam.Margin = new Padding(4, 0, 4, 0);
            btnTeam.Name = "btnTeam";
            btnTeam.Size = new Size(49, 20);
            btnTeam.TabIndex = 1;
            btnTeam.Text = "Team";
            // 
            // btnBil
            // 
            btnBil.AutoSize = true;
            btnBil.Font = new Font("Microsoft Sans Serif", 12F);
            btnBil.Location = new Point(46, 228);
            btnBil.Margin = new Padding(4, 0, 4, 0);
            btnBil.Name = "btnBil";
            btnBil.Size = new Size(26, 20);
            btnBil.TabIndex = 2;
            btnBil.Text = "Bil";
            // 
            // btnAlder
            // 
            btnAlder.AutoSize = true;
            btnAlder.Font = new Font("Microsoft Sans Serif", 12F);
            btnAlder.Location = new Point(46, 135);
            btnAlder.Margin = new Padding(4, 0, 4, 0);
            btnAlder.Name = "btnAlder";
            btnAlder.Size = new Size(46, 20);
            btnAlder.TabIndex = 3;
            btnAlder.Text = "Alder";
            // 
            // btnStartnr
            // 
            btnStartnr.AutoSize = true;
            btnStartnr.Font = new Font("Microsoft Sans Serif", 12F);
            btnStartnr.Location = new Point(25, 181);
            btnStartnr.Margin = new Padding(4, 0, 4, 0);
            btnStartnr.Name = "btnStartnr";
            btnStartnr.Size = new Size(102, 20);
            btnStartnr.TabIndex = 4;
            btnStartnr.Text = "Startnummer";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 33);
            textBox1.Margin = new Padding(4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(506, 26);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 88);
            textBox2.Margin = new Padding(4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(506, 26);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(135, 135);
            textBox3.Margin = new Padding(4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(506, 26);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(135, 178);
            textBox4.Margin = new Padding(4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(506, 26);
            textBox4.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(135, 228);
            textBox5.Margin = new Padding(4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(506, 26);
            textBox5.TabIndex = 9;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(647, 329);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(103, 51);
            btnAdd.TabIndex = 10;
            btnAdd.Text = "Legg til data";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // btnDel
            // 
            btnDel.Location = new Point(647, 443);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(103, 51);
            btnDel.TabIndex = 11;
            btnDel.Text = "Fjern data";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(647, 386);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(103, 51);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "Oppdater data";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(375, 297);
            textBox6.Margin = new Padding(4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(265, 26);
            textBox6.TabIndex = 13;
            textBox6.TextChanged += textBox6_TextChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(647, 297);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 26);
            btnSearch.TabIndex = 14;
            btnSearch.Text = "Søk";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1, 329);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(640, 321);
            dataGridView1.TabIndex = 15;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 647);
            Controls.Add(dataGridView1);
            Controls.Add(btnSearch);
            Controls.Add(textBox6);
            Controls.Add(btnUpdate);
            Controls.Add(btnDel);
            Controls.Add(btnAdd);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnStartnr);
            Controls.Add(btnAlder);
            Controls.Add(btnBil);
            Controls.Add(btnTeam);
            Controls.Add(btnUtøver);
            Font = new Font("Microsoft Sans Serif", 12F);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Superkul f1 database";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label btnUtøver;
        private Label btnTeam;
        private Label btnBil;
        private Label btnAlder;
        private Label btnStartnr;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnDel;
        private Button btnUpdate;
        private TextBox textBox6;
        private Button btnSearch;
        private DataGridView dataGridView1;
    }
}
