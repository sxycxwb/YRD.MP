using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewStaff
    {
        public string ID { get; set; }
        public string NickName { get; set; }

        public string LoginName { get; set; }

        public string LoginPwd { get; set; } 
        public string SelRoleID { get; set; }
        /// <summary>
        /// 编号
        /// </summary>
        public string ManagerNo { get; set; }
      
        public string Birthday { get; set; } 
        public string Sex { get; set; }
        public string GenderText { get; set; }
        public string Phone { get; set; }
        /// <summary>
        /// 入职时间
        /// </summary>
        public string InductionTime { get; set; }
    }
}
