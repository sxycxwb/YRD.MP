using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewRegister
    {

        public string ShopTypeID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
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
        /// <summary>
        /// 上传营业执照
        /// </summary>
        public string txtbusinesslicence { get; set; }
        /// <summary>
        /// 上传餐饮服务许可证
        /// </summary>
        public string txtpermitlicense { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 0 待审核 1审核通过 2审核失败
        /// </summary>
        public int AuditStatus { get; set; }


    }
}
