using System.Text;
using System.Security.Cryptography;
using System;

namespace api.Helpers
{
    public static class Password
    {
        public static string Hash(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static bool Compare(string inputPassword, string hashedPassword)
        {
            string hashOfInput = Password.Hash(inputPassword);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hashedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
