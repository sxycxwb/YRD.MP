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

    public partial class selpemit
    {
        /// <summary>
        /// 
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 权限名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 权限操作url
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// Url前缀地址 一般都是对应的各项目的地址
        /// </summary>
        public string UrlPrefix { get; set; }
    /// <summary>
    /// 权限图片
    /// </summary>
    public string ImgUrl { get; set; }
    /// <summary>
    /// 权限父ID
    /// </summary>
    public string ParentID { get; set; }
    /// <summary>
    /// 权限父名称
    /// </summary>
    public string ParentTitle { get; set; }
    /// <summary>
    /// 是否是按钮
    /// </summary>
    public int IsMenu { get; set; }
    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTime CreateTime { get; set; }
    /// <summary>
    /// 是否删除
    /// </summary>
    public int IsDel { get; set; }
    /// <summary>
    /// 创建管理员ID
    /// </summary>
    public string CreateManagerID { get; set; }
    /// <summary>
    /// controller名称
    /// </summary>
    public string CName { get; set; }
    /// <summary>
    /// action名称
    /// </summary>
    public string AName { get; set; }
    /// <summary>
    /// 权限类型（1后台2APP3分销）
    /// </summary>
    public int PemitType { get; set; }
    /// <summary>
    /// 权限状态（0默认都可以用的1免费版特有的2微店版3聚餐版4宴会版5分销6云库存）
    /// </summary>
    public string PemitState { get; set; }
}
}


