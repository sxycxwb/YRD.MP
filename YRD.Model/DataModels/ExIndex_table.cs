using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
   public  class ExIndex_table
    {
        /// <summary>
        /// 是否预定(0否1是)
        /// </summary>
        public int isReserver { get; set; }
        /// <summary>
        /// 店铺餐桌表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 餐桌名
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 餐桌状态(1空闲2正在使用3已预订4维护中5其他状态)
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 所属房间
        /// </summary>
        public string SelRoomID { get; set; }
        /// <summary>
        /// 所属店铺
        /// </summary>
        public string SelShopID { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string OrderPhone { get; set; }
        /// <summary>
        /// 预定金额或者订单金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderTime { get; set; }
        /// <summary>
        /// 最大人数
        /// </summary>
        public int MaxPeople { get; set; }
        /// <summary>
        /// 用餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 支付状态
        /// </summary>
        public int PayState { get; set; }
        /// <summary>
        /// 优惠字符串
        /// </summary>
        public string DiscountStr { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal Dismoney { get; set; }
        /// <summary>
        /// 折后金额
        /// </summary>
        public decimal TruePrice { get; set; }
        /// <summary>
        /// 是否下单不起菜
        /// </summary>
        public int IsNoUpFood { get; set; }
        /// <summary>
        /// 结账时间
        /// </summary>
        public DateTime EnDateTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 订单来源(1APP点餐2扫码点餐3吧台点餐4服务员点餐)
        /// </summary>
        public string OrderSource { get; set; }
        /// <summary>
        /// 区域Id
        /// </summary>
        public string DepatchId { get; set; }
        /// <summary>
        /// 菜品数量
        /// </summary>
        public int FoodCount { get; set; }
    }
}
