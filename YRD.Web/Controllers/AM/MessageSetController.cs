using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRD.Dao;
using YRD.Model.DomainModels;
using YRD.Model.EnumModels;
using YRD.Model.ViewModels; 

namespace YRD.Web.Controllers
{
    /// <summary>
    /// 账户管理--短信设置
    /// </summary>
    public class MessageSetController : BaseController
    {

        #region 短信设置
        [Authorization(1116)]
        public ActionResult AddMessageSet()
        {
            using (var db = new EFContext())
            {
                ViewMessageSet model = new ViewMessageSet();
                var e = db.selshopsmsset.FirstOrDefault(x => x.ShopID == ShopId);
                if (e != null)
                {
                    model.ShopID = e.ShopID;
                    model.Day = e.Day;
                    model.Hour = e.Hour;
                    model.Minute = e.Minute;
                    model.SmsBirthdayAccept = e.SmsBirthdayAccept;
                    model.SmsShopAccept = e.SmsShopAccept;
                    model.SmsUserAccept = e.SmsUserAccept;
                }
                return View(model);
            }

        }

        [HttpPost]
        public ActionResult SaveMessageSet(FormCollection form)
        {
            var SmsBirthdayAccept = form.Get("SmsBirthdayAccept");
            int _SmsBirthdayAccept = 0;
            int.TryParse(SmsBirthdayAccept, out _SmsBirthdayAccept);

            var Day = form.Get("Day");
            int _Day = 0;
            int.TryParse(Day, out _Day);

            var Hour = form.Get("Hour");
            int _Hour = 0;
            int.TryParse(Hour, out _Hour);

            var Minute = form.Get("Minute");
            int _Minute = 0;
            int.TryParse(Minute, out _Minute);

            var SmsShopAccept = form.Get("SmsShopAccept");
            int _SmsShopAccept = 0;
            int.TryParse(SmsShopAccept, out _SmsShopAccept);

            var SmsUserAccept = form.Get("SmsUserAccept");
            int _SmsUserAccept = 0;
            int.TryParse(SmsUserAccept, out _SmsUserAccept);

            ViewBase b = new ViewBase();

            using (var db = new EFContext())
            {
                var entity = db.selshopsmsset.FirstOrDefault(x => x.ShopID == ShopId);
                if (entity == null)
                {
                    entity = new selshopsmsset();
                    entity.ShopID = ShopId;
                    entity.SmsBirthdayAccept = _SmsBirthdayAccept;
                    entity.Day = _Day;
                    entity.Hour = _Hour;
                    entity.Minute = _Minute;
                    entity.SmsShopAccept = _SmsShopAccept;
                    entity.SmsUserAccept = _SmsUserAccept;
                    db.selshopsmsset.Add(entity);
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "操作成功";
                }
                else
                {
                    entity.SmsBirthdayAccept = _SmsBirthdayAccept;
                    entity.Day = _Day;
                    entity.Hour = _Hour;
                    entity.Minute = _Minute;
                    entity.SmsShopAccept = _SmsShopAccept;
                    entity.SmsUserAccept = _SmsUserAccept;
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "修改成功";
                }
            }

            if (b.IsSuccess)
            {
                b.Url = "/MessageSet/AddMessageSet";  //成功后跳转
                b.Message = "操作成功";
            }

            return Json(b);
        }
        #endregion

    }
}