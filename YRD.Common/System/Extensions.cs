using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace System
{
    /// <summary>
    /// 常用 扩展方法定义
    /// </summary>
    public static class SystemExtensions
    {
        #region json序列化
        /// <summary>
        /// Json序列化
        /// </summary>
        /// <returns></returns>
        public static string ToJsonString(this object obj, string dateFormate = "yyyy-MM-dd")
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,//去除循环引用
                DateFormatString = dateFormate //设置日期格式化
            };
            JsonSerializer ser = JsonSerializer.Create(settings);
            using (var sw = new StringWriter())
            {
                ser.Serialize(sw, obj);
                return sw.ToString();
            }
        }
        /// <summary>
        /// Json序列化，长时间处理‘yyyy-MM-dd HH:mm:ss’
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToJsonLongDate(this object obj)
        {
            return ToJsonString(obj, "yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// Json反序列化
        /// </summary>
        /// <returns></returns>
        public static T JsonDeserializer<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }
        #endregion

        #region Count 该方法目前不太稳定 推建使用LongCount
        /// <summary>
        /// 该方法目前不太稳定 推建使用LongCount
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int EFCount<T>(this IQueryable<T> obj)
        {
            return (int)obj.LongCount();
        }
        #endregion
        #region LongCount
        public static int EFLongCount<T>(this IQueryable<T> obj)
        {
            //return (int)obj.LongCount();
            return (int)obj.Count();
        }
        #endregion

        #region 过滤掉 html 字符串 方法
        /// <summary>
        /// 过滤掉 html 字符串 方法
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string getNoHTMLString(this string Htmlstring)
        {
            if (Htmlstring == null)
                return "";
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            Htmlstring = HttpUtility.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }
        #endregion

        #region 过滤重复数据
        /// <summary>
        /// 过滤重复数据
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
        #endregion

        #region MD5加密
        public static string ToMD5(this string str)
        {
            return MD5.Hash(str);
        }
        #endregion

        #region 字符串是否为空的简化
        public static bool IsNull(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        public static bool IsNotNull(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }
        #endregion

        #region 空的时间转换成时间字符串
        /// <summary>
        /// 扩展空的时间转字符串
        /// </summary>
        /// <param name="dt">空的时间</param>
        /// <param name="format">格式</param>
        /// <returns></returns>
        public static string ToString(this DateTime? dt, string format = FormatHelper.DataTimeFormat)
        {
            string str = "";
            if (dt.HasValue)
            {
                str = dt.Value.ToString(format);
            }
            return str;
        }
        #endregion
    }
}
