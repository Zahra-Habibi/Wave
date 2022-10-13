using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.PulicClasses
{
    public static class Md5
    {
        public static string EncodePasswordMd5(this string Password)
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(Password);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }

    }
}
