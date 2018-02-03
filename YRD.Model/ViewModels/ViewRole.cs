using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewRole
    {
        /// <summary>
        /// 商家角色表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }

        public List<ViewPemit> ListPemit { get; set; }
    }

 
}
