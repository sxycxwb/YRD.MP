using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace YRD.SOLib
{
    /// <summary>
    /// DES对称加密
    /// </summary>
    public class DESCryptoHelper
    {
        /// <summary>
        /// des加密
        /// </summary>
        /// <param name="pToEncrypt">需要加密的字符串</param>
        /// <param name="sKey">8位秘钥</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string pToEncrypt, string sKey)
        {
            string str = string.Empty;
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                    des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                    MemoryStream ms = new MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    str = Convert.ToBase64String(ms.ToArray());
                    ms.Close();
                }
            }
            catch
            {
                str = string.Empty;
            }
            return str;

        }

        /// <summary>
        /// des解密
        /// </summary>
        /// <param name="pToDecrypt">加密过的字符串</param>
        /// <param name="sKey">8位秘钥</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string pToDecrypt, string sKey)
        {
            string str = string.Empty;
            try
            {
                byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
                    des.IV = ASCIIEncoding.ASCII.GetBytes(sKey);
                    MemoryStream ms = new MemoryStream();
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        cs.Close();
                    }
                    str = Encoding.UTF8.GetString(ms.ToArray());
                    ms.Close();
                }
            }
            catch
            {
                str = string.Empty;
            }
            return str;
        }
    }
}
