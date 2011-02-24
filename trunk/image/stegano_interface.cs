using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace image
{
    public partial class stegano_interface : Form
    {
        // ATRIBUT
        private bool statusencript = false;
        private int modeLSB = 1;
        private byte[] message;
        private byte[] mypicture;
        private string key;
        Bitmap tempbitmap;
        result myresultpict = new result();
        private string filename;
        private byte[] resultmessage;
        private int filesize;

        // METHODS
        public stegano_interface()
        {
            InitializeComponent();
            //textBox2.Text = generateRandomSeed(8, 20, 30)[1].ToString();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new stegano_interface());
        }

        // load result bitmap ke jendela baru
        private void loadResultBitmap()
        {
            myresultpict.setPicture(tempbitmap, mypicture);
            double psnrval = hitung.PSNR(hitung.rms((Bitmap)sourcepict.Image, tempbitmap));
            myresultpict.PSNR.Text = psnrval.ToString();
            if (psnrval > 30)
                myresultpict.psnr_kategori.Text = "kualitas citra bagus";
            else
                myresultpict.psnr_kategori.Text = "citra terdegradasi signifikan";
                myresultpict.Show();
        }

        //prosedur yang dijalankan saat tombol pencarian file di tekan
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            openfile.Title = "Cari gambar sumber";
            openfile.Filter = "Bitmap Image|*.bmp";
            openfile.ShowDialog();
            
            if (openfile.FileName != "")
            {
                namafile.Text = openfile.FileName;
                mypicture = File.ReadAllBytes(openfile.FileName);

                pesanfile.Enabled = true;

                sourcepict.Image = new Bitmap(namafile.Text);
                tempbitmap = (Bitmap)sourcepict.Image;
            }
        }

        // prosedur untuk menentukan apakah penyisipan pesan dilakukan dengan enkripsi terlebih dahulu / tidak
        private void checkencript_MouseClick(object sender, MouseEventArgs e)
        {
            statusencript = !(statusencript);
        }

        // generate random from seed
        private ArrayList generateRandomSeed(int length, int seed, int maxsize)
        {
            ArrayList myarray = new ArrayList();

            Random rdm = new Random(seed);
            for (int i = 0; i < length; ++i)
            {
                myarray.Add(rdm.Next(maxsize));
            }

            return myarray;
        }

        // prosedur untuk mengganti elemen warna pada pixel[x,y] pada warna ke -color, dengan nilai value
        private Color changeAColorInAPixel(Color source, int color, byte value)
        {
            byte R = source.R;
            byte G = source.G;
            byte B = source.B;

            if (color == 1) // if RED
            {
                R = value;
            } else
            if (color == 2) // if GREEN
            {
                G = value;
            } else // if BLUE
            {
                B = value;
            }
            source = Color.FromArgb(R, G, B);
            return source;
        }

        // mencari nilai seed dari string kunci
        // ambil bagian genapnya aja
        private int getSeed(string key)
        {
            int len = key.Length;
            int i = 0;
            int retval = 0;

            while (i < len)
            {
                if (i % 2 == 0)
                {
                    retval += key[i];
                }
                ++i;
            }
            return retval;
        }

        //mengambil nilai bit pada posisi tertentu pada variabel sumber
        private byte getBitAtPoss(byte source, int poss, int LSB) {
            // shift bit source
            int temp = shiftRightSomeBit(source, (byte)(9 - poss - LSB));
            if (LSB == 1)
                return ((byte)(temp & 1));
            else
                return ((byte)(temp & 3));
        }

        // prosedur untuk mengubah nilai 1 bit / 2 bit terakhir dengan nilai value
        private byte changeLast1or2Bit(byte source, byte values)
        {
            return (byte)(shiftLeftSomeBit(shiftRightSomeBit(source, (byte)modeLSB), (byte)modeLSB) | values);
        }

        // prosedur untuk menggeser ke kiri nilai bit suatu bilangan
        private int shiftLeftSomeBit(int value, byte shifting)
        {
            return (value << shifting);
        }

        // prosedur untuk menggeser ke kanan nilai bit suatu bilangan
        private int shiftRightSomeBit(int value, byte shifting)
        {
            return (value >> shifting);
        }

        private void insertbyPicture()
        {
            key = keyarea.Text;
            modeLSB = comboBox1.SelectedIndex + 1;
            int containersize = tempbitmap.Width * tempbitmap.Height * 3;

            if ((namafile.Text != "") && (textBox1.Text != "") && (key != "") && (comboBox1.Text != ""))
            {
                if (containersize < message.Length * 8)
                {
                    MessageBox.Show("Ukuran file yang akan disisipkan terlalu besar");
                }
                else
                {
                    if (statusencript) // encript first
                        message = vigenere.encrypt(message, key);


                    //memasukkan header
                    //format message namafile*ukuran(4byte)isi
                    byte[] newmessage = new byte[filename.Length + 5 + filesize];
                    char[] nama =filename.ToCharArray();

                    int i,j;
                    for (i=0; i < nama.Length; i++)
                    {
                        newmessage[i] = (byte)nama[i];
                    }
                    newmessage[i++] = (byte)'*';

                    newmessage[i++] = (byte)(filesize >> 24);
                    newmessage[i++] = (byte)(filesize >> 16);
                    newmessage[i++] = (byte)(filesize >> 8);
                    newmessage[i++] = (byte)(filesize);

                    //MessageBox.Show("" + newmessage[i - 4] + " " + newmessage[i - 3] + " " + newmessage[i - 2] + " " + newmessage[i - 1] + " ");

                    for (j = i; i < j + message.Length; i++)
                    {
                        newmessage[i] = message[i - j];
                    }

                    message = newmessage;

                    int seed = getSeed(key);
                    Random rdm = new Random(seed);

                    byte messagebit = 1;
                    int coordinate;
                    byte colorvalue;

                    // generate INSERTION MESSAGE INTO BITMAP FILE
                    for (i = 0; i < message.Length; ++i)
                    {
                        byte datasend = message[i];
                        if (modeLSB == 1)
                        {
                            for (j = 1; j <= 8; ++j)
                            {
                                messagebit = getBitAtPoss(datasend, j, modeLSB);
                                // koordinat gambar (0,0) di kiri atas

                                coordinate = rdm.Next(1,containersize);
                                
                                int colorplace, coord, x, y;
                                coord = coordinate / 3;
                                colorplace = coordinate % 3; // R, G, or B
                                if (colorplace == 0)
                                {
                                    colorplace = 3;
                                    coord -= 1;
                                }
                                y = coord / tempbitmap.Width;
                                x = coord % tempbitmap.Width;

                                if (colorplace == 1)
                                    colorvalue = tempbitmap.GetPixel(x, y).R;
                                else
                                {
                                    if (colorplace == 2)
                                        colorvalue = tempbitmap.GetPixel(x, y).G;
                                    else
                                        colorvalue = tempbitmap.GetPixel(x, y).B;
                                }

                                Console.WriteLine("random: " + coordinate +"(x,y):" + x + ","+ y + " bit:" + messagebit);
                                colorvalue = changeLast1or2Bit(colorvalue, messagebit);
                                tempbitmap.SetPixel(x, y, changeAColorInAPixel(tempbitmap.GetPixel(x, y), colorplace, colorvalue));
                            }
                            Console.WriteLine();
                        }
                        else
                            if (modeLSB == 2)
                            {
                                for (j = 1; j <= 4; ++j)
                                {
                                    messagebit = getBitAtPoss(datasend, 2 * j - 1, modeLSB);
                                    coordinate = rdm.Next(1,containersize);
                                    //Console.WriteLine(coordinate);
                                    int colorplace, coord, x, y;
                                    coord = coordinate / 3;
                                    colorplace = coordinate % 3; // R, G, or B
                                    if (colorplace == 0)
                                    {
                                        colorplace = 3;
                                        coord -= 1;
                                    }
                                    y = coord / tempbitmap.Width;
                                    x = coord % tempbitmap.Width;

                                    if (colorplace == 1)
                                        colorvalue = tempbitmap.GetPixel(x, y).R;
                                    else
                                        if (colorplace == 2)
                                            colorvalue = tempbitmap.GetPixel(x, y).G;
                                        else
                                            colorvalue = tempbitmap.GetPixel(x, y).B;

                                    Console.WriteLine("random: " + coordinate + "(x,y):" + x + "," + y + " bit:" + messagebit);
                        
                                    colorvalue = changeLast1or2Bit(colorvalue, messagebit);
                                    tempbitmap.SetPixel(x, y, changeAColorInAPixel(tempbitmap.GetPixel(x, y), colorplace, colorvalue));
                                }
                            }
                    }

                    // load result image into new window
                    loadResultBitmap();
                }
            }
            else
            {
                MessageBox.Show("isian belum lengkap");
            }
        }

        // prosedur untuk melakukan penyisipan pesan dari gambar bitmap yang dimasukkan
        private void btn_insert_Click(object sender, EventArgs e)
        {
            insertbyPicture();
        }

        // prosedur yang dijalankan ketika tombol cari pada bagian isi pesan ditekan.
        // file name yang diklik akan dicek besarnya dan dibandingkan besar kontainer image yang tersedia.
        private void pesanfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile1 = new OpenFileDialog();
            
            openFile1.Title = "Cari nama file pesan";
            openFile1.ShowDialog();

            if (openFile1.FileName != "")
            {
                filename = openFile1.SafeFileName;
                message = File.ReadAllBytes(openFile1.FileName);
                filesize = message.Length;

                for (int i = 0; i < filesize; i++)
                {
                    //Console.WriteLine("pesan");
                    //Console.Write((char)message[i]);
                }

                    if (((message.Length + openFile1.SafeFileName.Length + 5) * 8) > (sourcepict.Image.PhysicalDimension.Height * sourcepict.Image.PhysicalDimension.Width * 3))
                    {
                        MessageBox.Show("ukuran file pesan terlalu besar");
                    }
                    else // ukuran memenuhi
                    {
                        textBox1.Text = openFile1.SafeFileName;
                    }
            }

        }

        // prosedur untuk mengekstrak pesan
        private void btn_extract_Click(object sender, EventArgs e)
        {
            key = keyarea.Text;
            if ((namafile.Text != "") && (key != ""))
            {
                modeLSB = comboBox1.SelectedIndex + 1;
                int containersize = tempbitmap.Width * tempbitmap.Height * 3;

                int seed = getSeed(key);
                Random rdm = new Random(seed);

                byte messagebit = 1;
                int coordinate;
                byte colorvalue;

                bool checkfilename = false;
                byte datahide = 0;

                filename = "";
                ///nama pesan
                int filesize = 0;


                // INI BAGIAN BACA NAMA FILE NYA
                while (datahide!= 42)
                {
                    //coordinate = rdm.Next(1,containersize);
                    //Console.WriteLine(coordinate);

                    for (int j = 1; j <= (8/modeLSB); ++j) // iterasi buat 1 atau 2 LSB
                    {
                        coordinate = rdm.Next(1,containersize);
                        //Console.WriteLine(coordinate);
                        int colorplace, coord, x, y;
                        coord = coordinate / 3;
                        colorplace = coordinate % 3; // R, G, or B
                        if (colorplace == 0)
                        {
                            colorplace = 3;
                            coord -= 1;
                        }
                        y = coord / tempbitmap.Width;
                        x = coord % tempbitmap.Width;

                        if (colorplace == 1)
                            colorvalue = tempbitmap.GetPixel(x, y).R;
                        else
                            if (colorplace == 2)
                                colorvalue = tempbitmap.GetPixel(x, y).G;
                            else
                                colorvalue = tempbitmap.GetPixel(x, y).B;

                        messagebit = getBitAtPoss(colorvalue, 9 - modeLSB, modeLSB);

                        datahide = (byte)shiftLeftSomeBit(datahide, (byte)modeLSB);
                        datahide += messagebit;
                        Console.WriteLine("random: " + coordinate + "(x,y):" + x + "," + y + " bit:" + messagebit);
                                
                    }
                    filename += datahide;
                    Console.WriteLine();
                    MessageBox.Show(""+(char)datahide + datahide);
                }

                // ABIS INI BACA FILE SIZE NYA 4 BYTE
                for (int j = 1; j < 4; ++j)
                {
                    //coordinate = rdm.Next(1,containersize);
                    //Console.WriteLine(coordinate);
                    for (int k = 1; k <= (8/modeLSB); ++k)
                    {
                        coordinate = rdm.Next(1,containersize);
                        //Console.WriteLine(coordinate);
                        int colorplace, coord, x, y;
                        coord = coordinate / 3;
                        colorplace = coordinate % 3; // R, G, or B
                        if (colorplace == 0)
                        {
                            colorplace = 3;
                            coord -= 1;
                        }
                        y = coord / tempbitmap.Width;
                        x = coord % tempbitmap.Width;

                        if (colorplace == 1)
                            colorvalue = tempbitmap.GetPixel(x, y).R;
                        else
                            if (colorplace == 2)
                                colorvalue = tempbitmap.GetPixel(x, y).G;
                            else
                                colorvalue = tempbitmap.GetPixel(x, y).B;

                        messagebit = getBitAtPoss(colorvalue, 9 - modeLSB, modeLSB);

                        datahide = (byte)shiftLeftSomeBit(datahide, (byte)modeLSB);
                        datahide += messagebit;
                        Console.WriteLine("random: " + coordinate + "(x,y):" + x + "," + y + " bit:" + messagebit);
                        
                    }
                    filesize = shiftLeftSomeBit(filesize, 8);
                    filesize += datahide;
                    datahide = 0;
                    Console.WriteLine();
                }
                MessageBox.Show("filesize = "+filesize);

                // BAGIAN BACA DATAN
                // generate INSERTION MESSAGE INTO BITMAP FILE
                resultmessage = new byte[filesize];

                for (int i = 0; i < filesize; ++i)
                {
                    datahide = 0;
                        for (int j = 1; j <= (8/modeLSB); ++j)
                        {
                            coordinate = rdm.Next(1,containersize);
                            //Console.WriteLine(coordinate);
                            int colorplace, coord, x, y;
                            coord = coordinate / 3;
                            colorplace = coordinate % 3; // R, G, or B
                            if (colorplace == 0)
                            {
                                colorplace = 3;
                                coord -= 1;
                            }
                            y = coord / tempbitmap.Width;
                            x = coord % tempbitmap.Width;

                            if (colorplace == 1)
                                colorvalue = tempbitmap.GetPixel(x, y).R;
                            else
                            if (colorplace == 2)
                                colorvalue = tempbitmap.GetPixel(x, y).G;
                            else
                                colorvalue = tempbitmap.GetPixel(x, y).B;

                            messagebit = getBitAtPoss(colorvalue, 9 - modeLSB, modeLSB);
                            datahide = (byte)shiftLeftSomeBit(datahide, (byte)modeLSB);
                            datahide += messagebit;
                            Console.WriteLine("random: " + coordinate + "(x,y):" + x + "," + y + " bit:" + messagebit);
                        
                        }
                        resultmessage[i] = datahide;
                        Console.WriteLine();
                        MessageBox.Show("" + (char)datahide);
                }
            }
            MessageBox.Show("Pesan berhasil diekstrak");
            saveas.Visible = true;
        }

        private void saveas_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            saveFileDialog1.Title = "Simpan hasil"; 
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                File.WriteAllBytes(saveFileDialog1.FileName, resultmessage);
            }
        }
    }
}
