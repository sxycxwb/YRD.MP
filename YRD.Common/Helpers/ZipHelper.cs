using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


public class ZipHelper
{

    /// <summary>
    /// 所有文件缓存
    /// </summary>
    List<string> files = new List<string>();

    /// <summary>
    /// 所有空目录缓存
    /// </summary>
    List<string> paths = new List<string>();


    /// <summary>
    /// 压缩目录（包括子目录及所有文件）
    /// </summary>
    /// <param name="rootPath">要压缩的根目录</param>
    /// <param name="destinationPath">保存路径</param>
    /// <param name="compressLevel">压缩程度，范围0-9，数值越大，压缩程序越高</param>
    public static void ZipFileFromDirectory(string rootPath, string destinationPath, string filename, int compressLevel)
    {

        string[] files = Directory.GetFiles(rootPath);
        string rootMark = rootPath + "\\";//得到当前路径的位置，以备压缩时将所压缩内容转变成相对路径。
        Crc32 crc = new Crc32();
        string tempfilename = string.Format("{0}/{1}", destinationPath, filename);
        ZipOutputStream outPutStream = new ZipOutputStream(File.Create(tempfilename));
        outPutStream.SetLevel(compressLevel); // 0 - store only to 9 - means best compression
        foreach (string file in files)
        {
            FileStream fileStream = File.OpenRead(file);//打开压缩文件
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, buffer.Length);
            ZipEntry entry = new ZipEntry(file.Replace(rootMark, string.Empty));
            entry.DateTime = DateTime.Now;
            // set Size and the crc, because the information
            // about the size and crc should be stored in the header
            // if it is not set it is automatically written in the footer.
            // (in this case size == crc == -1 in the header)
            // Some ZIP programs have problems with zip files that don't store
            // the size and crc in the header.
            entry.Size = fileStream.Length;
            fileStream.Close();
            crc.Reset();
            crc.Update(buffer);
            entry.Crc = crc.Value;
            outPutStream.PutNextEntry(entry);
            outPutStream.Write(buffer, 0, buffer.Length);
        }
        outPutStream.Finish();
        outPutStream.Close();
        GC.Collect();
    }
}
