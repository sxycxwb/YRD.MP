using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;



//1）计算32位MD5码（大小写）：Hash_MD5_32

//2）计算16位MD5码（大小写）：Hash_MD5_16

//3）计算32位2重MD5码（大小写）：Hash_2_MD5_32

//4）计算16位2重MD5码（大小写）：Hash_2_MD5_16

//5）计算SHA-1码（大小写）：Hash_SHA_1

//6）计算SHA-256码（大小写）：Hash_SHA_256

//7）计算SHA-384码（大小写）：Hash_SHA_384

//8）计算SHA-512码（大小写）：Hash_SHA_512

//fenghulong 2015-06-04
public class HashHelper
{
    /// <summary>
    /// 计算32位MD5码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_MD5_32(string word, bool toUpper = false)
    {
        try
        {
            MD5CryptoServiceProvider MD5CSP
                = new MD5CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = MD5CSP.ComputeHash(bytValue);
            MD5CSP.Clear();

            //根据计算得到的Hash码翻译为MD5码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 计算16位MD5码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_MD5_16(string word, bool toUpper = false)
    {
        try
        {
            string sHash = Hash_MD5_32(word).Substring(8, 16);
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 计算32位2重MD5码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_2_MD5_32(string word, bool toUpper = false)
    {
        try
        {
            MD5CryptoServiceProvider MD5CSP
                = new MD5CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = MD5CSP.ComputeHash(bytValue);

            //根据计算得到的Hash码翻译为MD5码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            bytValue = Encoding.UTF8.GetBytes(sHash);
            bytHash = MD5CSP.ComputeHash(bytValue);
            MD5CSP.Clear();
            sHash = "";

            //根据计算得到的Hash码翻译为MD5码
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    /// <summary>
    /// 计算16位2重MD5码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_2_MD5_16(string word, bool toUpper = false)
    {
        try
        {
            MD5CryptoServiceProvider MD5CSP
                    = new MD5CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = MD5CSP.ComputeHash(bytValue);

            //根据计算得到的Hash码翻译为MD5码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            sHash = sHash.Substring(8, 16);

            bytValue = Encoding.UTF8.GetBytes(sHash);
            bytHash = MD5CSP.ComputeHash(bytValue);
            MD5CSP.Clear();
            sHash = "";

            //根据计算得到的Hash码翻译为MD5码
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            sHash = sHash.Substring(8, 16);

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 计算SHA-1码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_SHA_1(string word, bool toUpper = false)
    {
        try
        {
            SHA1CryptoServiceProvider SHA1CSP
                = new SHA1CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = SHA1CSP.ComputeHash(bytValue);
            SHA1CSP.Clear();

            //根据计算得到的Hash码翻译为SHA-1码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    /// <summary>
    /// 计算SHA-256码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_SHA_256(string word, bool toUpper = false)
    {
        try
        {
            SHA256CryptoServiceProvider SHA256CSP
                = new SHA256CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = SHA256CSP.ComputeHash(bytValue);
            SHA256CSP.Clear();

            //根据计算得到的Hash码翻译为SHA-1码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 计算SHA-384码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_SHA_384(string word, bool toUpper = false)
    {
        try
        {
            SHA384CryptoServiceProvider SHA384CSP
                = new SHA384CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = SHA384CSP.ComputeHash(bytValue);
            SHA384CSP.Clear();

            //根据计算得到的Hash码翻译为SHA-1码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    /// <summary>
    /// 计算SHA-512码
    /// </summary>
    /// <param name="word">字符串</param>
    /// <param name="toUpper">返回哈希值格式 true：英文大写，false：英文小写</param>
    /// <returns></returns>
    public static string Hash_SHA_512(string word, bool toUpper = false)
    {
        try
        {
            SHA512CryptoServiceProvider SHA512CSP
                = new SHA512CryptoServiceProvider();

            byte[] bytValue = Encoding.UTF8.GetBytes(word);
            byte[] bytHash = SHA512CSP.ComputeHash(bytValue);
            SHA512CSP.Clear();

            //根据计算得到的Hash码翻译为SHA-1码
            string sHash = "", sTemp = "";
            for (int counter = 0; counter < bytHash.Count(); counter++)
            {
                long i = bytHash[counter] / 16;
                if (i > 9)
                {
                    sTemp = ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp = ((char)(i + 0x30)).ToString();
                }
                i = bytHash[counter] % 16;
                if (i > 9)
                {
                    sTemp += ((char)(i - 10 + 0x41)).ToString();
                }
                else
                {
                    sTemp += ((char)(i + 0x30)).ToString();
                }
                sHash += sTemp;
            }

            //根据大小写规则决定返回的字符串
            return toUpper ? sHash : sHash.ToLower();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}

