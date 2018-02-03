using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    public class ViewOrderCheck
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
    /// 入库订单进度
    /// </summary>
    public class ViewOrderCheckProgress
    {
        public string ID { get; set; }
        public string ApplySellerID { get; set; }
        public string ApplySellerName { get; set; }
        public string ApplySellerNickName { get; set; }
        public string CreateTime { get; set; }
        public string OperationTime { get; set; }
        public string OperationSellerID { get; set; }
        public string OperationSellerName { get; set; }
        public string OperationSellerNickName { get; set; }

    }


    /// <summary>
    /// 库存盘点详情数据列表
    /// </summary>
    public class ViewOrderCheckDetail
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
        /// 材料规格名称
        /// </summary>
        public string MaterialSpecName { get; set; }
        /// <summary>
        /// 材料单位名称
        /// </summary>
        public string MaterialUnitName { get; set; }
        /// <summary>
        /// 材料主单位名称
        /// </summary>

        public string MaterialMainUnitName { get; set; }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public decimal CountReal { get; set; }
        /// <summary>
        /// 盘点数量
        /// </summary>

        public decimal CountMainReal { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal CountStock { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>

        public decimal CountMainStock { get; set; }
        /// <summary>
        /// 平均价格
        /// </summary>
        public decimal AveragePrice { get; set; }
        /// <summary>
        /// 盈亏
        /// </summary>

        public decimal ProfitAndLoss { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 材料类型名称
        /// </summary>
        public string MaterialTypeMainName { get; set; }
        /// <summary>
        /// 材料类型名称
        /// </summary>
        public string MaterialTypeChildName { get; set; }

        /// <summary>
        /// 0 不需要校验 1 需要校验
        /// </summary>
        public bool IsNeedCheck { get; set; }

        /// <summary>
        /// 0 未校验 1校验成功 -1校验失败
        /// </summary>
        public int Status { get; set; }

        public string StatusName { get; set; }

    }

}
