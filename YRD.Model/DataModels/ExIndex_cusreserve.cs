using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 用户预定
    /// </summary>
    public class ExIndex_cusreserve:PaBase
    {
        /// <summary>
        /// 用户预定表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 预定店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 就餐时间
        /// </summary>
        public DateTime MealTime { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public string PeopleCount { get; set; }
        /// <summary>
        /// 餐桌ID
        /// </summary>
        public string TableID { get; set; }
        /// <summary>
        /// 餐桌名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 定金
        /// </summary>
        public string DepositPrice { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string CusName { get; set; }
        /// <summary>
        /// 客户手机号
        /// </summary>
        public string CusPhone { get; set; }
        /// <summary>
        /// 是否发送短信（1是0否）
        /// </summary>
        public int IsSms { get; set; }
        /// <summary>
        /// 预定来源（1电话2APP3到店）
        /// </summary>
        public int OrderSource { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public string IDKey { get; set; }
                
    }
}
