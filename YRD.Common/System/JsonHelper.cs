using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class JsonHelper
    {
        #region 构造器
        public JsonHelper()
        {
            IsOK = false;
            Msg = "操作失败";
        }
        /// <summary>
        /// 带参数的构造器
        /// </summary>
        /// <param name="isSuccess">是否成功</param>
        /// <param name="msg">提示信息，默认为空，isSuccess=true时：操作成功，isSuccess=false：操作失败</param>
        public JsonHelper(bool isOK, string msg = null)
        {
            if (msg == null)
            {
                if (this.IsOK == false)
                {
                    msg = "操作失败";
                }
                else
                {
                    msg = "操作成功";
                }
            }
            this.IsOK = isOK;
            this.Msg = msg;
        }
        #endregion
        /// <summary>
        /// 关联对象
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 操作信息提示
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 跳转URL
        /// </summary>
        public string ReUrl { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOK { get; set; }
    }
}
