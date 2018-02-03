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
    /// RSA非对称加密
    /// </summary>
    public class RSACryptoHelper
    {
        public RSACryptoHelper()
        {
            this.rsaProvider = new RSACryptoServiceProvider();
            this.CreatePublicPrivateKey();
        }

        private RSACryptoServiceProvider rsaProvider = null;
        private string _publicKey = null; //公钥
        private string _privateKey = null; //私钥

        private void CreatePublicPrivateKey()
        {
            this._publicKey = Convert.ToBase64String(this.rsaProvider.ExportCspBlob(false)); //生成公钥
            this._privateKey = Convert.ToBase64String(this.rsaProvider.ExportCspBlob(true)); //生成秘钥
        }

        /// <summary>
        /// 公钥
        /// </summary>
        public string PublicKey
        {
            get
            {
                return this._publicKey;
            }
        }

        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey
        {
            get
            {
                return this._privateKey;
            }
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="strPlainText">需要加密的字符串</param>
        /// <returns>返回密码</returns>
        public string RSAEncrypt(string strPlainText)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(strPlainText);
            string strCypherText = null; //密码
            try
            {
                //RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                //OAEP padding is only available on Microsoft Windows XP or later.  
                byte[] bytesCypherText = this.rsaProvider.Encrypt(DataToEncrypt, false); //执行加密
                strCypherText = Convert.ToBase64String(bytesCypherText);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                strCypherText = null;
            }
            return strCypherText;
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="strCypherText">密码</param>
        /// <returns>返回原码</returns>
        public string RSADecrypt(string strCypherText)
        {
            byte[] DataToDecrypt = Convert.FromBase64String(strCypherText);
            string strPlainText = null;
            try
            {
                byte[] bytes_Public_Key = Convert.FromBase64String(this._privateKey);
                this.rsaProvider.ImportCspBlob(bytes_Public_Key);

                //OAEP padding is only available on Microsoft Windows XP or later.  
                byte[] bytes_Plain_Text = this.rsaProvider.Decrypt(DataToDecrypt, false);
                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                strPlainText = ByteConverter.GetString(bytes_Plain_Text);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                strPlainText = null;
            }
            return strPlainText;
        }
    }
}
