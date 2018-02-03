using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewFindpwd
    {
        public string LoginName { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        public string LoginPwd { get; set; }

        public string ConfirmLoginPwd { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }


    }
}
