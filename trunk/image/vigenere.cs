using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace image
{
    class vigenere
    {
        public static string encrypt(string plaintext, string key)
        {
            //mengenkripsi plaintext menggunakan vigenere cipher dengan kunci key

            char[] tmp = new char[plaintext.Length];
            char[] plainchar = plaintext.ToCharArray();
            char[] keychar = key.ToCharArray();

            for (int i = 0; i < plaintext.Length; i++)
            {
                tmp[i] = (char)(((int)plainchar[i] + (int)keychar[i % key.Length]) % 256);
            }
            return new string(tmp);
        }


        public static string decrypt(string ciphertext, string key)
        {
            //mendekripsi ciphertext vigenere cipher dengan kunci key

            char[] tmp = new char[ciphertext.Length];
            char[] cipherchar = ciphertext.ToCharArray();
            char[] keychar = key.ToCharArray();

            for (int i = 0; i < ciphertext.Length; i++)
            {
                int x = ((int)cipherchar[i] - (int)keychar[i % key.Length]);
                if (x < 0) x += 256;
                tmp[i] = (char)(x % 256);
            }
            return new string(tmp);
        }
    }
}
