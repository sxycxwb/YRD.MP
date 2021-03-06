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
    
    public partial class cusloguserlevelchange
    {
        /// <summary>
        /// 用户等级变化表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 所属用户ID
        /// </summary>
        public string UserID { get; set; }
        /// <summary>
        /// 变化类型（1升级2降级）
        /// </summary>
        public Nullable<int> ChangeType { get; set; }
        /// <summary>
        /// 变化后的等级ID
        /// </summary>
        public string ChangeToLevelID { get; set; }
        /// <summary>
        /// 变化名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 添加日期
        /// </summary>
        public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
    }
}


