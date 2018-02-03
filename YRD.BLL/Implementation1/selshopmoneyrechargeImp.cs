using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;
using YRD.Model.DataModels;
using YRD.Model.DomainModels;

namespace YRD.BLL
{
    public class selshopjinbirechargeImp : EFRepositoryBase<selshopjinbirecharge>
    {
        /// <summary>
        /// 添加充值记录
        /// </summary>
        /// <param name="uguid"></param>
        /// <param name="data"></param>
        /// <param name="paymode">支付方式</param> 
        /// <param name="origin"></param> 
        /// <returns></returns>
        public NewBase<ExAddRecharge> AddRecharge(string shopid, string managerid, decimal data, int paymode, int origin)
        {
            NewBase<ExAddRecharge> b = new NewBase<ExAddRecharge>();
            b.Data = new ExAddRecharge();
            try
            {
                DateTime now = DateTime.Now;
                using (var db = new EFContext())
                {
                    selshopjinbirecharge recharge = new selshopjinbirecharge();
                    recharge.ID = WebTools.getGUID();
                    recharge.ShopID = shopid;
                    recharge.ManagerID = managerid;
                    recharge.Data = data;
                    recharge.DT = now;
                    recharge.Status = 0;
                    recharge.Mode = paymode;
                    recharge.Origin = origin;
                    recharge.IsAvailable = true;

                    recharge.BatchId = BatchHelper.GetBatchId;
                    recharge.Contents = data.ToString();

                    db.selshopjinbirecharge.Add(recharge);

                    syspayhistory payhistory = new syspayhistory()
                    {
                        OrderMode = 1,
                        OrderNumber = recharge.ID,
                        CreateTime = now,
                        Status = 0,
                        BatchId = recharge.BatchId,
                        Price = data

                    };
                    db.syspayhistory.Add(payhistory);

                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "充值订单已提交，请确认后进行付款操作";
                    b.Data.Id = recharge.ID;
                    b.Data.BatchId = recharge.BatchId;
                }
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = ConstantHelper.Failure;
                b.Description = Exc.ToString();
            }
            return b;
        }

        /// <summary>
        /// 取消充值记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Base CancelRecharge(int id)
        //{
        //    Base b = new Base();
        //    try
        //    {
        //        using (var db = new ncpEntities())
        //        {
        //            ncp_jinbirecharge recharge = db.ncp_jinbirecharge.FirstOrDefault(a => a.ID == id);
        //            if (recharge != null)
        //            {
        //                recharge.IsAvailable = false;
        //                db.SaveChanges();
        //            }
        //            b.Code = 1;
        //            b.Message = ConstantHelper.Success;
        //        }
        //    }
        //    catch (Exception Exc)
        //    {
        //        b.Code = 0;
        //        b.Message = ConstantHelper.Failure;
        //        b.Description = Exc.ToString();
        //    }
        //    return b;
        //}


        /// <summary>
        /// 获取充值记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Base RechargeDetail(int id)
        //{
        //    NewBase<ExJinbiCharge> b = new NewBase<ExJinbiCharge>();
        //    try
        //    {
        //        using (var db = new ncpEntities())
        //        {
        //            ncp_jinbirecharge recharge = db.ncp_jinbirecharge.FirstOrDefault(a => a.ID == id);
        //            if (recharge == null)
        //            {
        //                b.Code = 0;
        //                b.Message = "该充值记录不存在！";
        //            }
        //            else
        //            {
        //                b.Code = 1;
        //                b.Message = ConstantHelper.Success;

        //                ExJinbiCharge ex = new ExJinbiCharge();
        //                ex.ID = recharge.ID;
        //                ex.UserId = recharge.UserId;
        //                ex.Data = recharge.Data;
        //                ex.DT = recharge.DT;
        //                ex.Origin = recharge.Origin;
        //                ex.paytype = recharge.PayType;
        //                ex.RechargeType = recharge.RechargeType;
        //                ex.BatchId = recharge.BatchId;
        //                ex.UserName = string.Empty;
        //                b.Data = ex;
        //            }
        //        }
        //    }
        //    catch (Exception Exc)
        //    {
        //        b.Code = 0;
        //        b.Message = ConstantHelper.Failure;
        //        b.Description = Exc.ToString();
        //    }
        //    return b;
        //}


        /// <summary>
        /// 确认充值成功 支付宝充值回调使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Base ConfirmAddRechargeByBatchId(string batchid)
        {
            Base b = new Base();
            try
            {
                using (var db = new EFContext())
                {


                    selshopjinbirecharge recharge = db.selshopjinbirecharge.FirstOrDefault(a => a.BatchId == batchid);

                    if (recharge == null)
                    {
                        b.Code = 0;
                        b.Message = "无效的充值记录！";
                        return b;

                    }



                    selshopjinbiaccount jinbiaccount = db.selshopjinbiaccount.FirstOrDefault(a => a.ShopID == recharge.ShopID);

                    if (jinbiaccount == null)
                    {
                        b.Code = 0;
                        b.Message = "无效的帐户，请联系管理员！";
                        return b;
                    }

                    if (recharge.Status == 1)
                    {
                        b.Code = 1;
                        b.Message = "充值成功！";
                        return b;
                    }

                    decimal oldjinbi = 0;
                    decimal jinbi = 0;
                    decimal newjinbi = 0;
                    var ordernumber = recharge.ID.ToString();
                    DateTime now = DateTime.Now;

                    oldjinbi = jinbiaccount.Jinbi;
                    jinbi = recharge.Data;
                    newjinbi = oldjinbi + jinbi;
                    jinbiaccount.Jinbi = newjinbi;

                    selshopjinbidetail jinbidetail = new selshopjinbidetail()
                    {
                        OrderNumber = ordernumber,
                        Type = 1,
                        Before = oldjinbi,
                        Data = jinbi,
                        Sign = 1,
                        After = newjinbi,
                        BatchId = batchid,
                        DT = now,
                        ShopID = recharge.ShopID,
                        IsAuto = false,
                        Remark = "用户在线充值",
                        Description = string.Format("用户在线充值,结余：{0}", newjinbi),
                    };


                    db.selshopjinbidetail.Add(jinbidetail);

                    ///充值成功
                    recharge.Status = 1;
                    recharge.ConfirmDT = now;



                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = ConstantHelper.Success;
                }
            }
            catch (Exception Exc)
            {
                b.Code = 0;
                b.Message = ConstantHelper.Failure;
                b.Description = Exc.ToString();
            }
            return b;
        }

    }
}

