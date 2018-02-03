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
    
    public partial class cususerleveltype
    {
        /// <summary>
        /// 用户等级类型表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 上一级ID
        /// </summary>
        public string LastID { get; set; }
        /// <summary>
        /// 下一级ID
        /// </summary>
        public string NextID { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public Nullable<int> Sort { get; set; }
        /// <summary>
        /// 经验
        /// </summary>
        public Nullable<int> Exp { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public Nullable<System.DateTime> CreateTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public Nullable<int> IsDel { get; set; }
        /// <summary>
        /// 创建管理员ID
        /// </summary>
        public Nullable<int> CreateManagerID { get; set; }
        /// <summary>
        /// 折扣（95折填写0.95）
        /// </summary>
        public Nullable<double> Discount { get; set; }
        /// <summary>
        /// 标识图标
        /// </summary>
        public string ImageUrl { get; set; }
    }
}


