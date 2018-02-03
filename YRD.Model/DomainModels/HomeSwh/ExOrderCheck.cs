using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.SwhModels
{
    /// <summary>
    /// 库存简易数据列表
    /// </summary>
    public class ExOrderCheck
    {
        /// <summary>
        /// 申请表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 申请人ID
        /// </summary>
        public string ApplySellerID { get; set; }

        /// <summary>
        /// 申请人名字
        /// </summary>
        public string ApplySellerName { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>

        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 盘点时间
        /// </summary>
        public string OperationTime { get; set; }

        /// <summary>
        /// 盘点用户编号
        /// </summary>
        public string OperationSellerID { get; set; }
        /// <summary>
        /// 盘点用户名
        /// </summary>

        public string OperationSellerName { get; set; }

        /// <summary>
        /// 库房编号
        /// </summary>
        public string WarehourseID { get; set; }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string WareHourseName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int OrderState { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Introduction { get; set; }
    }

    /// <summary>
    /// 库存盘点详情数据列表
    /// </summary>
    public class ExOrderCheckDetail
    {
        /// <summary>
        /// 仓库盘点申请表详情ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 材料ID
        /// </summary>
        public string MaterialID { get; set; }
        /// <summary>
        /// 材料名称
        /// </summary>
        public string MaterialName { get; set; }
        /// <summary>
        /// 材料单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 材料包装名称
        /// </summary>
        public string MaterialPackUnitName { get; set; }
        /// <summary>
        /// 材料品牌名称
        /// </summary>
        public string MaterialBrandName { get; set; }
        /// <summary>
        /// 材料类型名称
        /// </summary>
        public string MaterialTypeName { get; set; }
        /// <summary>
        /// 单位统计数量
        /// </summary>
        public decimal UnitCountBudget { get; set; }
        /// <summary>
        /// 单位实际数量
        /// </summary>
        public decimal UnitCountReal { get; set; }
        /// <summary>
        /// 整包统计数量
        /// </summary>
        public decimal WholeCountBudget { get; set; }
        /// <summary>
        /// 整包实际数量
        /// </summary>
        public decimal WholeCountReal { get; set; }
        /// <summary>
        /// 零散统计数量
        /// </summary>
        public decimal ZeroCountBudget { get; set; }
        /// <summary>
        /// 零散实际数量
        /// </summary>
        public decimal ZeroCountReal { get; set; }
        /// <summary>
        /// 材料平均价格
        /// </summary>
        public decimal AveragePrice { get; set; }
    }
}
