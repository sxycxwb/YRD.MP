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
    /// 客户端IP操作
    /// </summary>
    public class IPManager
    {
        SM manager;
        public IPManager(SM manager)
        {
            this.manager = manager;
        }

        /// <summary>
        /// 获取真实的IP地址，包括内网与代理
        /// </summary>
        /// <returns></returns>
        public string GetIP()
        {
            string result = String.Empty;
            try
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                //可能有代理   
                if (!string.IsNullOrWhiteSpace(result))
                {
                    //没有"." 肯定是非IP格式  
                    if (result.IndexOf(".") == -1)
                    {
                        result = string.Empty;
                    }
                    else
                    {
                        //有","，估计多个代理。取第一个不是内网的IP。  
                        if (result.IndexOf(",") != -1)
                        {
                            result = result.Replace(" ", string.Empty).Replace("\"", string.Empty);
                            string[] temparyip = result.Split(",;".ToCharArray());
                            if (temparyip != null && temparyip.Length > 0)
                            {
                                for (int i = 0; i < temparyip.Length; i++)
                                {
                                    //找到不是内网的地址  
                                    if (IsIPAddress(temparyip[i])
                                        && temparyip[i].Substring(0, 3) != "10."
                                        && temparyip[i].Substring(0, 7) != "192.168"
                                        && temparyip[i].Substring(0, 7) != "172.16.")
                                    {
                                        return temparyip[i];
                                    }
                                }
                            }
                        }
                        //代理即是IP格式  
                        else if (IsIPAddress(result))
                        {
                            return result;
                        }
                        //代理中的内容非IP  
                        else
                        {
                            result = string.Empty;
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(result))
                {
                    result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                }
                if (string.IsNullOrWhiteSpace(result))
                {
                    result = HttpContext.Current.Request.UserHostAddress;
                }
            }
            catch { }
            return result;
        }
        /// <summary>
        /// 获得客户端IP
        /// </summary>
        /// <returns></returns>
        private string GetClientIP()
        {
            /*
             * X-Forwarded-For格式如下: client1, proxy1, proxy2
             * 其中的值通过逗号+空格，把多个IP地址区分开, 最左边(client1)是最原始客户端的IP地址。
             * 代理服务器每成功收到一个请求，就把请求来源IP地址添加到右边。
             * 鉴于伪造这一字段非常容易，应该谨慎使用X-Forwarded-For字段。
             * 正常情况下XFF中最后一个IP地址是最后一个代理服务器的IP地址, 这通常是一个比较可靠的信息来源。
             */
            /*
             * REMOTE_ADDR 获取客户端IP地址，如果有代理服务，将获得代理的IP
             */
            /*
             * Request.UserHostAddress   直接获得远程IP，无法确定是客户端IP还是代理IP
             */

            string ipInfo = null;
            string hostIP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; //通过代理，获得所有代理IP和原始IP
            if (hostIP != null && String.Empty != hostIP && hostIP.Trim().Length > 0)
            {
                ipInfo = hostIP.Split(',')[0].Trim();
            }
            if (ipInfo == null || ipInfo.Trim().Length <= 0)
            {
                ipInfo = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]; //无视代理，获得远程IP
            }
            if (null == ipInfo || String.Empty == ipInfo || ipInfo.Trim().Length <= 0)
            {
                ipInfo = HttpContext.Current.Request.UserHostAddress;
            }
            if (!IsIPAddress(ipInfo))
            {
                ipInfo = "127.0.0.1";
            }
            return ipInfo;
        }

        /// <summary>
        /// IP是否是内网地址
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns>strIP必须是正确的IP格式</returns>
        public bool IsInnerIP(string strIP)
        {
            //if (!IsIPAddress(strIP))
            //{
            //    return false;
            //}
            bool flag = false;
            if (strIP.Substring(0, 3) != "10." && strIP.Substring(0, 7) != "192.168" && strIP.Substring(0, 7) != "172.16.")
            {
                flag = true;
            }
            return flag;
        }

        /// <summary>
        /// 检查是否是正确的IP格式
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public bool IsIPAddress(string strIP)
        {
            if (strIP == null || strIP == string.Empty || strIP.Length < 7 || strIP.Length > 15)
            {
                return false;
            }
            string regformat = @"^\\d{1,3}[\\.]\\d{1,3}[\\.]\\d{1,3}[\\.]\\d{1,3}$";
            Regex regex = new Regex(regformat, RegexOptions.IgnoreCase);
            return regex.IsMatch(strIP);
        }
    }
}
