﻿//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRD.Dao
{
    using System;
    using System.Collections.Generic;
    
    public partial class cususercollectfood
    {
        /// <summary>
        /// 用户菜品收藏表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 菜品ID
        /// </summary>
        public string FoodID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public System.DateTime CreateTime { get; set; }
    }
}


