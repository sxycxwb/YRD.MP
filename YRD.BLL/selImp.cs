using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;
using YRD.Model.DataModels;

namespace YRD.BLL
{
    public class selImp
    {
        #region 集合

        private List<Ex> sexList;
        /// <summary>
        /// 性别集合
        /// </summary>
        public List<Ex> SexList
        {
            get
            {
                if (sexList == null)
                {
                    sexList = new List<Model.DataModels.Ex>()
                    {
                        new Ex(){ ID=0,Name="女"},
                        new Ex(){ ID=1,Name="男"}
                    };
                }
                return sexList;
            }

        }
        private List<Ex> foodprintRule;
        /// <summary>
        /// 传菜打印规则集合
        /// </summary>
        public List<Ex> FoodPrintRule
        {
            get
            {
                if (foodprintRule == null)
                {
                    foodprintRule = new List<Ex>()
                    {
                        new Ex(){ ID=0,Name="不需要打印"},
                        new Ex(){ ID=1,Name="按单品打印"},
                        new Ex(){ ID=2,Name="按订单打印"}
                    };
                }
                return foodprintRule;
            }

        }

        private List<Ex> shoppropertyList;
        /// <summary>
        /// 店铺类型
        /// </summary>
        public List<Ex> ShopPropertyList
        {
            get
            {
                if (shoppropertyList == null)
                {
                    shoppropertyList = new List<Ex>()
                    {
                        new Ex(){ ID=1,Name="独立店铺"},
                        new Ex(){ ID=2,Name="直营店铺"},
                        new Ex(){ ID=3,Name="加盟店铺"}
                    };
                }
                return shoppropertyList;
            }

        }

        private List<Ex> paytypeList;
        /// <summary>
        /// 支付方式
        /// </summary>
        public List<Ex> PayTypeList
        {
            get
            {
                if (paytypeList == null)
                {
                    paytypeList = new List<Ex>()
                    {
                        new Ex(){ ID=2,Name="支付宝"},
                        new Ex(){ ID=3,Name="微信"}
                    };
                }
                return paytypeList;
            }

        }

        private List<Ex> sendstateList;
        /// <summary>
        /// 发送方式
        /// </summary>
        public List<Ex> SendStateList
        {
            get
            {
                if (sendstateList == null)
                {
                    sendstateList = new List<Ex>()
                    {
                        new Ex(){ ID=0,Name="未发送"},
                        new Ex(){ ID=1,Name="已发送"},
                        new Ex(){ ID=2,Name="发送失败"}
                    };
                }
                return sendstateList;
            }

        }

        private List<Ex> fixedcostType;

        public List<Ex> FixedCostType
        {
            get
            {
                if (fixedcostType == null)
                {
                    fixedcostType = new List<Ex>()
                    {
                        new Ex(){ ID=1,Name="按人数"},
                        new Ex(){ ID=2,Name="按餐桌"},
                        new Ex(){ ID=3,Name="按房间"},
                        new Ex(){ ID=255,Name="其他费用"}
                    };
                }
                return fixedcostType;
            }

        }

        private List<Ex> messagemoneyType;

        public List<Ex> MessageMoneyType
        {
            get
            {
                if (messagemoneyType == null)
                {
                    messagemoneyType = new List<Ex>()
                    {
                        new Ex(){ ID=2000,Name="0.01"},
                        new Ex(){ ID=5000,Name="0.02"},
                        new Ex(){ ID=10000,Name="0.03"}
                    };
                }
                return messagemoneyType;
            }

        }
        #endregion

        public string SexName(int sex)
        {
            string sexname = "女";
            if (sex == 1)
            {
                sexname = "男";
            }
            return sexname;
        }

        public string DelName(int isdel)
        {
            string delname = "正常";
            if (isdel == 1)
            {
                delname = "锁定";
            }
            return delname;

        }
        public string CardTypeName(string cardtypecode)
        {
            string cardtypename = "未命名";

            switch (cardtypecode)
            {
                case "1":
                    cardtypename = "充值卡";
                    break;
                case "2":
                    cardtypename = "打折卡";
                    break;
                case "3":
                    cardtypename = "特惠卡";
                    break;
                case "4":
                    cardtypename = "专享卡";
                    break;
                case "5":
                    cardtypename = "记次卡";
                    break;
                default:
                    cardtypename = "未命名";

                    break;
            }
            return cardtypename;

        }

        /// <summary>
        /// 订单状态转换成订单名称
        /// </summary>
        /// <param name="orderstate"></param>
        /// <returns></returns>
        public string OrderStateName(int orderstate)
        {
            string orderstatename = "";
            //1提交审核2审核未通过3审核通过4整单入库提交完成5分单入库提交未完成6分单入库提交已完成10库管签名订单完成
            switch (orderstate)
            {
                case 1:
                    orderstatename = "提交审核";
                    break;
                case 2:
                    orderstatename = "审核未通过";
                    break;
                case 3:
                    orderstatename = "审核通过";
                    break;
                case 4:
                    orderstatename = "整单入库提交完成";
                    break;
                case 5:
                    orderstatename = "分单入库提交未完成";
                    break;
                case 6:
                    orderstatename = "分单入库提交已完成";
                    break;
                case 10:
                    orderstatename = "库管签名订单完成";
                    break;
                default:
                    orderstatename = "";
                    break;
            }
            return orderstatename;

        }


        public string MoneyTypeName(int moneytype)
        {
            string moneytypename = "";
            //付款详情方式（1进货2退货 3付款单4收款单）
            switch (moneytype)
            {
                case 1:
                    moneytypename = "进货";
                    break;
                case 2:
                    moneytypename = "退货";
                    break;
                case 3:
                    moneytypename = "付款单";
                    break;
                case 4:
                    moneytypename = "收款单";
                    break;
                
                default:
                    moneytypename = "";
                    break;
            }
            return moneytypename;
        }

    }
}

