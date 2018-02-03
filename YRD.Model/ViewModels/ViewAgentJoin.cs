using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewAgentJoin
    {
        public string RealName { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 省
        /// </summary>
        public string ProvinceID { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string CityID { get; set; }
        /// <summary>
        /// 县
        /// </summary>
        public string CountyID { get; set; }
        /// <summary>
        /// 圈
        /// </summary>
        public string AreaID { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo { get; set; }

        public string Phone { get; set; }

        public string  Code { get; set; }
    }
}
