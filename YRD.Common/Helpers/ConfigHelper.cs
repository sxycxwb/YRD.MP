using System.Configuration;

public static class ConfigHelper
{

    /// <summary>
    /// 获取CDN地址
    /// </summary>
    /// <returns></returns>
    public static string GetCdnUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["CdnUrl"];
        }
    }
    public static string GetFileServiceUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["FileServiceUrl"];
        }
    }
    /// <summary>
    /// 获取Api地址
    /// </summary>
    /// <returns></returns>
    public static string GetApiUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["ApiUrl"];
        }
    }
    /// <summary>
    /// 获取Home地址
    /// </summary>
    /// <returns></returns>
    public static string GetHomeUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["HomeUrl"];
        }
    }
    /// <summary>
    /// 获取Www地址
    /// </summary>
    /// <returns></returns>
    public static string GetWwwUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["WwwUrl"];
        }
    }
    /// <summary>
    /// 获取单点登录地址
    /// </summary>
    /// <returns></returns>
    public static string GetSoUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["SoUrl"];
        }
    }
    /// <summary>
    /// 获取单点登录地址
    /// </summary>
    /// <returns></returns>
    public static string GetSmsUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["SmsUrl"];
        }
    }
    /// <summary>
    /// 获取静态化系统地址
    /// </summary>
    /// <returns></returns>
    public static string GetGsUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["GsUrl"];
        }
    }
    /// <summary>
    /// 获取广告系统地址
    /// </summary>
    /// <returns></returns>
    public static string GetAdvertUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["AdvertUrl"];
        }
    }
    /// <summary>
    /// 获取站点系统1地址
    /// </summary>
    /// <returns></returns>
    public static string GetWebSite1Url
    {
        get
        {
            return ConfigurationManager.AppSettings["WebSite1Url"];
        }
    }

    /// <summary>
    /// 获取超管地址
    /// </summary>
    /// <returns></returns>
    public static string GetSuperManageUrl
    {
        get
        {
            return ConfigurationManager.AppSettings["SuperManage"];
        }
    }

    public static string GetCookieDomain
    {
        get
        {
            return ConfigurationManager.AppSettings["CookieDomain"];
        }
    }
    public static string GetSuperPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["SuperPassword"];
        }
    }
    public static string GetAdminPassword
    {
        get
        {
            return ConfigurationManager.AppSettings["AdminPassword"];
        }
    }
    public static bool GetIsGenerateArticle
    {
        get
        {
            return int.Parse(ConfigurationManager.AppSettings["IsGenerateArticle"]) == 1 ? true : false;
        }
    }
    public static bool GetIsUnionBaiduAdvert
    {
        get
        {
            return int.Parse(ConfigurationManager.AppSettings["IsUnionBaiduAdvert"]) == 1 ? true : false;
        }
    }
}
