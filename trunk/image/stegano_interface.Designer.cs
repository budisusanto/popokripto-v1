namespace image
{
    partial class stegano_interface
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pesanfile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.saveas = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkencript = new System.Windows.Forms.CheckBox();
            this.btn_extract = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.keyarea = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.namafile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sourcepict = new System.Windows.Forms.PictureBox();
            this.openfile = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFile1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcepict)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.pesanfile);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.saveas);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.checkencript);
            this.panel1.Controls.Add(this.btn_extract);
            this.panel1.Controls.Add(this.btn_insert);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.keyarea);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.namafile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(854, 193);
            this.panel1.TabIndex = 0;
            // 
            // pesanfile
            // 
            this.pesanfile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pesanfile.Enabled = false;
            this.pesanfile.Location = new System.Drawing.Point(767, 29);
            this.pesanfile.Name = "pesanfile";
            this.pesanfile.Size = new System.Drawing.Size(75, 23);
            this.pesanfile.TabIndex = 12;
            this.pesanfile.Text = "cari";
            this.pesanfile.UseVisualStyleBackColor = false;
            this.pesanfile.Click += new System.EventHandler(this.pesanfile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(436, 31);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(325, 20);
            this.textBox1.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(16, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Pilih bit LSB";
            // 
            // saveas
            // 
            this.saveas.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.saveas.Location = new System.Drawing.Point(537, 109);
            this.saveas.Name = "saveas";
            this.saveas.Size = new System.Drawing.Size(108, 27);
            this.saveas.TabIndex = 5;
            this.saveas.Text = "Simpan File Sisipan";
            this.saveas.UseVisualStyleBackColor = false;
            this.saveas.Visible = false;
            this.saveas.Click += new System.EventHandler(this.saveas_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 bit",
            "2 bit"});
            this.comboBox1.Location = new System.Drawing.Point(19, 158);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(107, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // checkencript
            // 
            this.checkencript.AutoSize = true;
            this.checkencript.ForeColor = System.Drawing.Color.White;
            this.checkencript.Location = new System.Drawing.Point(19, 65);
            this.checkencript.Name = "checkencript";
            this.checkencript.Size = new System.Drawing.Size(96, 17);
            this.checkencript.TabIndex = 8;
            this.checkencript.Text = "Enkripsi Pesan";
            this.checkencript.UseVisualStyleBackColor = true;
            this.checkencript.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkencript_MouseClick);
            // 
            // btn_extract
            // 
            this.btn_extract.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_extract.Location = new System.Drawing.Point(436, 109);
            this.btn_extract.Name = "btn_extract";
            this.btn_extract.Size = new System.Drawing.Size(86, 27);
            this.btn_extract.TabIndex = 3;
            this.btn_extract.Text = "Ekstrak";
            this.btn_extract.UseVisualStyleBackColor = false;
            this.btn_extract.Click += new System.EventHandler(this.btn_extract_Click);
            // 
            // btn_insert
            // 
            this.btn_insert.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_insert.Location = new System.Drawing.Point(436, 59);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(86, 27);
            this.btn_insert.TabIndex = 4;
            this.btn_insert.Text = "Sisipkan";
            this.btn_insert.UseVisualStyleBackColor = false;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(435, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Masukkan Pesan dari File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Masukkan kunci";
            // 
            // keyarea
            // 
            this.keyarea.Location = new System.Drawing.Point(19, 109);
            this.keyarea.MaxLength = 25;
            this.keyarea.Name = "keyarea";
            this.keyarea.Size = new System.Drawing.Size(381, 20);
            this.keyarea.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(325, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "cari";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // namafile
            // 
            this.namafile.Enabled = false;
            this.namafile.Location = new System.Drawing.Point(19, 28);
            this.namafile.Name = "namafile";
            this.namafile.Size = new System.Drawing.Size(298, 20);
            this.namafile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masukkan File Gambar";
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Controls.Add(this.sourcepict);
            this.panel2.Location = new System.Drawing.Point(12, 222);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(854, 405);
            this.panel2.TabIndex = 1;
            // 
            // sourcepict
            // 
            this.sourcepict.Location = new System.Drawing.Point(3, 3);
            this.sourcepict.Name = "sourcepict";
            this.sourcepict.Size = new System.Drawing.Size(830, 377);
            this.sourcepict.TabIndex = 0;
            this.sourcepict.TabStop = false;
            // 
            // openfile
            // 
            this.openfile.CheckFileExists = false;
            // 
            // openFile1
            // 
            this.openFile1.CheckFileExists = false;
            // 
            // stegano_interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(878, 639);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "stegano_interface";
            this.Text = "stegano_interface";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcepict)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox namafile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox sourcepict;
        private System.Windows.Forms.OpenFileDialog openfile;
        private System.Windows.Forms.CheckBox checkencript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox keyarea;
        private System.Windows.Forms.Button btn_extract;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button saveas;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button pesanfile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.OpenFileDialog openFile1;
    }
}