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
        private string filename;
        private int modeLSB = 1;
        private byte[] message;
        private string key;
        private int[][] dummybitmap;
        Bitmap tempbitmap;
        result myresultpict = new result();

        // METHODS
        public stegano_interface()
        {
            InitializeComponent();
            textBox2.Text = generateRandomSeed(8, 20, 30)[1].ToString();
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new stegano_interface());
        }

        // load result bitmap ke jendela baru
        private void loadResultBitmap()
        {
            myresultpict.setPicture(tempbitmap);
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
            openfile.Filter = "Bitmap Image|*.bmp";//JPeg Image|*.jpg|Gif Image|*.gif";
            openfile.ShowDialog();
            
            if (openfile.FileName != "")
            {
                namafile.Text = openfile.FileName;
                filename = openfile.SafeFileName; // menyimpan nama file
                sourcepict.Image = new Bitmap(namafile.Text);

                pesanfile.Enabled = true;

                tempbitmap = (Bitmap)sourcepict.Image;
            }
        }

        // prosedur untuk menentukan apakah penyisipan pesan dilakukan dengan enkripsi terlebih dahulu / tidak
        private void checkencript_MouseClick(object sender, MouseEventArgs e)
        {
            statusencript = !(statusencript);
        }

        // prosedur untuk menyimpan file hasil dekripsi
        private void saveas_Click(object sender, EventArgs e)
        {
            //
        }


        private int getRandomCoordinate()
        {
            // DARI LALA
            return modeLSB;
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
            byte A = source.A;
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
            int temp = shiftRightSomeBit(source, (byte)(8 - poss));
            if (LSB == 1)
                return ((byte)(temp & 1));
            else
                return ((byte)(temp & 3));
        }

        // prosedur untuk mengubah nilai 1 bit / 2 bit terakhir dengan nilai value
        private byte changeLast1or2Bit(byte source, byte values)
        {
            return (byte)(shiftRightSomeBit(shiftLeftSomeBit(source, (byte)modeLSB), (byte)modeLSB) + values);
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

        // prosedur untuk melakukan penyisipan pesan dari gambar bitmap yang dimasukkan
        private void btn_insert_Click(object sender, EventArgs e)
        {
            /*key = keyarea.Text;
            modeLSB = comboBox1.SelectedIndex;

            if ((filename != "") && (message != "") && (key != ""))
            {
                if (statusencript) // encript first
                    message = vigenere.decrypt(message, key);

                int seed = getSeed(key);
                byte messagebit;
                int coordinate;
                byte colorvalue;

                // generate INSERTION MESSAGE INTO BITMAP FILE
                for (int i = 0; i < message.Length; ++i)
                {
                    byte datasend = (byte)message[i];
                    if (modeLSB == 1)
                    {
                        for (int j = 1; j <= 8; ++j)
                        {
                            messagebit = getBitAtPoss(datasend, j, modeLSB);
                            coordinate = getRandomCoordinate();

                            // koordinat gambar (0,0) di kiri atas
                            int rest, coord, x, y;
                            coord = coordinate / 3;
                            rest = coordinate % 3; // R, G, or B
                            y = coord / 3;
                            x = (coord % 3) | (tempbitmap.Width);

                            if (rest == 1)
                                colorvalue = tempbitmap.GetPixel(x, y).R;
                            else
                            if (rest == 2)
                                colorvalue = tempbitmap.GetPixel(x, y).G;
                            else
                                colorvalue = tempbitmap.GetPixel(x, y).B;

                            colorvalue = changeLast1or2Bit(colorvalue, getBitAtPoss(datasend, j, 1));

                            Color dummy = changeAColorInAPixel(tempbitmap.GetPixel(x, y), colorvalue, (byte)rest);
                            tempbitmap.SetPixel(x, y, dummy);

                        }
                    } else
                    if (modeLSB == 2)
                    {
                        for (int j = 1; j <= 4; ++j)
                        {
                            messagebit = getBitAtPoss(datasend, 2*j-1, modeLSB);
                            coordinate = getRandomCoordinate();




                        }
                    }
                }
            }
            */
            // load result image into new window
            loadResultBitmap();
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
                byte[] isi = File.ReadAllBytes(filename);
                char[] namafile = openFile1.SafeFileName.ToCharArray();
                int ukuran = isi.Length;

                //buat message
                //format message namafile*ukuran(32 bit)isi
                
                message = new byte[ukuran + namafile.Length + 5];
                int i = 0;
                for (; i < namafile.Length; i++)
                {
                    message[i] = (byte)namafile[i];
                }
                message[i++] = (byte)'*';
                
                byte[] temp = BitConverter.GetBytes(ukuran);

                int j = i;
                for (; i < 4 + j; i++)
                {
                    message[i] = temp[i-j];
                }

                j = i;
                for (; i < j + isi.Length; i++)
                {
                    message[i] = isi[i-j];
                }
                if ((message.Length*8) > (sourcepict.Image.PhysicalDimension.Height * sourcepict.Image.PhysicalDimension.Width * 3))
                {
                    MessageBox.Show("ukuran file pesan terlalu besar");
                }
                else // ukuran memenuhi
                {
                    textBox1.Text = filename;

                    //INI BAGIAN UNTUK MENGAMBIL PESAN
                    i = 0;
                    char c = (char)message[i];
                    for (; c != '*'; i++)
                    {
                        MessageBox.Show(""+ (char)message[i]);
                        c = (char)message[i];
                    }
                    byte[] u = new byte[4];
                    u[0] = message[i++];
                    u[1] = message[i++];
                    u[2] = message[i++];
                    u[3] = message[i++];
                    MessageBox.Show(""+ BitConverter.ToInt32(u,0));
                }
            }

        }

        private void btn_extract_Click(object sender, EventArgs e)
        {

            saveas.Visible = true;
        }
    }
}
