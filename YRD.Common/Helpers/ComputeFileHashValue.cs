using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

/// <summary>
/// 计算文件的Hash值管理类
/// </summary>
public class ComputeFileHashValue
{
    /// <summary>
    /// 计算文件的 MD5 值
    /// </summary>
    /// <param name="fileName">要计算 MD5 值的文件名和路径 物理文件路径</param>
    /// <returns>MD5 值16进制字符串 全是大写字母</returns>
    public static string MD5File(string fileName)
    {
        return HashFile(fileName, "md5");
    }

    /// <summary>
    /// 计算文件的 sha1 值
    /// </summary>
    /// <param name="fileName">要计算 sha1 值的文件名和路径 物理文件路径</param>
    /// <returns>sha1 值16进制字符串 全是大写字母</returns>
    public static string SHA1File(string fileName)
    {
        return HashFile(fileName, "sha1");
    }


    /// <summary>
    /// 计算文件的哈希值
    /// </summary>
    /// <param name="fileName">要计算哈希值的文件名和路径</param>
    /// <param name="algName">算法:sha1,md5</param>
    /// <returns>哈希值16进制字符串</returns>
    private static string HashFile(string fileName, string algName)
    {
        string hex = string.Empty;
        if (!System.IO.File.Exists(fileName))
            return hex;

        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            byte[] hashBytes = HashData(fs, algName);
            fs.Close();
            hex = ByteArrayToHexString(hashBytes);
        }
        return hex;
    }

    public static string HashFile(Stream stream, string algName)
    {
        byte[] hashBytes = HashData(stream, algName);
        return ByteArrayToHexString(hashBytes);
    }
    public static string HashFile(byte[] stream, string algName)
    {
        byte[] hashBytes = HashData(stream, algName);
        return ByteArrayToHexString(hashBytes);
    }
    /// <summary>
    /// 计算哈希值
    /// </summary>
    /// <param name="buffer">要计算哈希值的 Stream</param>
    /// <param name="algName">算法:sha1,md5</param>
    /// <returns>哈希值字节数组</returns>
    private static byte[] HashData(byte[] buffer, string algName)
    {
        System.Security.Cryptography.HashAlgorithm algorithm;
        if (algName == null)
        {
            throw new ArgumentNullException("algName 不能为 null");
        }
        if (string.Compare(algName, "sha1", true) == 0)
        {
            algorithm = System.Security.Cryptography.SHA1.Create();
        }
        else
        {
            if (string.Compare(algName, "md5", true) != 0)
            {
                throw new Exception("algName 只能使用 sha1 或 md5");
            }
            algorithm = System.Security.Cryptography.MD5.Create();
        }
        return algorithm.ComputeHash(buffer);
    }
    /// <summary>
    /// 计算哈希值
    /// </summary>
    /// <param name="stream">要计算哈希值的 Stream</param>
    /// <param name="algName">算法:sha1,md5</param>
    /// <returns>哈希值字节数组</returns>
    private static byte[] HashData(System.IO.Stream stream, string algName)
    {
        System.Security.Cryptography.HashAlgorithm algorithm;
        if (algName == null)
        {
            throw new ArgumentNullException("algName 不能为 null");
        }
        if (string.Compare(algName, "sha1", true) == 0)
        {
            algorithm = System.Security.Cryptography.SHA1.Create();
        }
        else
        {
            if (string.Compare(algName, "md5", true) != 0)
            {
                throw new Exception("algName 只能使用 sha1 或 md5");
            }
            algorithm = System.Security.Cryptography.MD5.Create();
        }
        return algorithm.ComputeHash(stream);
    }

    /// <summary>
    /// 字节数组转换为16进制表示的字符串
    /// </summary>
    private static string ByteArrayToHexString(byte[] buf)
    {
        return BitConverter.ToString(buf).Replace("-", "");
    }

}
