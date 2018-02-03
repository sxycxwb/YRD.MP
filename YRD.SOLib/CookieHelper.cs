using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;

namespace YRD.SOLib
{
    /// <summary>
    /// Cookie操作
    /// </summary>
    public class CookieHelper
    {
        /// <summary>
        /// 写Cookie
        /// </summary>
        /// <param name="CookieDomain">域</param>
        /// <param name="CookieName">cookie名称</param>
        /// <param name="ExpiresMinute">从当前时间开始延长的过期时间，以分钟算</param>
        /// <param name="isExpries">是否开启过期时间，如果开启过期时间才启作用</param>
        public static void WriteCookie(string CookieDomain, string CookieName, string CookieValue,  int ExpiresMinute, bool isExpries)
        {
            HttpCookie cookieOld = HttpContext.Current.Request.Cookies[CookieName];
            HttpCookie cookieNew = new HttpCookie(CookieName);
            if (isExpries)
            {
                cookieNew.Expires = DateTime.Now.AddMinutes(ExpiresMinute);
            }

            cookieNew.Domain = CookieDomain;
            //cookieNew.HttpOnly = true;
            cookieNew.Path = "/";
            cookieNew.Value = CookieValue;
            if (cookieOld == null)
            {
                HttpContext.Current.Response.Cookies.Add(cookieNew);
            }
            else
            {
                HttpContext.Current.Response.Cookies.Set(cookieNew);
            }
        }

        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <param name="CookieName"></param>
        /// <returns></returns>
        public static HttpCookie ReadCookie(string CookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            return cookie;
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="CookieName"></param>
        public static void ClearCookie(string CookieName, string CookieDomain)
        {
            HttpCookie cookie = new HttpCookie(CookieName);
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Domain = CookieDomain;
            cookie.Path = "/";
            HttpContext.Current.Response.Cookies.Set(cookie);
        }


    }
}
