using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 材料
    /// </summary>
    public class ViewMaterialType
    {
        /// <summary>
        /// 店铺仓库材料分类表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 分类名
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 材料分类父ID
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 材料分类父名称
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }


    }

}
