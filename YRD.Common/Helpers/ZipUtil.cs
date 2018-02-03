﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


public class ZipUtilHelper
{
    /// <summary>  
    /// 压缩  
    /// </summary>  
    /// <param name="param"></param>  
    /// <returns></returns>  
    public static string Compress(string param)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes(param);
        //byte[] data = Convert.FromBase64String(param);  
        MemoryStream ms = new MemoryStream();
        Stream stream = new ICSharpCode.SharpZipLib.BZip2.BZip2OutputStream(ms);
        try
        {
            stream.Write(data, 0, data.Length);
        }
        finally
        {
            stream.Close();
            ms.Close();
        }
        return Convert.ToBase64String(ms.ToArray());
    }


    /// <summary>  
    /// 解压  
    /// </summary>  
    /// <param name="param"></param>  
    /// <returns></returns>  
    public static string Decompress(string param)
    {
        string commonString = "";
        byte[] buffer = Convert.FromBase64String(param);
        MemoryStream ms = new MemoryStream(buffer);
        Stream sm = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(ms);
        //这里要指明要读入的格式，要不就有乱码  
        StreamReader reader = new StreamReader(sm, System.Text.Encoding.UTF8);
        try
        {
            commonString = reader.ReadToEnd();
        }
        finally
        {
            sm.Close();
            ms.Close();
        }
        return commonString;
    }
}


