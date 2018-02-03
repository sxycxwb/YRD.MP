﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace YRD.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SOLib.SoLogin.CookieDoman = ConfigHelper.GetCookieDomain;
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            LogHelper.Debug("Application_Start");
        }

        protected void Application_End(object sender, EventArgs e)
        {
            //LogHelper.Debug("Application_End");
            ////下面的代码是关键，可解决IIS应用程序池自动回收的问题  
            //System.Threading.Thread.Sleep(1000);
            ////这里设置你的web地址，可以随便指向你的任意一个aspx页面甚至不存在的页面，目的是要激发Application_Start  
            //string url = (ConfigHelper.GetWwwUrl + "/Home/Null").Replace("//", "/").Replace("http:/", "http://");
            //HttpWebRequest myHttpWebRequest = (HttpWebRequest)System.Net.WebRequest.Create(url);
            //HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
            //System.IO.Stream receiveStream = myHttpWebResponse.GetResponseStream();//得到回写的字节流    
            //LogHelper.Debug("Application_End2");
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
            Exception objErr = Server.GetLastError().GetBaseException();  //获取错误
            if (objErr != null)
            {
                try
                {
                    string err = "发生错误地址:" + Request?.Url.ToString() + "    错误信息：" + objErr.Message.ToString();
                    //将捕获的错误写入windows的应用程序日志中，可从事件查看器中访问应用程序日志。
                    //System.Diagnostics.EventLog.WriteEntry("Test2", err, System.Diagnostics.EventLogEntryType.Error);
                    LogHelper.Warn("页面错误：" + err);
                    // Server.ClearError();  //清除异常，其他地方不再捕获此异常。
                }
                catch (Exception ex)
                {
                    LogHelper.Error("Application_Error错误：" + WebTools.getFinalException(ex));
                }
            }
        }
    }
}
