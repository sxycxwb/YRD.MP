using System;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 订单列表
    /// </summary>
    public class ExOrder
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDate;

        /// <summary>
        /// 序号
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 餐桌名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 点餐方式
        /// </summary>
        public string SpotType { get; set; }
        /// <summary>
        /// 结账金额
        /// </summary>
        public decimal OutMoney { get; set; }
        /// <summary>
        /// 结账次数
        /// </summary>
        public int OutCount { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 成交时间
        /// </summary>
        public string FlishTime { get; set; }
        /// <summary>
        /// 订单号码
        /// </summary>
        public string OrderNo { get; set; }
        /// <summary>
        /// 挂账人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 挂账手机
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 还款方式
        /// </summary>
        public string BackType { get; set; }
        /// <summary>
        /// 还款时间
        /// </summary>
        public string BackTime { get; set; }
        /// <summary>
        /// 还款金额
        /// </summary>
        public decimal BackMoney { get; set; }
        /// <summary>
        /// 预定来源(预定列表)
        /// </summary>
        public string OrderSource { get; set; }
        /// <summary>
        /// 手机号(预定列表)
        /// </summary>

        public string Phone { get; set; }
        /// <summary>
        /// 人数(预定列表)
        /// </summary>
        public string PeopleNumber { get; set; }
        /// <summary>
        /// 押金(预定列表)
        /// </summary>
        public string Money { get; set; }
        /// <summary>
        /// 回复时间(预定列表)
        /// </summary>
        public string ReplayTime { get; set; }
        /// <summary>
        /// 就餐时间(预定列表)
        /// </summary>
        public string DiningTime { get; set; }
        /// <summary>
        /// 预定人(预定列表)
        /// </summary>
        public string Man { get; set; }
        /// <summary>
        /// 备注(预定列表)
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 取消时间
        /// </summary>
        public string CancellationTime { get; set; }
        /// <summary>
        /// 是否退单 0不是
        /// </summary>
        public int RefundState { get; set; }
        /// <summary>
        /// 是否外卖 0不是
        /// </summary>
        public int IsTakeOut { get; set; }
        /// <summary>
        /// 挂账金额
        /// </summary>
        public decimal GzMOney { get; set; }
        /// <summary>
        /// 挂账状态
        /// </summary>
        public string GzState { get; set; }
        /// <summary>
        /// 挂账支付方式
        /// </summary>
        public string GzPayState { get; set; }
        /// <summary>
        /// 挂账支付时间
        /// </summary>
        public string GzPayTime { get; set; }
        /// <summary>
        /// 订单类型1、正常点餐 2、外卖 3、挂账
        /// </summary>
        public int orderType { get; set; }


     
    }
}