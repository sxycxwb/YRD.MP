using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class ViewSetPayPassword : ViewBase
    {
        /// <summary>
        /// 是否允许设置支付密码
        /// </summary>
        public bool IsAllowSetPayPassword { get; set; }

        public string Password { get; set; }
        public string NewPayPassword { get; set; }
        public string ConfirmNewPayPassword { get; set; }
    }

    public class ViewChangePayPassword : ViewBase
    {
        public string UserName { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }

    }
}
