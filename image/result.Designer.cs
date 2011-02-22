namespace image
{
    partial class result
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
            this.pictureBox1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.psnr_kategori = new System.Windows.Forms.Label();
            this.PSNR = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.AutoScroll = true;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(531, 482);
            this.pictureBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 504);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kategori :";
            // 
            // psnr_kategori
            // 
            this.psnr_kategori.AutoSize = true;
            this.psnr_kategori.Location = new System.Drawing.Point(321, 504);
            this.psnr_kategori.Name = "psnr_kategori";
            this.psnr_kategori.Size = new System.Drawing.Size(0, 13);
            this.psnr_kategori.TabIndex = 5;
            // 
            // PSNR
            // 
            this.PSNR.AutoSize = true;
            this.PSNR.Location = new System.Drawing.Point(64, 504);
            this.PSNR.Name = "PSNR";
            this.PSNR.Size = new System.Drawing.Size(0, 13);
            this.PSNR.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PSNR : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 539);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Simpan Hasil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(555, 574);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PSNR);
            this.Controls.Add(this.psnr_kategori);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "result";
            this.Text = "result";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label PSNR;
        public System.Windows.Forms.Label psnr_kategori;
        private System.Windows.Forms.Button button1;

    }
}