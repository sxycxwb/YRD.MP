using System;
/// <summary>
/// 接口验证管理类
/// </summary>
public class SafeCodeHelper
{
    /// <summary>
    /// 生成检验码 字段
    /// </summary>
    public static string GetSafeCode
    {
        get
        {
            string key = Guid.NewGuid().ToString("N").ToLower();
            string value = HashHelper.Hash_MD5_32(key);
            string strCode = string.Format("{0}{1}{2}", key.Substring(0, 16), value, key.Substring(16, 16));
            return strCode;
        }
    }

    /// <summary>
    /// 检验验证码
    /// </summary>
    /// <param name="strValue"></param>
    /// <returns></returns>
    public static bool CheckSafeCode(string safecode)
    {
        bool flag = false;
        try
        {
            if (string.IsNullOrEmpty(safecode) || safecode.Length != 64)
            {
                flag = false;
                return flag;
            }

            string key = string.Format("{0}{1}", safecode.Substring(0, 16), safecode.Substring(48, 16));

            string value = safecode.Substring(16, 32);

            string comValue = HashHelper.Hash_MD5_32(key);

            if (value == comValue)
            {
                flag = true;
            }
        }
        catch
        {
            flag = false;
        }
        return flag;

    }



    //  Decryption 
}

