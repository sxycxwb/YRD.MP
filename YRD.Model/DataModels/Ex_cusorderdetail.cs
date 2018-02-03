using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 订单详情
    /// </summary>
   public class Ex_cusorderdetail
    {
        public string Border { get; set; }
        /// <summary>
        /// 属性id
        /// </summary>
        public string FoodAttributeID { get; set; }
        /// <summary>
        /// 属性name
        /// </summary>
        public string FoodAttributeName { get; set; }
        /// <summary>
        /// 类别 对应名称的类别 1菜品名称 2套餐名称 3固定费用
        /// </summary>
        public int Type { get; set; }
        public string FoodTypeName { get; set; }
        public string PrintId { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 食品编号
        /// </summary>
        public string FoodID { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string FoodPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int FoodCount { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public string TotalPrice { get; set; }
        /// <summary>
        /// 菜品类型ID
        /// </summary>
        public string FoodTypeID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 订单来源(1远程2扫码3吧台4服务员
        /// </summary>
        public int OrderSource { get; set; }
        public int PayState { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 上菜状态（0临时状态1已下单2制作中3已上菜4部分上）
        /// </summary>
        public int MakeType { get; set; }
        /// <summary>
        /// 规格ID
        /// </summary>
        public string GGId { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string GGName { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 退菜数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AddType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LikeTaste { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NoLikeTaste { get; set; }

        public string State { get; set; }

        public string IsHd { get; set; }
     

    }
}
