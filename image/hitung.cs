using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace image
{
    class hitung
    {
        public static double PSNR(double rms)
        {
            return (20 * Math.Log10(256 / rms));
        }

        public static double rms(Bitmap i1, Bitmap i2)
        {
            int i, j;
            int jml = 0;
            double hasil;
            int m, n;

            m = i1.Width;
            n = i1.Height;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    jml += (int)Math.Pow(i1.GetPixel(j, i).R - i1.GetPixel(j, i).R, 2);
                    jml += (int)Math.Pow(i1.GetPixel(j, i).G - i1.GetPixel(j, i).G, 2);
                    jml += (int)Math.Pow(i1.GetPixel(j, i).B - i1.GetPixel(j, i).B, 2);
                }
            }

            hasil = (double) Math.Sqrt((double)jml / (double)(m * n));
            return hasil;
        }
    }
}
