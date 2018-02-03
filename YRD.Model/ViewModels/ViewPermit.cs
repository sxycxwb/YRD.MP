using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewPemit
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 父权限编号
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public int IsDel { get; set; }

        public int PemitType { get; set; }

        public string PemitState { get; set; }

        public string Url { get; set; }

        public string ImgUrl { get; set; }
        public int Sort { get; set; }


    }
}
