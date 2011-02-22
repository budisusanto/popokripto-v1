﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace image
{
    public partial class result : Form
    {
        private Bitmap myimage;

        public result()
        {
            InitializeComponent();
        }

        public void setPicture(Bitmap pict)
        {
            pictureBox1.BackgroundImage = pict;
            myimage = pict;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Bitmap Image|*.bmp|JPeg Image|*.jpg|Gif Image|*.gif";
            saveFileDialog1.Title = "Simpan hasil";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                // Saves the Image in the appropriate ImageFormat based upon the File type selected in the dialog box.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        myimage.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        myimage.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                        myimage.Save(fs,
                        System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }

                fs.Close();
            }
        }
    }
}
