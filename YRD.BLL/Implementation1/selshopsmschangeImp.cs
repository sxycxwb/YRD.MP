using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;

namespace YRD.BLL
{
    public class selshopsmschangeImp : EFRepositoryBase<selshopsmschange>
    {
        /// <summary>
        /// 确认支付成功 支付宝支付回调使用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Base ConfirmShopVersionByBatchId(string batchid)
        {
            Base b = new Base();
            try
            {
                using (var db = new EFContext())
                {

                    selshopsmschange recharge = db.selshopsmschange.FirstOrDefault(a => a.BatchId == batchid);

                    if (recharge == null)
                    {
                        b.Code = 0;
                        b.Message = "无效的支付记录！";
                        return b;
                    }
                    selshop selshopmodel = db.selshop.FirstOrDefault(a => a.ID == recharge.ShopID);

                    if (selshopmodel == null)
                    {
                        b.Code = 0;
                        b.Message = "无效的帐户，请联系管理员！";
                        return b;
                    }

                    if (recharge.Status == 1)
                    {
                        b.Code = 1;
                        b.Message = "支付成功！";
                        return b;
                    }
                    var ordernumber = recharge.ID.ToString();
                    DateTime now = DateTime.Now;
                     

                    //升级成功
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

