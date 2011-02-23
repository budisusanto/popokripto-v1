using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace image
{
    class vigenere
    {
        public static byte[] encrypt(byte[] plaintext, string key)
        {
            //mengenkripsi plaintext menggunakan vigenere cipher dengan kunci key

            byte[] tmp = new byte[plaintext.Length];
            char[] keychar = key.ToCharArray();

            for (int i = 0; i < plaintext.Length; i++)
            {
                tmp[i] = (byte)((plaintext[i] + (byte)keychar[i % key.Length]) % 256);
            }
            return tmp;
        }


        public static byte[] decrypt(byte[] ciphertext, string key)
        {
            //mendekripsi ciphertext vigenere cipher dengan kunci key

            byte[] tmp = new byte[ciphertext.Length];
            char[] keychar = key.ToCharArray();

            for (int i = 0; i < ciphertext.Length; i++)
            {
                int x = ((int)ciphertext[i] - (int)keychar[i % key.Length]);
                if (x < 0) x += 256;
                tmp[i] = (byte)(x % 256);
            }
            return tmp;
        }
    }
}
