using System.Linq;
using System.Security.Cryptography;
using System.Text;


public class MD5
{
    #region MD5加密
    public static string ToMD5(string pwd)
    {
        var md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.Default.GetBytes(pwd);
        byte[] md5data = md5.ComputeHash(data);
        md5.Clear();
        string str = "";
        for (int i = 0; i < md5data.Length; i++)
        {
            str += md5data[i].ToString("x").PadLeft(2, '0');

        }
        return str;
    }
    #endregion
    public static string GetMD5(string sDataIn, string move)
    {
        var md5 = new MD5CryptoServiceProvider();
        var bytValue = Encoding.UTF8.GetBytes(move + sDataIn);
        var bytHash = md5.ComputeHash(bytValue);
        md5.Clear();
        return bytHash.Aggregate("", (current, t) => current + t.ToString("x").PadLeft(2, '0'));
    }

    /// <summary>
    /// 计算指定字符串的MD5哈希值
    /// </summary>
    /// <param name="message">要进行哈希计算的字符串</param>
    /// <returns></returns>
    public static string Hash(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return string.Empty;
        }
        else
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            byte[] source = Encoding.UTF8.GetBytes(message);
            byte[] result = md5.ComputeHash(source);
            StringBuilder buffer = new StringBuilder(result.Length);

            for (int i = 0; i < result.Length; i++)
            {
                buffer.Append(result[i].ToString("x2"));//将byte值转换成十六进制字符串
            }
            return buffer.ToString();
        }
    }
}
