using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;
using YRD.Model.ViewModels;
using YRD.SOLib;
using System.Net.Http;
using Newtonsoft.Json;
using YRD.Model;

namespace YRD.Web.Controllers
{
    public class OriginBaseController : Controller
    {
        protected ActionResult uploadimage(string _folderName, int _width = 5000, int _height = 5000, bool isOriginal = false)
        {
            UpFileModel model = new UpFileModel();

            HttpPostedFileBase fileData = Request.Files["fileData"];
            //'width': 100, 'height': 200, size:2097152
            var width = Request["width"];
            var height = Request["height"];
            var size = Request["size"];

            if (width.IsNull())
            {
                model.error = "参数width不能为空";
                if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                {

                    return Json(model, "application/json");
                }
                else
                {
                    return Json(model, "text/plain");
                }
            }
            if (height.IsNull())
            {
                model.error = "参数height不能为空";
                if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                {

                    return Json(model, "application/json");
                }
                else
                {
                    return Json(model, "text/plain");
                }
            }
            if (size.IsNull())
            {
                model.error = "参数size不能为空";
                if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                {

                    return Json(model, "application/json");
                }
                else
                {
                    return Json(model, "text/plain");
                }
            }
            int _thumbwidth = 0;
            int _thumbheight = 0;
            int _maxsize = 0;
            int.TryParse(width, out _thumbwidth);
            int.TryParse(height, out _thumbheight);
            int.TryParse(size, out _maxsize);

            //营业执照
            string filename = string.Empty;

            //图片上传目录
            var dbfolder = string.Format("/upload/{0}/original", _folderName);
            //缩略图目录
            var dbfoldermin = string.Format("/upload/{0}/thumbnail", _folderName);

            var maxsize = _maxsize;//200KB
            var maxh = _height;
            var maxw = _width;
            if (null != fileData)
            {
                string filetype = Path.GetExtension(fileData.FileName).ToLower();


                #region 对文件类型进行判断
                if (filetype != ".jpg" && filetype != ".png" && filetype != ".jpeg")
                {
                    model = new UpFileModel
                    {
                        status = 0,//文件格式不对
                        error = "文件格式不对",
                        oldfilename = fileData.FileName
                    };
                    if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                    {

                        return Json(model, "application/json");
                    }
                    else
                    {
                        return Json(model, "text/plain");
                    }
                }
                #endregion

                #region 对文件大小进行判断
                if (fileData.ContentLength < 1 || fileData.ContentLength > maxsize)
                {
                    model = new UpFileModel
                    {
                        status = 0,//文件大小不对
                        error = "文件太大",
                        filelink = "",
                        oldfilename = fileData.FileName
                    };
                    if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                    {

                        return Json(model, "application/json");
                    }
                    else
                    {
                        return Json(model, "text/plain");
                    }
                }
                #endregion

                #region 对文件流进行处理
                using (Stream inputStream = fileData.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
                    if (image.Width > maxw || image.Height > maxh)
                    {
                        model = new UpFileModel
                        {
                            status = 0,//文件格式不对
                            error = "文件尺寸超出限制",
                            oldfilename = fileData.FileName
                        };
                        if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                        {

                            return Json(model, "application/json");
                        }
                        else
                        {
                            return Json(model, "text/plain");
                        }
                    }
                    var data = memoryStream.ToArray();
                    filename = string.Format("{0}{1}", WebTools.getGUID(), filetype);
                    var imgFalg = FilesWebServiceHelper.sr.ImgFilesUp("", data, filename, dbfolder, dbfoldermin, _thumbwidth, _thumbheight);
                    if (imgFalg == false)
                    {
                        model = new UpFileModel
                        {
                            status = 0,//文件格式不对
                            error = "文件上传失败,请稍后重试",
                            oldfilename = fileData.FileName

                        };
                        if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                        {

                            return Json(model, "application/json");
                        }
                        else
                        {
                            return Json(model, "text/plain");
                        }
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

                        if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
                        {

                            return Json(model, "application/json");
                        }
                        else
                        {
                            return Json(model, "text/plain");
                        }
                    }
                }
            }
            #endregion


            if (Request.ServerVariables["HTTP_ACCEPT"] != null && Request.ServerVariables["HTTP_ACCEPT"].Contains("application/json"))
            {

                return Json(model, "application/json");
            }
            else
            {
                return Json(model, "text/plain");

            }
        }

        /// <summary>
        /// PostAsJsonAsync提交
        /// </summary>
        /// <typeparam name="T">返回结果模型</typeparam>
        /// <typeparam name="M">提交参数模型</typeparam>
        /// <param name="url">接口地址</param>
        /// <param name="m">参数</param>
        /// <returns></returns>
        public static T PostAsJsonAsync<T, M>(string url, M m) where T : class, new()
        {
            var http = HttpClientHelper.GetClient();
            {
                var response = http.PostAsJsonAsync(url, m).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    T result = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    return result;
                }
                else
                {
                    return new T();
                }
            }
        }

    }
}