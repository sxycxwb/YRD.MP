using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 
    /// </summary>
    public class ExSelfood
    {
        /// <summary>
        /// 店铺菜品表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 菜名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string FoodPrice { get; set; }
        /// <summary>
        /// 剩余库存数量
        /// </summary>
        public int SurplusCount { get; set; }

        /// <summary>
        /// 赠送菜品数量
        /// </summary>
        public int FoodCount { get; set; }
        /// <summary>
        /// 绑定打印机ID
        /// </summary>
        public string PrintId { get; set; }
        /// <summary>
        /// 套餐
        /// </summary>
        //public e package { get; set; }
        public string TypeId { get; set; }
        /// <summary>
        /// 菜品类型id
        /// </summary>
        public string FoodtypeId { get; set; }


    }
}
