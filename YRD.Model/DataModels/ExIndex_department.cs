using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 区域
    /// </summary>
   public  class ExIndex_department
    {
       /// <summary>
       /// 序号
       /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
    }
}
