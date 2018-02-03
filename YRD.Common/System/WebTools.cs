using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;

namespace System
{
    public class WebTools
    {
        #region 复制对象，主要是对于数据库表某条记录 每个字段分别复制其内容（可以排除不复制的字段）

        /// <summary> 
        /// 把源对象的值复制到目标对象 
        /// </summary> 
        /// <param name="SourceObject">源对象</param> 
        /// <param name="TargetObject">目标对象</param> 
        /// <param name="isNullCopy">null属性不赋值</param> 
        /// <returns>返回AOPResult</returns> 
        public static JsonHelper CopyToObject(object SourceObject, object TargetObject, bool isNullCopy = false)
        {
            try
            {
                Type TS = SourceObject.GetType();
                Type TT = TargetObject.GetType();
                if (!TS.Equals(TT))
                {
                    return new JsonHelper(false, "源对象与目标对象的类型不一致");
                }
                FieldInfo[] fieldInfos = TS.GetFields(BindingFlags.Instance | BindingFlags.Public);
                PropertyInfo[] propertyInfos = TS.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (var item in fieldInfos)
                {
                    var value = item.GetValue(SourceObject);
                    if (value != null || (value == null && isNullCopy))
                    {
                        item.SetValue(TargetObject, value);
                    }
                }
                foreach (var item in propertyInfos)
                {
                    if (item.CanWrite == true && (item.PropertyType.IsValueType == true || item.PropertyType == typeof(String)))
                    {
                        var value = item.GetValue(SourceObject, null);
                        if (value != null || (value == null && isNullCopy))
                        {
                            item.SetValue(TargetObject, value, null);
                        }
                    }
                }
                return new JsonHelper(true);
            }
            catch (Exception Exc)
            {
                return new JsonHelper(false, Exc.Message);
            }
        }

        /// <summary> 
        /// 把源对象的值复制到目标对象,排除不需要复制的字段 
        /// </summary> 
        /// <param name="SourceObject">源对象</param> 
        /// <param name="TargetObject">目标对象</param> 
        /// <param name="field">不需要复制的字段</param> 
        /// <returns>返回AOPResult</returns> 
        public static JsonHelper CopyToObject(object SourceObject, object TargetObject, string[] field, bool isNullCopy = false)
        {
            try
            {
                Type TS = SourceObject.GetType();
                Type TT = TargetObject.GetType();
                if (!TS.Equals(TT))
                {
                    return new JsonHelper(false, "源对象与目标对象的类型不一致");
                }
                FieldInfo[] fieldInfos = TS.GetFields(BindingFlags.Instance | BindingFlags.Public);
                PropertyInfo[] propertyInfos = TS.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                StringBuilder sb = new StringBuilder();
                sb.Append(",");
                foreach (var item in field)
                {
                    sb.Append(item + ",");
                }
                foreach (var item in fieldInfos)
                {
                    if (!sb.ToString().Contains("," + item.Name + ","))
                    {
                        var value = item.GetValue(SourceObject);
                        if (value != null || (value == null && isNullCopy))
                        {
                            item.SetValue(TargetObject, value);
                        }
                    }
                }
                foreach (var item in propertyInfos)
                {
                    if (!sb.ToString().Contains("," + item.Name + ","))
                    {
                        if (item.CanWrite == true && (item.PropertyType.IsValueType == true || item.PropertyType == typeof(String)))
                        {
                            var value = item.GetValue(SourceObject, null);
                            if (value != null || (value == null && isNullCopy))
                            {
                                item.SetValue(TargetObject, value, null);
                            }
                        }
                    }
                }
                return new JsonHelper(true);
            }
            catch (Exception Exc)
            {
                return new JsonHelper(false, Exc.Message);
            }
        }
        #endregion

