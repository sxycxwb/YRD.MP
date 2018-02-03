using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;


/// <summary>
/// 创建图片验证码管理类
/// </summary>
public class ValidateEmailHelper
{
    /// <summary>
    /// 用户邮箱验证
    /// </summary>
    /// <param name="uguid">用户编号</param>
    /// <param name="username">用户名</param>
    /// <param name="email">邮箱</param>
    /// <param name="encryEmail">加密邮箱</param>
    /// <param name="siteName">站点名称</param>
    /// <returns></returns>
    public static Base ValidEmailUser(string uguid, string username, string email, string encryEmail, string siteName)
    {
        Base b = new Base();
        try
        {
            var url = string.Format("{0}/Email/ValidEmail/{1}_{2}_{3}", ConfigHelper.GetHomeUrl, uguid, encryEmail, WebTools.getGUID().ToString());
            var subject = string.Format("{0}__邮箱验证", siteName);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("尊敬的{0}会员 <strong>{1}:</strong><p>您好！</p>", siteName, username);
            sb.AppendFormat("<p>请点击以下链接，以完成您的邮箱验证:</p><p><a target='_blank' href='{0}'>{0}</a></p>", url);
            sb.AppendFormat("<p>如果上面的链接无法点击，您也可以复制链接，粘贴到您浏览器的地址栏内，然后按“回车”键打开预设页面，完成相应功能。</p>");
            sb.AppendFormat("<p>如果有其他问题，请联系我们： <a href=\"mailto:{0}\">{0}</a> 谢谢！</p>", SmtpHelper.fromAddress);
            sb.AppendFormat("<p>此为系统消息，请勿回复</p>");
            var body = sb.ToString();
            var result = SmtpHelper.SendSmtpToUser(email, subject, body);
            if (result.Code == 1)
            {
                b.Code = 1;
                b.Message = "验证邮件已发送到您的注册邮箱，请登录您的邮箱查看，以完成邮箱验证";
            }
            else
            {
                b = result;
            }

        }
        catch (Exception e)
        {
            b.Message = "发送注册验证邮件失败,请稍后重新注册！";
            b.Description = e.ToString();
        }
        return b;
    }

    public static Base ValidEmailUser(string username, string email, string validateCode, string siteName)
    {
        Base b = new Base();
        try
        {
            var subject = string.Format("{0}__邮箱验证", siteName);

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("尊敬的{0}会员 <strong>{1}：</strong><p>您好！</p>", siteName, username);
            sb.AppendFormat("<p>您的验证码为{0}。如非本人操作，请忽略本邮件，谢谢您的理解！</p>", validateCode);
            sb.AppendFormat("<p>如果有其他问题，请联系我们： <a href=\"mailto:{0}\">{0}</a> 谢谢！</p>", SmtpHelper.fromAddress);
            sb.AppendFormat("<p>此为系统消息，请勿回复</p>");
            var body = sb.ToString();
            var result = SmtpHelper.SendSmtpToUser(email, subject, body);
            if (result.Code == 1)
            {
                b.Code = 1;
                b.Message = "验证码已发送到您输入的邮箱，请登录您的邮箱查看，以获取邮箱验证码！";
            }
            else
            {
                b = result;
            }

        }
        catch (Exception e)
        {
            b.Message = "获取注册验证码邮件发送失败,请稍后重新注册！";
            b.Description = e.ToString();
        }
        return b;
    }
}

