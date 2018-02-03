using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    public class ViewWareHouse
    {
        /// <summary>
        /// 店铺仓库表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 仓库名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string SelManagerName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 是否自动出库 1有 0 无
        /// </summary>
        public bool IsAuto { get; set; }
        /// <summary>
        ///  排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 绑定的餐桌，以逗号分隔开的字符串
        /// </summary>
        public string BindTableNames { get; set; }
        /// <summary>
        /// 绑定的餐桌
        /// </summary>
        public List<ViewBindTable> BindTableList { get; set; }
    }
    /// <summary>
    /// 绑定的餐桌
    /// </summary>
    public class ViewBindTable
    {
        public string TableName { get; set; }

        public string TableID { get; set; }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked { get; set; }
    }
}
