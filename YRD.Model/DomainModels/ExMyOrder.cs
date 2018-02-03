using System;
using System.Collections.Generic;
using YRD.Model.DataModels;

namespace YRD.Model.DomainModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ExMyOrder
    {
        public decimal TruePrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreaTime { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string IdKey { get; set; }

        public string TableId { get; set; }
        public string TableName { get; set; }
        /// <summary>
        /// 点菜来源
        /// </summary>
        public string SpotType { get; set; }
        /// <summary>
        /// 菜品价格
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 用餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal YouhuiMoney { get; set; }
        /// <summary>
        /// 优惠字符串
        /// </summary>
        public string YouHuiStr { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int FoodCount { get; set; }
        /// <summary>
        /// 订单详情列表
        /// </summary>
        public List<Ex_cusorderdetail> Orderdetails { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string ShopName { get; set; }
    }
}