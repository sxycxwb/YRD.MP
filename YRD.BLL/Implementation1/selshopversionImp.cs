using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;

namespace YRD.BLL
{
    public class selshopversionImp : EFRepositoryBase<selshopversion>
    {
        /// <summary>
        /// 确认支付成功 支付宝支付回调使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //public Base ConfirmShopVersionByBatchId(string batchid)
        //{
        //    Base b = new Base();
        //    try
        //    {
        //        using (var db = new EFContext())
        //        {

        //            selshopversion recharge = db.selshopversion.FirstOrDefault(a => a.BatchId == batchid);

        //            if (recharge == null)
        //            {
        //                b.Code = 0;
        //                b.Message = "无效的支付记录！";
        //                return b;
        //            }
        //            selshop selshopmodel = db.selshop.FirstOrDefault(a => a.ID == recharge.ShopID);

        //            if (selshopmodel == null)
        //            {
        //                b.Code = 0;
        //                b.Message = "无效的帐户，请联系管理员！";
        //                return b;
        //            }

        //            sysversion sysversionmodel = db.sysversion.FirstOrDefault(x => x.VersionID == recharge.VersionID);

        //            if (recharge.Status == 1)
        //            {
        //                b.Code = 1;
        //                b.Message = "支付成功！";
        //                return b;
        //            }
        //            var ordernumber = recharge.ID.ToString();
        //            DateTime now = DateTime.Now;

        //            if (recharge.VersionID == "2")
        //            {
        //                if (selshopmodel.ShopVipTypeID == recharge.VersionID)
        //                {
        //                    // selshopmodel.StartTime = recharge.StartTime;
        //                    selshopmodel.EndTime = recharge.EndTime;
        //                }
        //                else
        //                {
        //                    selshopmodel.StartTime = recharge.StartTime;
        //                    selshopmodel.EndTime = recharge.EndTime;
        //                    selshopmodel.ShopVipTypeID = recharge.VersionID;
        //                }




        //                #region 配置角色 
        //                //查找到老板对应的角色
        //                var selmanager_rolemodel = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selshopmodel.OwnSellerID);
        //                if (selmanager_rolemodel != null)
        //                {
        //                    //添加角色-权限关系表

        //                    var listPemit = db.selpemit.Where(x => x.PemitState.Contains("2")).ToList();

        //                    foreach (var item in listPemit)
        //                    {
        //                        var gxrp = db.selrole_pemit.FirstOrDefault(x => x.SelPemitID == item.ID && x.SelRoleID == selmanager_rolemodel.SelRoleID);
        //                        if (gxrp == null)
        //                        {
        //                            gxrp = new selrole_pemit();
        //                            gxrp.ID = System.Guid.NewGuid().ToString("N");
        //                            gxrp.SelPemitID = item.ID;
        //                            gxrp.SelRoleID = selmanager_rolemodel.SelRoleID;
        //                            db.selrole_pemit.Add(gxrp);
        //                        }

        //                    }
        //                }
        //                #endregion


        //            }
        //            else if (recharge.VersionID == "3")
        //            {
        //                if (selshopmodel.ShopVipTypeID == recharge.VersionID)
        //                {
        //                    // selshopmodel.StartTime = recharge.StartTime;
        //                    selshopmodel.EndTime = recharge.EndTime;
        //                }
        //                else
        //                {
        //                    selshopmodel.StartTime = recharge.StartTime;
        //                    selshopmodel.EndTime = recharge.EndTime;
        //                    selshopmodel.ShopVipTypeID = recharge.VersionID;
        //                }
        //                #region 配置角色 
        //                //查找到老板对应的角色
        //                var selmanager_rolemodel = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selshopmodel.OwnSellerID);
        //                if (selmanager_rolemodel != null)
        //                {
        //                    //添加角色-权限关系表

        //                    var listPemit = db.selpemit.Where(x => x.PemitState.Contains("2")).ToList();

        //                    foreach (var item in listPemit)
        //                    {
        //                        var gxrp = db.selrole_pemit.FirstOrDefault(x => x.SelPemitID == item.ID && x.SelRoleID == selmanager_rolemodel.SelRoleID);
        //                        if (gxrp == null)
        //                        {
        //                            gxrp = new selrole_pemit();
        //                            gxrp.ID = System.Guid.NewGuid().ToString("N");
        //                            gxrp.SelPemitID = item.ID;
        //                            gxrp.SelRoleID = selmanager_rolemodel.SelRoleID;
        //                            db.selrole_pemit.Add(gxrp);
        //                        }
        //                    }
        //                }
        //                #endregion
        //            }
        //            else if (recharge.VersionID == "4")
        //            {
        //                if (selshopmodel.ShopVipTypeID == recharge.VersionID)
        //                {
        //                    // selshopmodel.StartTime = recharge.StartTime;
        //                    selshopmodel.EndTime = recharge.EndTime;
        //                }
        //                else
        //                {
        //                    selshopmodel.StartTime = recharge.StartTime;
        //                    selshopmodel.EndTime = recharge.EndTime;
        //                    selshopmodel.ShopVipTypeID = recharge.VersionID;
        //                }
        //                #region 配置角色 
        //                //查找到老板对应的角色
        //                var selmanager_rolemodel = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == selshopmodel.OwnSellerID);
        //                if (selmanager_rolemodel != null)
        //                {
        //                    //添加角色-权限关系表

        //                    var listPemit = db.selpemit.Where(x => x.PemitState.Contains("2")).ToList();

        //                    foreach (var item in listPemit)
        //                    {
        //                        var gxrp = db.selrole_pemit.FirstOrDefault(x => x.SelPemitID == item.ID && x.SelRoleID == selmanager_rolemodel.SelRoleID);
        //                        if (gxrp == null)
        //                        {
        //                            gxrp = new selrole_pemit();
        //                            gxrp.ID = System.Guid.NewGuid().ToString("N");
        //                            gxrp.SelPemitID = item.ID;
        //                            gxrp.SelRoleID = selmanager_rolemodel.SelRoleID;
        //                            db.selrole_pemit.Add(gxrp);
        //                        }
        //                    }
        //                }
        //                #endregion
        //            }

        //            else if (recharge.VersionID == "6")
        //            {

        //                var swhshopstockmodel = db.swhshopstock.FirstOrDefault(x => x.ShopID == recharge.ShopID);
        //                if (swhshopstockmodel == null)
        //                {
        //                    swhshopstockmodel = new swhshopstock();
        //                    swhshopstockmodel.IsBuyStock = 1;
        //                    swhshopstockmodel.StartTime = recharge.StartTime;
        //                    swhshopstockmodel.EndTime = recharge.EndTime;
        //                    db.swhshopstock.Add(swhshopstockmodel);
        //                }
        //                else
        //                {
        //                    swhshopstockmodel.IsBuyStock = 1;
        //                    swhshopstockmodel.StartTime = recharge.StartTime;
        //                    swhshopstockmodel.EndTime = recharge.EndTime;
        //                }
        //            }

        //            //升级成功
        //            recharge.Status = 1;
        //            recharge.ConfirmDT = now;

        //            db.SaveChanges();
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
    }
}

