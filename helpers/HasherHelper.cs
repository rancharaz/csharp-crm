using System;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace jpddoocp.helpers
{
    class HasherHelper
    {
        public static string Hash(string text)
        {
            string salt = ConfigurationManager.AppSettings["salt"];
            string saltedText = String.Concat(text, salt);
            byte[] arrbyte = new byte[saltedText.Length];
            SHA256 hash = new SHA256CryptoServiceProvider();
            arrbyte = hash.ComputeHash(Encoding.UTF8.GetBytes(saltedText));
            return Convert.ToBase64String(arrbyte);
        }
    }
}
