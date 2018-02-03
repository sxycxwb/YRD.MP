using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ThoughtWorks.QRCode.Codec;
using YRD.Model.ViewModels;
using YRD.Web;

/// <summary>
/// 格式化类库
/// </summary>
public class TwoDimensionCodeHelper
{
    /// <summary>
    /// 生成rul图片二维码数组
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static byte[] GeneralTwoDimensionCode(string url)
    {
        QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
        qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
        qrCodeEncoder.QRCodeScale = 4;
        qrCodeEncoder.QRCodeVersion = 0;
        qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

        var img = qrCodeEncoder.Encode(url);

        MemoryStream ms = new MemoryStream();
        img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

        return ms.ToArray();
    }

    public static UpFileModel uploadimage(string _folderName, byte[] data, bool isOriginal, string tablename)
    {
        UpFileModel model = new UpFileModel();

        //营业执照
        string filename = string.Empty;

        //图片上传目录
        var dbfolder = string.Format("/upload/{0}/original", _folderName);
        //缩略图目录
        var dbfoldermin = string.Format("/upload/{0}/thumbnail", _folderName);

        filename = string.Format("{0}{1}", tablename, ".jpg");
        var imgFalg = FilesWebServiceHelper.sr.ImgFilesUp("", data, filename, dbfolder, dbfoldermin, 100, 100);
        if (imgFalg == false)
        {
            model = new UpFileModel
            {
                status = 0,//文件格式不对
                error = "文件上传失败,请稍后重试",
                oldfilename = string.Empty

            };

            return model;
        }
        else
        {
            model = new UpFileModel
            {
                status = 1,//文件格式不对
                error = "文件上传成功",
                oldfilename = filename
            };
            if (isOriginal)
            {
                model.filepath = string.Format("{0}/{1}", dbfolder, filename);
                model.filelink = string.Format("{0}{1}/{2}", ConfigHelper.GetFileServiceUrl, dbfolder, filename);
            }
            else
            {
                model.filepath = string.Format("{0}/{1}", dbfoldermin, filename);
                model.filelink = string.Format("{0}{1}/{2}", ConfigHelper.GetFileServiceUrl, dbfoldermin, filename);
            }
            return model;
        }
    }
}

