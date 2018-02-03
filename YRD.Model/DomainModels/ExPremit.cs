using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 获取操作员的权限菜单
    /// </summary>
    public class ExPremit
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// action名
        /// </summary>
        public string AName { get; set; }
        /// <summary>
        /// 控制器名
        /// </summary>
        public string CName { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImgUrl { get; set; }
        /// <summary>
        /// 菜单链接地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
    }
}
