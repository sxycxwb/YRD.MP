using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;
using YRD.Model;

namespace YRD.BLL
{
    public class swhorderlossrateImp : EFRepositoryBase<swhorderlossrate>
    {
        public NewBase<decimal> getMoneySumBudget(string id)
        {
            var ba = new NewBase<decimal>();
            try
            {
                using (var db = new EFContext())
                {
                    //通过材料ID获得材料信息
                    var model = db.swhorderlossratedetail.Where(m => m.OrderApplyID == id)
                        .Select(a => new { a.PriceReal, a.CountLoss })
                        .Sum(a => a.PriceReal * a.CountLoss);
                    ba.Data = model;
                    ba.setSuccess("获取数据成功");
                }
            }
            catch (Exception e)
            {
                var m = WebTools.getFinalException(e);
                ba.setFail("操作失败", m);
                LogHelper.Error("getMoneySumBudget：" + m);
            }
            return ba;
        }
        private NewBase<ExOrderLossRateAll> getOrderBase(PaID pa, bool? isCheck = null)
        {
            var ba = new NewBase<ExOrderLossRateAll>();
            try
            {
                Tools.PrintPa<PaID>(pa);
                using (var db = new EFContext())
                {
                    var model = db.swhorderlossrate.FirstOrDefault(a => a.ID == pa.ID);
                    ba.Data = new ExOrderLossRateAll
                    {
                        ID = model.ID,
                        ApproveContents = model.ApproveContents,
                        ApproveTime = model.ApproveTime,
                        OrderState = model.OrderState,
                        PriceReal = model.PriceReal,
                        ApproveSellerID = model.ApproveSellerID,
                        ApplySellerID = model.ApplySellerID,
                        CreateDate = model.CreateDate,
                        CreateTime = model.CreateTime,
                        Introduction = model.Introduction, 
                        ShopID = model.ShopID,
                        Title = model.Title,
                        WareHouseID = model.WareHouseID,
                        WareHouseName = Tools.getWareHouseName(db, model.WareHouseID)
                    };
                    var n = Tools.getManagerNameAndRole(db, model.ApplySellerID);
                    ba.Data.ApplySellerName = n.Data;
                    ba.Data.ApplySellerRole = n.Data2;

                    if (model.ApproveSellerID.IsNotNull()) //这里都查出来吧
                    {
                        var n2 = Tools.getManagerNameAndRole(db, model.ApproveSellerID);
                        ba.Data.ApplySellerName = n2.Data;
                        ba.Data.ApplySellerRole = n2.Data2;
                        ba.Data.ApproveContents = model.ApproveContents;
                        ba.Data.ApproveTime = model.ApproveTime;
                    }
                    ba.setSuccess("获取数据成功");
                    return ba;
                }
            }
            catch (Exception e)
            {
                var m = WebTools.getFinalException(e);
                ba.setFail("获取数据失败", m);
                LogHelper.Error("获取数据失败：" + m);
            }
            return ba;
        }

        public PageListWithPaging<ExOrderLossRateDetail> getDetailBase(PaPageList_ID model)
        {
            var ba = new PageListWithPaging<ExOrderLossRateDetail>(model.PageIndex, model.PageSize);
            try
            { 
                using (var db = new EFContext())
                {
                    var q = from a in db.swhorderlossratedetail.Where(a => a.OrderApplyID == model.ID)
                            join b in db.swhmaterial on a.MaterialID equals b.ID
                            orderby a.CreateTime
                            select new ExOrderLossRateDetail
                            {
                                ID = a.ID,
                                MaterialName = a.MaterialName,
                                SpecName = a.MaterialSpecName,
                                MaterialUnitName = a.MaterialUnitName,
                                CountLoss = a.CountLoss,
                                MaterialID = a.MaterialID,
                                MaterialUnitID = a.MaterialUnitID,
                                OrderApplyID = a.OrderApplyID,
                                WareHouseName = a.WareHouseName,
                                WareHouseID = a.WareHouseName, 
                                UnitScale = a.UnitScale, 
                            };
                    var list = q.Skip(model.PageSize * (model.PageIndex - 1))
                        .Take(model.PageSize)
                        .ToList();
                    foreach (var item in list)
                    {
                        item.StockCount = db.swhstockaccount.Where(t => t.MaterialID == item.MaterialID).Select(t => t.CountMainReal).ToList().Sum() / item.UnitScale;
                    }
                    ba.List = list;
                    ba.RecordCount = q.EFCount();
                    ba.setSuccess("获取数据成功");
                    return ba;
                }
            }
            catch (Exception e)
            {
                var m = WebTools.getFinalException(e);
                ba.setFail("获取数据失败", m);
                LogHelper.Error("获取数据失败：" + m);
            }
            return ba;
        }
    }
}

