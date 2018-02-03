using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace YRD.SO.Common
{
    public class DesCryption
    {
        private static readonly byte[] _keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        //加密
        public static string Encrypt(string encryptString, string sKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
            var keyIv = _keys;
            var inputByteArray = Encoding.UTF8.GetBytes(encryptString);
            var provider = new DESCryptoServiceProvider();
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, provider.CreateEncryptor(keyBytes, keyIv), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.ToArray()); 
        }
        //解密
        public static string Decrypt(string decryptString, string sKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
            var keyIv = _keys;
            var inputByteArray = Convert.FromBase64String(decryptString);
            var provider = new DESCryptoServiceProvider();
            var mStream = new MemoryStream();
            var cStream = new CryptoStream(mStream, provider.CreateDecryptor(keyBytes, keyIv), CryptoStreamMode.Write);
            cStream.Write(inputByteArray, 0, inputByteArray.Length);
            cStream.FlushFinalBlock();
            return Encoding.UTF8.GetString(mStream.ToArray()); 
        }

    }
}