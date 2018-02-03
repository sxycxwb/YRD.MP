using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.SOLib
{
    /// <summary>
    /// Cookie加密解密
    /// </summary>
    public class CryptoManager
    {


        SM manager;
        public CryptoManager(SM manager)
        {
            this.manager = manager;

        }


        /// <summary>
        /// Cookie加密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public string Encrypt(string pToEncrypt)
        {
            string str = DESCryptoHelper.DESEncrypt(pToEncrypt, manager.ConstantManager.key);
            return str;
        }

        /// <summary>
        /// Cookie解密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public string Decrypt(string pToEncrypt)
        {
            string str = DESCryptoHelper.DESDecrypt(pToEncrypt, manager.ConstantManager.key);
            return str;
        }
        /// <summary>
        /// Cookie加密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public string Encrypt_v2(string pToEncrypt)
        {
            string str = DESCryptoHelper.DESEncrypt(pToEncrypt, manager.ConstantManager.CookieValidCodeKey);
            return str;
        }

        /// <summary>
        /// Cookie解密
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public string Decrypt_v2(string pToEncrypt)
        {
            string str = DESCryptoHelper.DESDecrypt(pToEncrypt, manager.ConstantManager.CookieValidCodeKey);
            return str;
        }
    }
}
