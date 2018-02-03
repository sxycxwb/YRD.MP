using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


public class SmtpHelper
{
    static string host = "smtp.qq.com";
    static int port = 25;
    /// <summary>
    /// 默认值为100秒
    /// </summary>
    static int timeout = 100000;
    public static string fromAddress = "master@nchanpin.com";
    static string fromNickName = "今农网";
    static string fromPassword = "775852112501236";


    /// <summary>
    /// 异步发送邮件
    /// </summary>
    /// <param name="toAddress"></param>
    /// <param name="subject"></param>
    /// <param name="content"></param>
    public static Base SendSmtpAsyncToUser(string toAddress, string subject, string content)
    {
        Base b = new Base();
        try
        {
            #region 异步发送邮件
            //实例化一个smtp客户端
            SmtpClient client = new SmtpClient();
            //smtp服务器 qq:smtp.qq.com,端口：25 smtp服务器需要身份验证
            client.Host = host;
            client.Port = port;
            //指定如何处理待发的电子邮件
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //指定超时时间
            client.Timeout = timeout;
            //实例化发件人地址
            MailAddress from = new MailAddress(fromAddress, fromNickName, Encoding.UTF8);
            MailAddress to = new MailAddress(toAddress);

            //  MailMessage mail = new MailMessage(from, to);
            MailMessage mail = new MailMessage();
            mail.From = from;
            mail.To.Add(to);
            //主题
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            //正文
            mail.Body = content;

            mail.Priority = MailPriority.High;
            mail.BodyEncoding = Encoding.GetEncoding("utf-8");
            //指定发件人信息  包括邮箱地址和邮箱密码
            client.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //默认的身份凭据，这个最好不要设置，无论设置真假，发邮件都会出问题
            //client.UseDefaultCredentials = false;
            string userState = string.Format("toAddress:{0},subject:{1},content:{2}", toAddress, subject, content);
            client.SendCompleted += client_SendCompleted;
            client.SendAsync(mail, userState);
            b.Code = 1;
            b.Message = ConstantHelper.Success;
            #endregion
        }
        catch (Exception Exc)
        {
            b.Code = 0;
            b.Description = Exc.ToString();
            b.Message = ConstantHelper.Failure;
        }
        b.Code = 1;
        b.Message = "ok";
        return b;
    }

    static void client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {

    }

    /// <summary>
    /// 同步发送邮件
    /// </summary>
    /// <param name="toAddress"></param>
    /// <param name="subject"></param>
    /// <param name="content"></param>
    public static Base SendSmtpToUser(string toAddress, string subject, string content)
    {

        Base b = new Base();
        try
        {
            #region 发送邮件
            //实例化一个smtp客户端
            SmtpClient client = new SmtpClient();
            //smtp服务器 qq:smtp.qq.com,端口：25 smtp服务器需要身份验证
            client.Host = host;
            client.Port = port;
            //指定如何处理待发的电子邮件
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //指定超时时间
            client.Timeout = timeout;
            //实例化发件人地址
            MailAddress from = new MailAddress(fromAddress, fromNickName, Encoding.UTF8);
            MailAddress to = new MailAddress(toAddress);

            //  MailMessage mail = new MailMessage(from, to);
            MailMessage mail = new MailMessage();
            mail.From = from;
            mail.To.Add(to);
            //主题
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            //正文
            mail.Body = content;

            mail.Priority = MailPriority.High;
            mail.BodyEncoding = Encoding.GetEncoding("utf-8");
            //指定发件人信息  包括邮箱地址和邮箱密码
            client.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //默认的身份凭据，这个最好不要设置，无论设置真假，发邮件都会出问题
            //client.UseDefaultCredentials = false; 
            client.Send(mail);
            b.Code = 1;
            b.Message = ConstantHelper.Success;
            #endregion
        }
        catch (Exception Exc)
        {
            b.Message = " 验证邮件发送失败,请检查邮箱格式是否正确,稍后重试！";
            b.Description = Exc.ToString();
        }
        return b;

    }

    /// <summary>
    /// 给普通用户发送消息
    /// </summary>
    /// <param name="toAddress"></param>
    public static void SendSmtpToUser(string toAddress, string subject)
    {
        try
        {
            #region MyRegion


            //实例化一个smtp客户端
            SmtpClient client = new SmtpClient();
            //smtp服务器 qq:smtp.qq.com,端口：25 smtp服务器需要身份验证
            client.Host = host;
            client.Port = port;
            //指定如何处理待发的电子邮件
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            //指定超时时间
            client.Timeout = timeout;
            //实例化发件人地址
            MailAddress from = new MailAddress(fromAddress, fromNickName, Encoding.UTF8);
            MailAddress to = new MailAddress(toAddress);

            //  MailMessage mail = new MailMessage(from, to);
            MailMessage mail = new MailMessage();
            mail.From = from;
            mail.To.Add(to);
            //主题
            mail.Subject = subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.IsBodyHtml = true;
            //正文
            mail.Body = "<font size=\"4\" color=\"#666699\"><span style=\"line-height: 1.5;\">欢迎您在农产品网站发布消息，我们会尽最大努力把农产品网站做的更好。</span><br><span style=\"line-height: 1.5;\">如果您需要长期在我们农产品网站做宣传，请记住我们农产品网站的域名：http://www.nchanpin.com</span><br><span style=\"line-height: 1.5;\">如果您需要在我们的农产品网站做产品推广或消息置顶，请联系我们客服,QQ:522961566 QQ：710544504，我们的客服将会竭诚为您服务。</span></font><div><font size=\"4\" color=\"#666699\"><span style=\"line-height: 1.5;\">如果您的朋友，需要推广消息，请您顺便把我们的网站介绍给他。</span></font></div><div><font size=\"4\" color=\"#666699\">如果您在使用的过程中遇到问题或者有更好的建议，请占用您宝贵的时间，告诉我们，反馈方式：1、直接通过QQ客服；2、直接回复该邮件。我们会收集您宝贵的意见，将农产品网站做到更好。<br><span style=\"line-height: 1.5;\">感谢您对我们农产品网站的支持。</span><br></font><div><font size=\"4\" color=\"#666699\">祝你身体健康，工作顺利，生活愉快，万事如意。</font></div></div>";

            mail.Priority = MailPriority.High;
            // mail.BodyEncoding = Encoding.GetEncoding("GB2312");
            mail.BodyEncoding = Encoding.UTF8;
            //指定发件人信息  包括邮箱地址和邮箱密码
            client.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //默认的身份凭据，这个最好不要设置，无论设置真假，发邮件都会出问题
            //client.UseDefaultCredentials = false;
            string userState = "aa";
            client.SendCompleted += client_SendCompleted;
            client.SendAsync(mail, userState);
            #endregion
        }
        catch (Exception Exc)
        {

        }
    }
}
