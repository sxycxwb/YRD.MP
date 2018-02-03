using System.Web;
using System.Text;
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;

namespace Com.Alipay
{
    /// <summary>
    /// 类名：Config
    /// 功能：基础配置类
    /// 详细：设置帐户有关信息及返回路径
    /// 版本：3.4
    /// 修改日期：2016-03-08
    /// 说明：
    /// 以下代码只是为了方便商户测试而提供的样例代码，商户可以根据自己网站的需要，按照技术文档编写,并非一定要使用该代码。
    /// 该代码仅供学习和研究支付宝接口使用，只是提供一个参考。
    /// </summary>
    public class Config
    {

        //↓↓↓↓↓↓↓↓↓↓请在这里配置您的基本信息↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        // 合作身份者ID，签约账号，以2088开头由16位纯数字组成的字符串，查看地址：https://b.alipay.com/order/pidAndKey.htm
        public static string partner = "2088021170456563";

        // 收款支付宝账号，以2088开头由16位纯数字组成的字符串，一般情况下收款账号就是签约账号
        public static string seller_id = partner;

        //商户的私钥,原始格式，RSA公私钥生成：https://doc.open.alipay.com/doc2/detail.htm?spm=a219a.7629140.0.0.nBDxfy&treeId=58&articleId=103242&docType=1
        public static string private_key = @"MIICXAIBAAKBgQDSFATU0RoXawsqy+RZos7LR96rFiQl2353YtfujrEwMfzJO8tNbzER/ns7yS4jQw7hnvgW8zZVRC+ZE9a26lhJb1v7zinU5NgPTY//+4qblaZN0sp1TK4/xtwQe7C2ZQJAvZC+ZcoDJK0+oUpDd072WGrZmxVrVN1GB4+lDjkmKwIDAQABAoGAKXaICZUHyE15U8YQWNy4YgjaWvwwwEQVLu0UX2JMeI21LeaeVrc2gS2wFvm7IHyQyFk+8BCqzaN6nYT74PhZ2jD+FghyK1F8U6sIyR/evYGpBrCjv+H0fUgf8aT90tOGbE9N/FUSBWHzSxoazV+IfTLjRVAS/vi/uEcgwECQlYECQQDyPxoIpD6I4bABBRBVsvFmrcCn472advBh+xgxE/jweBiMQi/pHy0CaIbunWPv9pdCb+wyqZPtY3NhTugQjK1rAkEA3gFfHnCiEAzVEdU1qAWsCTLZfUOHO7LXrzDF2ETUs/xL5sRhlFm5D6GoA/CrJ4TEvwIRa9G511KJYpsT7XzaQQJBANQrYGnhMMRCpxy9iqkEqVn9JJfnZ9E6CyBGA9I4Y/h5t0ZhUgUkQQ+y7Ttgrn8lwyV1UbKtw9pPGGdJ7QdRrzECQB/tUJGfHx9xyP6si+/jCO+1uWNzX7JtMOmH+Rv2IiTURtIkMehU0vF1jSUr6mFfja/uizTXT4Ow4gMlTENeLkECQDbhXbK/Xb+ODJ2q8W3sTW1RY7Ksd5NNH6qQJPD4/ISQU1hH1l6MkQjAEHb/tjxrO1Z7qiShiQ6pgm/+Sy0MTLA=";

        //支付宝的公钥，查看地址：https://b.alipay.com/order/pidAndKey.htm 
        public static string alipay_public_key = @"MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";

        // 服务器异步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数,必须外网可以正常访问
        public static string notify_url = "http://home.meiweiyun.cn/alipay/notify_url";

        // 页面跳转同步通知页面路径，需http://格式的完整路径，不能加?id=123这类自定义参数，必须外网可以正常访问
        public static string return_url = "http://home.meiweiyun.cn/alipay/return_url";

        // 签名方式
        public static string sign_type = "RSA";

        // 调试用，创建TXT日志文件夹路径，见AlipayCore.cs类中的LogResult(string sWord)打印方法。
        public static string log_path = HttpRuntime.AppDomainAppPath.ToString() + "log\\";

        // 字符编码格式 目前支持 gbk 或 utf-8
        public static string input_charset = "utf-8";

        // 支付类型 ，无需修改
        public static string payment_type = "1";

        // 调用的接口名，无需修改
        public static string service = "create_direct_pay_by_user";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置您的基本信息↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑


        //↓↓↓↓↓↓↓↓↓↓请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        //防钓鱼时间戳  若要使用请调用类文件submit中的Query_timestamp函数
        public static string anti_phishing_key = "";

        //客户端的IP地址 非局域网的外网IP地址，如：221.0.0.1
        public static string exter_invoke_ip = "";

        //↑↑↑↑↑↑↑↑↑↑请在这里配置防钓鱼信息，如果没开通防钓鱼功能，请忽视不要填写 ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑

    }
}