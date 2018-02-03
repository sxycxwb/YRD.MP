using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class ViewShopDiscount
    {
        /// <summary>
        /// 店铺优惠表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 会员卡规则名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 满X减Y中的X
        /// </summary>
        public string MoneyX { get; set; }
        /// <summary>
        /// 满X减Y中的Y
        /// </summary>
        public string MoneyY { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 过期时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 折扣
        /// </summary>
        public string MoneyDiscount { get; set; }
        /// <summary>
        /// 店铺优惠类型（1满减2折扣）
        /// </summary>
        public string Type { get; set; }

        public int AllowType { get; set; }


    }
}
