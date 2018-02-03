using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 订单详情表
    /// </summary>
    public class ExCusorderFooddetail
    {
        /// <summary>
        /// 订单详情表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 菜品价格
        /// </summary>
        public decimal FoodPrice { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int FoodCount { get; set; }
        /// <summary>
        /// 退菜数量
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 菜品名称或者固定费用名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 菜品类型ID
        /// </summary>
        public string FoodTypeID { get; set; }
        /// <summary>
        /// 菜品添加类型（1正常点菜2赠送3退菜
        /// </summary>
        public int AddType { get; set; }
        /// <summary>
        /// 上菜状态（1制作中2已上菜3部分上
        /// </summary>
        public int MakeType { get; set; }
  
        /// <summary>
        /// 已上数量
        /// </summary>
        public int MakeCount { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string GGName { get; set; }

        public string State { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string SyName { get; set; }
        /// <summary>
        /// 菜品ID
        /// </summary>
        public string FoodID { get; set; }

    }
}
