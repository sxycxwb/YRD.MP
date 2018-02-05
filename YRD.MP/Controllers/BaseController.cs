using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace YRD.MP.Controllers
{
    public class BaseController : Controller
    {
        protected string AppId
        {
            get
            {
                return WebConfigurationManager.AppSettings["WeixinAppId"];//与微信公众账号后台的AppId设置保持一致，区分大小写。
            }
        }

        /// <summary>
        /// 商家ID
        /// </summary>
        public string ShopID { get; set; }

        #region 查询并分页
        /// <summary>
        /// 带分页列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="total"></param>
        /// <param name="exdata"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public string ToPageWithPaging(IEnumerable data, int total, object exdata = null, string dataFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (exdata != null)
            {
                var result = new
                {
                    success = true,
                    draw = Request["draw"],
                    recordsTotal = total,
                    recordsFiltered = total,
                    data = data,
                    exdata = exdata
                };
                return result.ToJsonString(dataFormat);
            }
            else
            {
                var result = new
                {
                    success = true,
                    draw = Request["draw"],
                    recordsTotal = total,
                    recordsFiltered = total,
                    data = data
                };
                return result.ToJsonString(dataFormat);
            }

        }
        #endregion

        #region 查询不分页
        /// <summary>
        /// 不带分布列表
        /// </summary>
        /// <param name="data"></param>
        /// <param name="exdata"></param>
        /// <param name="dataFormat"></param>
        /// <returns></returns>
        public string ToPageNoPaging(IEnumerable data, object exdata = null, string dataFormat = "yyyy-MM-dd HH:mm:ss")
        {
            if (exdata != null)
            {
                var result = new
                {
                    success = true,
                    data = data,
                    exdata = exdata
                };
                return result.ToJsonString(dataFormat);
            }
            else
            {
                var result = new
                {
                    success = true,
                    data = data
                };
                return result.ToJsonString(dataFormat);
            }

        }
        #endregion

        public string ToErrorMsg(string errorMsg)
        {
            var result = new
            {
                success = false,
                msg= errorMsg
            };
            return result.ToJsonString();
        }
    }
}
