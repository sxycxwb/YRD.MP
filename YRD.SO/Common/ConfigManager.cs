using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRD.SO.Common
{
    public class ConfigManager
    {
        Manager manager;
        public ConfigManager(Manager manager)
        {
            this.manager = manager;
        }

        private string ssoUrl;
        /// <summary>
        /// 单点登录Url地址
        /// </summary>
        public string SsoUrl
        {
            get
            {
                if (string.IsNullOrEmpty(ssoUrl))
                {
                    string tempSsoUrl = System.Configuration.ConfigurationManager.AppSettings["SsoUrl"];
                    if (string.IsNullOrEmpty(tempSsoUrl))
                    {
                        ssoUrl = "http://sso.ttce.cn";
                    }
                    else
                    {
                        ssoUrl = tempSsoUrl;
                    }
                }
                return ssoUrl;
            }
            set { ssoUrl = value; }
        }


        private string adRetUrl;

        public string AdRetUrl
        {
            get
            {
                if (string.IsNullOrEmpty(adRetUrl))
                {
                    string tempAdRetUrl = System.Configuration.ConfigurationManager.AppSettings["AdRetUrl"];
                    if (string.IsNullOrEmpty(tempAdRetUrl))
                    {
                        adRetUrl = "http://ad.ttce.cn";
                    }
                    else
                    {
                        adRetUrl = tempAdRetUrl;
                    }
                }
                return adRetUrl;
            }
            set { adRetUrl = value; }
        }


        private string wwwUrl;

        public string WwwUrl
        {
            get
            {
                if (string.IsNullOrEmpty(wwwUrl))
                {
                    string tempWwwUrl = System.Configuration.ConfigurationManager.AppSettings["WwwUrl"];
                    if (string.IsNullOrEmpty(tempWwwUrl))
                    {
                        wwwUrl = "http://www.ttce.cn";
                    }
                    else
                    {
                        wwwUrl = tempWwwUrl;
                    }
                }
                return wwwUrl;
            }
            set { wwwUrl = value; }
        }

        private string soUrl;

        public string SoUrl
        {
            get
            {
                if (string.IsNullOrEmpty(soUrl))
                {
                    string tempSoUrl = System.Configuration.ConfigurationManager.AppSettings["SoUrl"];
                    if (string.IsNullOrEmpty(tempSoUrl))
                    {
                        soUrl = "http://so.ttce.cn";
                    }
                    else
                    {
                        soUrl = tempSoUrl;
                    }
                }
                return soUrl;
            }
            set { soUrl = value; }
        }


        private string fdapiUrl;

        public string FdApiUrl
        {
            get
            {
                if (string.IsNullOrEmpty(fdapiUrl))
                {
                    string tempFdApiUrl = System.Configuration.ConfigurationManager.AppSettings["FdApiUrl"];
                    if (string.IsNullOrEmpty(tempFdApiUrl))
                    {
                        fdapiUrl = "http://apitest.ttce.cn";
                    }
                    else
                    {
                        fdapiUrl = tempFdApiUrl;
                    }
                }
                return fdapiUrl;
            }
            set { fdapiUrl = value; }
        }





        private string noLoginID;

        /// <summary>
        /// 禁止登录的用户ID
        /// </summary>
        public string NoLoginID
        {
            get
            {
                if (string.IsNullOrEmpty(noLoginID))
                {
                    string tempNoLoginID = System.Configuration.ConfigurationManager.AppSettings["NoLogin"];
                    if (string.IsNullOrEmpty(tempNoLoginID))
                    {
                        noLoginID = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            noLoginID = tempNoLoginID;
                        }
                        catch (Exception exc)
                        {

                            noLoginID = string.Empty;
                        }

                    }
                }
                return noLoginID;
            }
            set { noLoginID = value; }
        }

        private string noLoginSubID;

        /// <summary>
        /// 禁止登录的用户ID
        /// </summary>
        public string NoLoginSubID
        {
            get
            {
                if (string.IsNullOrEmpty(noLoginSubID))
                {
                    string tempNoLoginSubID = System.Configuration.ConfigurationManager.AppSettings["NoLoginSub"];
                    if (string.IsNullOrEmpty(tempNoLoginSubID))
                    {
                        noLoginSubID = string.Empty;
                    }
                    else
                    {
                        try
                        {
                            noLoginSubID = tempNoLoginSubID;
                        }
                        catch (Exception exc)
                        {

                            noLoginSubID = string.Empty;
                        }

                    }
                }
                return noLoginSubID;
            }
            set { noLoginSubID = value; }
        }

        private string superPwd;
        /// <summary>
        /// 超级密码
        /// </summary>
        public string SuperPwd
        {
            get
            {
                if (string.IsNullOrEmpty(superPwd))
                {
                    string tempSuperPwd = System.Configuration.ConfigurationManager.AppSettings["SuperPwd"];
                    if (string.IsNullOrEmpty(tempSuperPwd))
                    {
                        superPwd = string.Empty;
                    }
                    else
                    {
                        superPwd = tempSuperPwd;
                    }
                }
                return superPwd;
            }
            set { superPwd = value; }

        }


        private string adminSuperPwd;

        public string AdminSuperPwd
        {
            get
            {
                if (string.IsNullOrEmpty(adminSuperPwd))
                {
                    string tempAdminSuperPwd = System.Configuration.ConfigurationManager.AppSettings["AdminSuperPwd"];
                    if (string.IsNullOrEmpty(tempAdminSuperPwd))
                    {
                        adminSuperPwd = string.Empty;
                    }
                    else
                    {
                        adminSuperPwd = tempAdminSuperPwd;
                    }
                }
                return adminSuperPwd;
            }
            set { adminSuperPwd = value; }
        }

        private string decorationSuperPwd;

        public string DecorationSuperPwd
        {
            get
            {
                if (string.IsNullOrEmpty(decorationSuperPwd))
                {
                    string tempDecorationSuperPwd = System.Configuration.ConfigurationManager.AppSettings["DecorationSuperPwd"];
                    if (string.IsNullOrEmpty(tempDecorationSuperPwd))
                    {
                        decorationSuperPwd = string.Empty;
                    }
                    else
                    {
                        decorationSuperPwd = tempDecorationSuperPwd;
                    }
                }
                return decorationSuperPwd;
            }
            set { decorationSuperPwd = value; }
        }


        private string specialUrl;

        /// <summary>
        /// 店铺装修特殊Url地址
        /// </summary>
        public string SpecialUrl
        {
            get
            {
                if (string.IsNullOrEmpty(specialUrl))
                {
                    string tempSpecialUrl = System.Configuration.ConfigurationManager.AppSettings["SpecialUrl"];
                    if (string.IsNullOrEmpty(tempSpecialUrl))
                    {
                        specialUrl = "http://home.ttce.cn/sellerhome/MyShop_Decoration_Nav.aspx";
                    }
                    else
                    {
                        specialUrl = tempSpecialUrl;
                    }
                }
                return specialUrl;
            }
            set { specialUrl = value; }
        }

        private string homeUrl;

        public string HomeUrl
        {
            get
            {
                if (string.IsNullOrEmpty(homeUrl))
                {
                    string tempHomeUrl = System.Configuration.ConfigurationManager.AppSettings["HomeUrl"];
                    if (string.IsNullOrEmpty(tempHomeUrl))
                    {
                        homeUrl = "http://home.meiweiyun.cn";
                    }
                    else
                    {
                        homeUrl = tempHomeUrl;
                    }
                }
                return homeUrl;
            }
            set { homeUrl = value; }
        }




    }
}