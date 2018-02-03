using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
public class ImageHelp
{
    /// <summary>
    /// 获取图片中的各帧
    /// </summary>
    /// <param name="pPath">图片路径</param>
    /// <param name="pSavePath">保存路径</param>
    public void GetFrames(string pPath, string pSavedPath)
    {
        Image gif = Image.FromFile(pPath);
        FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);

        //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)
        int count = gif.GetFrameCount(fd);

        //以Jpeg格式保存各帧
        for (int i = 0; i < count; i++)
        {
            gif.SelectActiveFrame(fd, i);
            gif.Save(pSavedPath + "\\frame_" + i + ".jpg", ImageFormat.Jpeg);
        }
    }

    /**/
    /// <summary>
    /// 获取图片缩略图
    /// </summary>
    /// <param name="pPath">图片路径</param>
    /// <param name="pSavePath">保存路径</param>
    /// <param name="pWidth">缩略图宽度</param>
    /// <param name="pHeight">缩略图高度</param>
    /// <param name="pFormat">保存格式，通常可以是jpeg</param>
    public void GetSmaller(string pPath, string pSavedPath, int pWidth, int pHeight)
    {
        using (FileStream fs = new FileStream(pPath, FileMode.Open))
        {
            MakeSmallImg(fs, pSavedPath, pWidth, pHeight);
        }
    }


    //按模版比例生成缩略图（以流的方式获取源文件）  
    //生成缩略图函数  
    //顺序参数：源图文件流、缩略图存放地址、模版宽、模版高  
    //注：缩略图大小控制在模版区域内  
    public static void MakeSmallImg(System.IO.Stream fromFileStream, string fileSaveUrl, System.Double templateWidth, System.Double templateHeight)
    {
        //从文件取得图片对象，并使用流中嵌入的颜色管理信息  
        System.Drawing.Image myImage = System.Drawing.Image.FromStream(fromFileStream, true);

        //缩略图宽、高  
        System.Double newWidth = myImage.Width, newHeight = myImage.Height;
        //宽大于模版的横图  
        if (myImage.Width > myImage.Height || myImage.Width == myImage.Height)
        {
            if (myImage.Width > templateWidth)
            {
                //宽按模版，高按比例缩放  
                newWidth = templateWidth;
                newHeight = myImage.Height * (newWidth / myImage.Width);
            }
        }
        //高大于模版的竖图  
        else
        {
            if (myImage.Height > templateHeight)
            {
                //高按模版，宽按比例缩放  
                newHeight = templateHeight;
                newWidth = myImage.Width * (newHeight / myImage.Height);
            }
        }

        //取得图片大小  
        System.Drawing.Size mySize = new Size((int)newWidth, (int)newHeight);
        //新建一个bmp图片  
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(mySize.Width, mySize.Height);
        //新建一个画板  
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
        //设置高质量插值法  
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        //设置高质量,低速度呈现平滑程度  
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        //清空一下画布  
        g.Clear(Color.White);
        //在指定位置画图  
        g.DrawImage(myImage, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
        new System.Drawing.Rectangle(0, 0, myImage.Width, myImage.Height),
        System.Drawing.GraphicsUnit.Pixel);

        ///文字水印  
        //System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(bitmap);
        //System.Drawing.Font f = new Font("Lucida Grande", 6);
        //System.Drawing.Brush b = new SolidBrush(Color.Gray);
        //G.DrawString("TTCE", f, b, 0, 0);
        //G.Dispose();

        //保存缩略图  
        if (File.Exists(fileSaveUrl))
        {
            File.SetAttributes(fileSaveUrl, FileAttributes.Normal);
            File.Delete(fileSaveUrl);
        }

        bitmap.Save(fileSaveUrl, System.Drawing.Imaging.ImageFormat.Jpeg);

        g.Dispose();
        myImage.Dispose();
        bitmap.Dispose();
    }



    /**/
    /// <summary>
    /// 获取图片指定部分
    /// </summary>
    /// <param name="pPath">图片路径</param>
    /// <param name="pSavePath">保存路径</param>
    /// <param name="pPartStartPointX">目标图片开始绘制处的坐标X值(通常为)</param>
    /// <param name="pPartStartPointY">目标图片开始绘制处的坐标Y值(通常为)</param>
    /// <param name="pPartWidth">目标图片的宽度</param>
    /// <param name="pPartHeight">目标图片的高度</param>
    /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
    /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
    /// <param name="pFormat">保存格式，通常可以是jpeg</param>
    public void GetPart(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY)
    {
        string normalJpgPath = pSavedPath;

        using (Image originalImg = Image.FromFile(pPath))
        {
            Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);
            Graphics graphics = Graphics.FromImage(partImg);
            Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）


            ///文字水印  
            System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(partImg);
            System.Drawing.Font f = new Font("Lucida Grande", 10, FontStyle.Italic);
            System.Drawing.Brush b = new SolidBrush(Color.Red);
            G.Clear(Color.White);
            graphics.DrawImage(originalImg, destRect, origRect, GraphicsUnit.Pixel);
            G.DrawString("TTCE", f, b, 0, 0);
            G.Dispose();

            originalImg.Dispose();
            if (File.Exists(normalJpgPath))
            {
                File.SetAttributes(normalJpgPath, FileAttributes.Normal);
                File.Delete(normalJpgPath);
            }
            partImg.Save(normalJpgPath, ImageFormat.Jpeg);
        }
    }
    /**/
    /// <summary>
    /// 获取按比例缩放的图片指定部分
    /// </summary>
    /// <param name="pPath">图片路径</param>
    /// <param name="pSavePath">保存路径</param>
    /// <param name="pPartStartPointX">目标图片开始绘制处的坐标X值(通常为)</param>
    /// <param name="pPartStartPointY">目标图片开始绘制处的坐标Y值(通常为)</param>
    /// <param name="pPartWidth">目标图片的宽度</param>
    /// <param name="pPartHeight">目标图片的高度</param>
    /// <param name="pOrigStartPointX">原始图片开始截取处的坐标X值</param>
    /// <param name="pOrigStartPointY">原始图片开始截取处的坐标Y值</param>
    /// <param name="imageWidth">缩放后的宽度</param>
    /// <param name="imageHeight">缩放后的高度</param>
    public void GetPart(string pPath, string pSavedPath, int pPartStartPointX, int pPartStartPointY, int pPartWidth, int pPartHeight, int pOrigStartPointX, int pOrigStartPointY, int imageWidth, int imageHeight)
    {
        string normalJpgPath = pSavedPath;
        using (Image originalImg = Image.FromFile(pPath))
        {
            if (originalImg.Width == imageWidth && originalImg.Height == imageHeight)
            {
                GetPart(pPath, pSavedPath, pPartStartPointX, pPartStartPointY, pPartWidth, pPartHeight, pOrigStartPointX, pOrigStartPointY);
                return;
            }

            Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image zoomImg = originalImg.GetThumbnailImage(imageWidth, imageHeight, callback, IntPtr.Zero);//缩放
            Bitmap partImg = new Bitmap(pPartWidth, pPartHeight);

            Graphics graphics = Graphics.FromImage(partImg);
            Rectangle destRect = new Rectangle(new Point(pPartStartPointX, pPartStartPointY), new Size(pPartWidth, pPartHeight));//目标位置
            Rectangle origRect = new Rectangle(new Point(pOrigStartPointX, pOrigStartPointY), new Size(pPartWidth, pPartHeight));//原图位置（默认从原图中截取的图片大小等于目标图片的大小）

            ///文字水印  
            System.Drawing.Graphics G = System.Drawing.Graphics.FromImage(partImg);
            System.Drawing.Font f = new Font("Lucida Grande", 10, FontStyle.Italic);
            System.Drawing.Brush b = new SolidBrush(Color.Red);
            G.Clear(Color.White);

            graphics.DrawImage(zoomImg, destRect, origRect, GraphicsUnit.Pixel);
            G.DrawString("TTCE", f, b, 0, 0);
            G.Dispose();

            originalImg.Dispose();
            if (File.Exists(normalJpgPath))
            {
                File.SetAttributes(normalJpgPath, FileAttributes.Normal);
                File.Delete(normalJpgPath);
            }
            partImg.Save(normalJpgPath, ImageFormat.Jpeg);
        }
    }

    /// <summary>
    /// 获得图像高宽信息
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public ImageInformation GetImageInfo(string path)
    {
        using (Image image = Image.FromFile(path))
        {
            ImageInformation imageInfo = new ImageInformation();
            imageInfo.Width = image.Width;
            imageInfo.Height = image.Height;
            return imageInfo;
        }
    }
    /*
    public Color GetFirstPixel(string path)
    {
        using (Bitmap bm = new Bitmap(path))
        {
            return bm.GetPixel(0, 0);
        }
    }

    public string ConvertToCMYK(Color c)
    {
        byte cyan = (byte)((byte)255 - c.R);
        byte magenta = (byte)((byte)255 - c.G);
        byte yellow = (byte)((byte)255 - c.B);
        byte[] bs = CorrectCMYK(cyan, magenta, yellow, (byte)20);//修正值
        StringBuilder sb = new StringBuilder("");
        int bit;
        for (int i = 0; i < bs.Length; i++)
        {
            bit = (bs[i] & 0x0f0) >> 4;
            sb.Append(chars[bit]);
            bit = bs[i] & 0x0f;
            sb.Append(chars[bit]);
        }  
        return sb.ToString();
    }

    byte[] CorrectCMYK(byte cyan, byte magenta, byte yellow, byte rep_v)//色彩修正    
    {
        byte temp = Math.Min(Math.Min(cyan, magenta), yellow);
        byte rep_k, rep_c, rep_m, rep_y;
        if (temp != 0)
        {
            byte temp2 = (byte)((rep_v / 100.0) * temp + 0.9);
            rep_k = (byte)(temp2 / 255.0 * 100 + 0.9);
            rep_c = (byte)((cyan - temp2) / 255.0 * 100 + 0.9);
            rep_m = (byte)((magenta - temp2) / 255.0 * 100 + 0.9);
            rep_y = (byte)((yellow - temp2) / 255.0 * 100 + 0.9);
        }
        else
        {
            rep_c = (byte)(cyan / 255.0 * 100 + 0.9);
            rep_m = (byte)(magenta / 255.0 * 100 + 0.9);
            rep_y = (byte)(yellow / 255.0 * 100 + 0.9);
            rep_k = 0;
        }
        byte[] bt = new byte[4] { rep_c, rep_m, rep_y, rep_k };
        return bt;
    }*/

    public bool ThumbnailCallback()
    {
        return false;
    }

    public bool IsCMYKImage(string path)
    {
        bool result = false;
        try
        {
            Image img = Bitmap.FromFile(path);
            PixelFormat pixelFormat = img.PixelFormat;
            if (pixelFormat.ToString() == "8207")
            {
                result = true;
            }
            img.Dispose();
            img = null;
        }
        catch { }
        return result;
    }

    public Bitmap ConvertCMYKToRGB(Bitmap bmp, double rate)
    {
        rate = rate > 1.0 ? 1.0 : rate;
        rate = rate < 0.5 ? 0.5 : rate;
        Bitmap tmpBmp = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
        Graphics g = Graphics.FromImage(tmpBmp);
        if (rate == 0.5)//低质量
        {
            g.CompositingQuality = CompositingQuality.HighSpeed;
            g.SmoothingMode = SmoothingMode.HighSpeed;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
        }
        else if (rate == 1.0)//高质量
        {
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }
        else
        {
            //一般质量
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
        }
        Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        //将CMYK图片重绘一遍,此时GDI+自动将CMYK格式转换为RGB了
        g.DrawImage(bmp, rect);         
        Bitmap returnBmp = new Bitmap(tmpBmp);
        g.Dispose();
        tmpBmp.Dispose();
        bmp.Dispose(); 
        return returnBmp;
    }

    public void CMYKImageFormat(string filepath)
    {
        if (this.IsCMYKImage(filepath))
        {
            Bitmap bitmap = this.ConvertCMYKToRGB(new Bitmap(filepath), 1);
            if (bitmap.RawFormat == ImageFormat.Jpeg)
            {
                bitmap.Save(filepath, ImageFormat.Jpeg);
            }
            else if (bitmap.RawFormat == ImageFormat.Gif)
            {
                bitmap.Save(filepath, ImageFormat.Gif);
            }
            else if (bitmap.RawFormat == ImageFormat.Png)
            {
                bitmap.Save(filepath, ImageFormat.Png);
            }
            else
            {
                bitmap.Save(filepath, ImageFormat.Jpeg);
            }
        }
    }
}
public struct ImageInformation
{
    private int width;

    public int Width
    {
        get { return width; }
        set { width = value; }
    }
    private int height;

    public int Height
    {
        get { return height; }
        set { height = value; }
    }
}
