using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ValidationTester.Commons.Utils
{
    public class CryptoUtils
    {
        private static string HashMD5(byte[] bytes)
        {
            MD5CryptoServiceProvider cryptHandler = new MD5CryptoServiceProvider();
            byte[] hash = cryptHandler.ComputeHash(bytes);
            string ret = "";
            foreach (byte a in hash)
            {
                if (a < 16)
                    ret += "0" + a.ToString("x");
                else
                    ret += a.ToString("x");
            }
            return ret;
        }

        private static string HashSHA256(byte[] bytes)
        {
            HashAlgorithm hasher = SHA256.Create();
            byte[] hash = hasher.ComputeHash(bytes);
            StringBuilder sb = new StringBuilder(hash.Length);
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X"));

            hasher.Clear();
            return sb.ToString();
        }


        /// <summary>
        /// Recebe uma string de entrada e gera o hash MD5 dela.
        /// </summary>
        /// <param name="value">String a ser validada.</param>
        /// <returns>Retorna uma string contendo o hash MD5 da string de entrada.</returns>
        public static string HashMD5(string value)
        {
            byte[] bytes = Encoding.Default.GetBytes(value);
            return HashMD5(bytes);
        }

        /// <summary>
        /// Recebe uma string de entrada e gera o hash MD5 dela.
        /// </summary>
        /// <param name="filePath">String a ser validada.</param>
        /// <returns>Retorna uma string contendo o hash MD5 da string de entrada.</returns>
        public static string HashFileMD5(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return HashMD5(bytes);
        }

        public static string HashSHA256(string value)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return HashSHA256(bytes);
        }

        public static string HashFileSHA256(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            return HashSHA256(bytes);
        }
    }
}
