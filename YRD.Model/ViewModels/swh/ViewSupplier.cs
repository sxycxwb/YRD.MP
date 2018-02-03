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
    public class ViewSupplier
    {
        /// <summary>
        /// 仓库材料供应商表ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 供货类别编号
        /// </summary>
        public string SupplierTypeID { get; set; }
        /// <summary>
        /// name
        /// </summary>
        public string SupplierTypeName { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 简介
        /// </summary>
        public string Introduction { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string LinkPhone { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string AddressInfo { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
        /// <summary>
        /// 供应商欠款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 固话区号
        /// </summary>
        public string FixedCode { get; set; }
        /// <summary>
        /// 固话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 微信账号
        /// </summary>
        public string WeiXinPay { get; set; }
        /// <summary>
        /// 支付宝账号
        /// </summary>
        public string AliPay { get; set; }
        /// <summary>
        /// 开户名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankNo { get; set; }
        /// <summary>
        ///  开户行
        /// </summary>

        public string BankDeposit { get; set; }

    }

}
