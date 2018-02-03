using System;
using System.Collections.Generic;
using System.Linq;

public class ConstantHelper
{
    /// <summary>
    /// 加密的密钥键
    /// </summary>
    public static string Key = "nchanpin";

    public static string Title = "今农网";

    /// <summary>
    /// 记录某个应用程序的根目录 
    /// </summary>
    public static string RootDirection = string.Empty;

    public static string Success = "操作成功";
    public static string Failure = "操作失败,请稍后重试！";

    public static string DeleteNotFoundDesc = "未查询到相关记录！";

    /// <summary>
    /// 表单提交错误描述
    /// </summary>
    public static string ErrorPostDesc = "提交繁忙，请稍后重试！";

    /// <summary>
    /// 上传图片为空时显示的图片
    /// </summary>
    public static string uploaderimg = string.Format("{0}{1}", ConfigHelper.GetCdnUrl, "/Content/image/upload.png");
}