        #region 读取WebConfig---AppSetting节的配置
        /// <summary>
        /// 读取AppSetting节的配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppConfig(string key)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[key];
            }
            catch (Exception e)
            {
                LogHelper.Error(string.Format("读取AppSetting配置节异常，要读取的Key 为 {0},，失败原因：{1}", key, e.Message));
                return null;
            }
        }
        #endregion

        #region 获取客户端IP地址（无视代理）
        /// <summary>
        /// 获取客户端IP地址（无视代理）
        /// </summary>
        /// <returns>若失败则返回回送地址</returns>
        public static string GetHostAddress()
        {
            string userHostAddress = HttpContext.Current.Request.UserHostAddress;

            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            //最后判断获取是否成功，并检查IP地址的格式（检查其格式非常重要）
            if (!string.IsNullOrEmpty(userHostAddress) && IsIP(userHostAddress))
            {
                return userHostAddress;
            }
            return "127.0.0.1";
        }
        /// <summary>
        /// 检查IP地址格式
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIP(string ip)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }
        #endregion

        #region 通用转换类型
        public static object ChangeType(object value, Type type)
        {
            try
            {
                if (value == null && type.IsGenericType) return Activator.CreateInstance(type);
                if (value == null) return null;
                if (type == value.GetType()) return value;
                if (type.IsEnum)
                {
                    if (value is string)
                        return Enum.Parse(type, value as string);
                    else
                        return Enum.ToObject(type, value);
                }
                if (!type.IsInterface && type.IsGenericType)
                {
                    Type innerType = type.GetGenericArguments()[0];
                    object innerValue = ChangeType(value, innerType);
                    return Activator.CreateInstance(type, new object[] { innerValue });
                }
                if (value is string && type == typeof(Guid)) return new Guid(value as string);
                if (value is string && type == typeof(Version)) return new Version(value as string);
                if (!(value is IConvertible)) return value;
                return Convert.ChangeType(value, type);
            }
            catch
            {

            }
            return value;
        }
        #endregion

        #region 获取最终异常
        /// <summary>
        /// 获取最终的异常信息
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string getFinalException(Exception e)
        {
            if (e.InnerException != null)
            {
                return getFinalException(e.InnerException);
            }
            //return e.Message;      
            return e.ToString();
        }
        #endregion

        #region 获取绝对路径
        /// <summary>
        /// 获取最终的异常信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static string MapPath(string path)
        {
            return AppDomain.CurrentDomain.BaseDirectory + path;
        }
        #endregion

        #region 发送get请求 或 post请求
        //private string HttpPost(string Url, string postDataStr)
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
        //    request.Method = "POST";
        //    request.ContentType = "application/x-www-form-urlencoded";
        //    request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
        //    request.CookieContainer = cookie;
        //    Stream myRequestStream = request.GetRequestStream();
        //    StreamWriter myStreamWriter = new StreamWriter(myRequestStream, Encoding.GetEncoding("gb2312"));
        //    myStreamWriter.Write(postDataStr);
        //    myStreamWriter.Close();

        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    response.Cookies = cookie.GetCookies(response.ResponseUri);
        //    Stream myResponseStream = response.GetResponseStream();
        //    StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
        //    string retString = myStreamReader.ReadToEnd();
        //    myStreamReader.Close();
        //    myResponseStream.Close();

        //    return retString;
        //}

        public static string HttpGet(string Url, string postDataStr, int sleep = 0)
        {
            var url = Url + (postDataStr == "" ? "" : "?") + postDataStr;
            return HttpGet(url, sleep);
        }
        public static string HttpGet(string Url, int sleep = 0)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Thread.Sleep(sleep * 1000);
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        #region Web请求.         
        /// <summary>  
        /// POST请求与获取结果  
        /// </summary>  
        public static string HttpPost(string Url, string postDataStr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }
        #endregion
        #endregion

        #region GUID32
        /// <summary>
        /// 返回32位不重复的GUID
        /// </summary>
        /// <returns></returns>
        public static string getGUID()
        {
            var nowtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            var longid = GuidToLongID();
            //14+19=33
            var guid = nowtime + longid.ToString().Substring(0, 18);
            return guid;

        }

        /// <summary>  
        /// 根据GUID获取19位的唯一数字序列  
        /// </summary>  
        /// <returns></returns>  
        public static long GuidToLongID()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(buffer, 0);
        }
        #endregion

        #region 接口的验证
        private static string tokenstring = "mxbig";
        /// <summary>
        /// 获得token
        /// </summary>
        /// <param name="id">操作员id</param>
        /// <returns></returns>
        public static string getToken(string id)
        {
            var newid = id + tokenstring;
            var pwd = newid.ToMD5();
            return pwd;
        }
        /// <summary>
        /// 验证token是否合法
        /// </summary>
        /// <param name="id">操作员id</param>
        /// <param name="token">token安全码</param>
        /// <returns></returns>
        public static bool ValidateToken(string id, string token)
        {
            var newid = id + tokenstring;
            var pwd = newid.ToMD5();
            return pwd == token;
        }
        #endregion

        #region 数字转大写的数字一，二，三
        public static string ConvertNumberToBig(int n)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "一");
            dic.Add(2, "二");
            dic.Add(3, "三");
            dic.Add(4, "四");
            dic.Add(5, "五");
            dic.Add(6, "六");
            dic.Add(7, "七");
            dic.Add(8, "八");
            dic.Add(9, "九");
            dic.Add(0, "零");
            string dd = n.ToString();
            string svalue = string.Empty;
            foreach (char item in dd.ToCharArray())
            {
                foreach (int key in dic.Keys)
                {
                    if (key.ToString() == item.ToString())
                    {
                        svalue += dic[key];
                        break;
                    }
                }

            }
            return svalue;
        }
        #endregion
    }
}
