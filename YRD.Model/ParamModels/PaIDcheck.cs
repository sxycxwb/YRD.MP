using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 盘点点添加对象
    /// </summary>
    public class PaOrderCheckWithList : PaBase
    {
        /// <summary>
        /// 仓库盘点表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 申请名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 选择的材料列表
        /// </summary>
        public List<ExMaterialSimple> List { get; set; }
        ///// <summary>
        ///// 添加时间
        ///// </summary>
        //public System.DateTime CreateTime { get; set; }
        ///// <summary>
        ///// 添加日期
        ///// </summary>
        //public Nullable<System.DateTime> CreateDate { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        public string ApplySellerID { get; set; }
        /// <summary>
        /// 申请简介
        /// </summary>
        public string Introduction { get; set; }

        /// <summary>
        /// 实际操作人ID
        /// </summary>
        public string OperationSellerID { get; set; }

        /// <summary>
        /// 仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        ///// <summary>
        ///// 是否单位数量统计
        ///// </summary>
        //public int IsUnitCount { get; set; }
        ///// <summary>
        ///// 是否整包数量统计
        ///// </summary>
        //public int IsWholeCount { get; set; }
        ///// <summary>
        ///// 是否零散数量统计
        ///// </summary>
        //public int IsZeroCount { get; set; }
    }
}
