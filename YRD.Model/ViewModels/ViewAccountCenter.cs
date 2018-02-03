using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewAccountCenter
    {
        /// <summary>
        /// 店铺类型ID(火锅，炒菜)
        /// </summary>
        public string ShopTypeID { get; set; }

        /// <summary>
        /// 店铺类型名称
        /// </summary>
        public string ShopTypeText { get; set; }
        /// <summary>
        /// 商家店铺ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 地图经度
        /// </summary>
        public string MapLng { get; set; }
        /// <summary>
        /// 地图维度
        /// </summary>
        public string MapLat { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// qq
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 省ID
        /// </summary>
        public string ProvinceID { get; set; }

        public string ProvinceIDText { get; set; }
        /// <summary>
        /// 市ID
        /// </summary>
        public string CityID { get; set; }
        public string CityIDText { get; set; }
        /// <summary>
        /// 县区ID
        /// </summary>
        public string CountyID { get; set; }
        public string CountyIDText { get; set; }
        /// <summary>
        /// 商圈ID
        /// </summary>
        public string AreaID { get; set; }
        public string AreaIDText { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 管理区域类型（1全国2省3市4县区5商圈，其他无）
        /// </summary>
        public string ManagerAreaType { get; set; }
        /// <summary>
        /// 创建管理员ID
        /// </summary>
        public string CreateManagerID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 审核通过开通时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 使用结束时间
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 剩余时间
        /// </summary>
        public string Remainder { get; set; }

        /// <summary>
        /// 商家规模ID
        /// </summary>
        public string ScaleID { get; set; }
        /// <summary>
        /// 商家性质ID（1独立2直营3加盟）
        /// </summary>
        public string PropertyID { get; set; }
        /// <summary>
        /// 商家性质名称
        /// </summary>
        public string PropertyIDText { get; set; }
        /// <summary>
        /// 拥有者SellerID
        /// </summary>
        public string OwnSellerID { get; set; }

        /// <summary>
        /// 列表缩略图
        /// </summary>
        public string ListImg { get; set; }

        public List<ViewImgUrl> ImgUrlList { get; set; }
        /// <summary>
        /// 详情图
        /// </summary>
        public string imgurl { get; set; }

        /// <summary>
        /// 午餐开始营业时间
        /// </summary>
        public string BusinessTimeStartLunch { get; set; }
        /// <summary>
        /// 午餐结束营业时间
        /// </summary>
        public string BusinessTimeEndLunch { get; set; }
        /// <summary>
        /// 晚餐开始营业时间
        /// </summary>
        public string BusinessTimeStartDinner { get; set; }
        /// <summary>
        /// 晚餐结束营业时间
        /// </summary>
        public string BusinessTimeEndDinner { get; set; }
        /// <summary>
        /// 是否可以预定（1是0否）
        /// </summary>
        public int IsCanReserve { get; set; }
        /// <summary>
        /// 店铺Vip等级（1免费版）
        /// </summary>
        public string ShopVipTypeID { get; set; }

        /// <summary>
        /// 营业执照
        /// </summary>
        public string ImageBusinesslicence { get; set; }
        /// <summary>
        /// 许可证图片
        /// </summary>
        public string ImagePermitlicense { get; set; }

        public string VaildCode { get; set; }

    }

}
