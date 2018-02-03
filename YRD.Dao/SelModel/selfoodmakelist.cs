﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;

    public partial class selfoodmakelist
    {
        /// <summary>
        /// 店铺菜品表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 订单ID
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 菜品ID
        /// </summary>
        public string FoodID { get; set; }

        public string ShopID { get; set; }
        /// <summary>
        /// 总数量
        /// </summary>
        public Nullable<int> FoodCount { get; set; }
        /// <summary>
        /// 工作人员ID（厨师）
        /// </summary>
        public string SellerID { get; set; }
        /// <summary>
        /// 菜品名称或者固定费用名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 菜品类型ID
        /// </summary>
        public string FoodTypeID { get; set; }
        /// <summary>
        /// 上菜状态（1制作中2已上菜3部分上）
        /// </summary>
        public Nullable<int> MakeType { get; set; }
        /// <summary>
        /// 店铺菜品表ID
        /// </summary>
        public Nullable<int> MakeCount { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<DateTime> CreateDate { get; set; }
        /// <summary>
        /// 菜品类型名称
        /// </summary>
        public string FoodTypeName { get; set; }
        /// <summary>
        /// 制作全部完成时间
        /// </summary>
        public Nullable<DateTime> MakeCompleteTime { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public Nullable<DateTime> CreateTime { get; set; }
        /// <summary>
        /// 平均一个菜制作时间
        /// </summary>
        public string MakeMinute { get; set; }


    }
}


