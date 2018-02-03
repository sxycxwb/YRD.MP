using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace YRD.SOLib
{
    /// <summary>
    /// 根据cookie判断用户登录信息
    /// </summary>
    public class SoLogin
    {
        #region private field

        /// <summary>
        /// cookie域名
        /// </summary>
        private static string cookieDoman = ".meiweiyun.cn"; //cookie域,默认为

        /// <summary>
        /// cookie过期时间
        /// </summary>
        private static int expiresMinute = 120; //cookie过期时间，默认1天

        /// <summary>
        /// cookie名称
        /// </summary>
        private static string cookieName = ".yrd.com";

        #endregion

        #region public field

        /// <summary>
        /// Cookie的域
        /// </summary>
        public static string CookieDoman
        {
            get
            {
                return SoLogin.cookieDoman;
            }
            set
            {
                SoLogin.cookieDoman = value;
            }
        }



        #endregion

        #region IsLogin

        /// <summary>
        /// 判断用户是否登录，如果用户已经登录，返回客户端登录唯一标识 SoLibID
        /// </summary>
        /// <returns>登录成功返回SoLibID 登录失败返回空</returns>
        public static string IsLogin()
        {
            string hashCookieName = SM.Current.HashManager.Hash_MD5_16(cookieName);
            return IsLoginByHash(hashCookieName);
        }

        /// <summary>
        /// 要用经过Hash运行的用户名判断用户是否登录成功
        /// </summary>
        /// <returns>登录成功返回True 登录失败返回False</returns>
        private static string IsLoginByHash(string hashCookieName)
        {
            bool flag = false;
            string soLibID = string.Empty;
            try
            {
                string cookieName = hashCookieName;
                HttpCookie cookie = CookieHelper.ReadCookie(cookieName);
                if (null == cookie)
                {
                    return soLibID;
                }
                string cookieValue = cookie.Value;
                string cookieValuePlain = SM.Current.CryptoManager.Decrypt(cookieValue); //cookie value 原码
                SoUser model = JsonConvert.DeserializeObject<SoUser>(cookieValuePlain); //反序列化
                if (model == null)
                {
                    return soLibID;
                }
                else
                {
                    flag = true;
                    soLibID = SM.Current.CryptoManager.Encrypt(string.Format("{0}{1}", model.UserName, model.DT.ToString("yyyy-MM-dd HH:mm:ss")));
                }

                //flag = false;

                //string clientIPNow = SM.Current.IPManager.GetIP();
                //string clientIPCookie = model.IP;

                //if (clientIPNow != null && clientIPCookie != null)
                //{
                //    if (clientIPNow == clientIPCookie)
                //    {
                //        flag = true;
                //    }
                //}

            }
            catch
            {
                flag = false;
            }
            if (!flag)
            {
                soLibID = string.Empty;
            }

            return soLibID;
        }
        #endregion

        #region GetUserModel

        /// <summary>
        /// 返回已经成功登录用户对象实体
        /// </summary>
        /// <returns></returns>
        public static SoUser GetUserModel()
        {
            //根据cookieName 获取到加密hashCookieName
            string hashCookieName = SM.Current.HashManager.Hash_MD5_16(cookieName);
            return GetUserModelByHash(hashCookieName);
        }

        /// <summary>
        /// 返回已经成功登录用户对象实体
        /// </summary>
        /// <param name="hashCookieName"></param>
        /// <returns></returns>
        private static SoUser GetUserModelByHash(string hashCookieName)
        {
            SoUser model = null;
            try
            {
                HttpCookie cookie = CookieHelper.ReadCookie(hashCookieName);
                if (null == cookie)
                {
                    return null;
                }

                string cookieValue = cookie.Value;

                if (!string.IsNullOrEmpty(cookieValue))
                {
                    string cookieValuePlain = SM.Current.CryptoManager.Decrypt(cookieValue); //cookie value 原
                    model = JsonConvert.DeserializeObject<SoUser>(cookieValuePlain); //反序列化
                }

            }
            catch
            {
                model = null;
            }

            return model;
        }
        #endregion

        #region Login 登录成功之后 写Cookie使用
        /// <summary>
        /// 登录成功之后，写cookie调用
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Login(SoUser item)
        {
            bool flag = false;
            try
            {
                if (item == null)
                {
                    flag = false;
                }
                else
                {
                    //防止调用时不给赋值时间导致问题
                    item.DT = DateTime.Now;
                    string hashCookieName = SM.Current.HashManager.Hash_MD5_16(cookieName);
                    string jsonUser = JsonConvert.SerializeObject(item); //序列化
                    string cookieValue = jsonUser;
                    string cookieValueCypher = SM.Current.CryptoManager.Encrypt(cookieValue);
                    CookieHelper.WriteCookie(SoLogin.cookieDoman, hashCookieName, cookieValueCypher, SoLogin.expiresMinute, false);
                    //添加用户登录昵称
                    CookieHelper.WriteCookie(SoLogin.cookieDoman, "NickName", item.NickName, SoLogin.expiresMinute, false);
                    flag = true;
                }
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region LoginOut
        /// <summary>
        /// 退出时调用
        /// </summary>
        /// <returns></returns>
        public static bool LoginOut()
        {
            bool flag = false;
            try
            {
                string hashCookieName = SM.Current.HashManager.Hash_MD5_16(cookieName);
                CookieHelper.ClearCookie(hashCookieName, cookieDoman);
                CookieHelper.ClearCookie("NickName", cookieDoman);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        #endregion

        #region Cookie验证码专用
        private static string CookieVaildCode = "3CDD1F17BF8E120C";

        /// <summary>
        /// 记住登录用户名
        /// </summary>
        public static void WriteCookieVaildCode(string VaildCode)
        {
            string cookieValueCypher = SM.Current.CryptoManager.Encrypt_v2(VaildCode);
            CookieHelper.WriteCookie(cookieDoman, CookieVaildCode, cookieValueCypher, 5, true);
        }

        /// <summary>
        /// 读取登录用户名
        /// </summary>
        /// <returns></returns>
        public static string ReadCookieVaildCode()
        {
            HttpCookie cookie = CookieHelper.ReadCookie(CookieVaildCode);
            string userName = string.Empty;
            if (cookie != null)
            {
                userName = SM.Current.CryptoManager.Decrypt_v2(cookie.Value);
            }
            return userName;
        }
        #endregion


        #region 加解密方法
        /// <summary>
        /// 加密字符串方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string pToEncrypt)
        {
            string str = System.Web.HttpUtility.UrlEncode(pToEncrypt, Encoding.UTF8);
            return str;
        }

        /// <summary>
        /// 解密字符串方法
        /// </summary>
        /// <param name="pToEncrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string pToEncrypt)
        {
            string str = System.Web.HttpUtility.UrlDecode(pToEncrypt, Encoding.UTF8);
            return str;
        }
        #endregion

        #region 重置Cookie登录时间
        /// <summary>
        /// 重置登录时间
        /// </summary>
        /// <returns></returns>
        public static bool ReSetLoginTime()
        {
            //todo
            return true;
        }
        #endregion

    }
}
