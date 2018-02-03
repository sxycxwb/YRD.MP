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
    /// 账户管理
    /// </summary>
    public class AccountInfoController : BaseController
    {
        #region 商家资料
        [Authorization(1111)]
        public ActionResult AccountCenter()
        {
            ViewAccountCenter model = new ViewAccountCenter();
            model.ImgUrlList = new List<ViewImgUrl>();
            using (var db = new EFContext())
            {
                var f = db.selshop.FirstOrDefault(a => a.ID == ShopId);
                if (f != null)
                {
                    model.ShopTypeID = f.ShopTypeID;
                    model.ShopTypeText = db.selshoptype.FirstOrDefault(a => a.ID == f.ShopTypeID)?.Title;
                    model.ID = f.ID;
                    model.ShopName = f.ShopName;
                    model.Introduction = f.Introduction;
                    model.MapLat = f.MapLat?.ToString();
                    model.MapLng = f.MapLng?.ToString();
                    model.LinkMan = f.LinkMan;
                    model.Phone = f.Phone;
                    model.Tel = f.Tel;
                    model.QQ = f.QQ;
                    model.Email = f.Email;
                    model.ProvinceID = f.ProvinceID;
                    model.ProvinceIDText = db.syschinaarea.FirstOrDefault(x => x.code == f.ProvinceID)?.name;
                    model.CityID = f.CityID;

                    model.CityIDText = db.syschinaarea.FirstOrDefault(x => x.code == f.CityID)?.name;
                    model.CountyID = f.CountyID;

                    model.CountyIDText = db.syschinaarea.FirstOrDefault(x => x.code == f.CountyID)?.name;
                    model.AreaID = f.AreaID;

                    model.AreaIDText = db.syschinaarea.FirstOrDefault(x => x.code == f.AreaID)?.name;
                    model.AddressInfo = f.AddressInfo;
                    model.ManagerAreaType = f.ManagerAreaType;
                    model.CreateManagerID = f.CreateManagerID;
                    model.CreateTime = f.CreateTime.ToString(FormatHelper.DataTimeFormat);

                    model.StartTime = f.StartTime.ToString(FormatHelper.DateFormat);
                    if (f.VersionID == 1)
                    {
                        model.EndTime = "永久免费";
                    }
                    else
                    {
                        model.EndTime = f.EndTime.ToString(FormatHelper.DateFormat);
                    }

                    model.ScaleID = f.ScaleID;
                    model.PropertyID = f.PropertyID;
                    model.PropertyIDText = DB.selImp.Value.ShopPropertyList.FirstOrDefault(x => x.ID.ToString() == f.PropertyID)?.Name;
                    model.OwnSellerID = f.OwnSellerID;

                    model.ListImg = f.ListImg;


                    model.BusinessTimeStartLunch = f.BusinessTimeStartLunch;
                    model.BusinessTimeEndLunch = f.BusinessTimeEndLunch;
                    model.BusinessTimeStartDinner = f.BusinessTimeStartDinner;
                    model.BusinessTimeEndDinner = f.BusinessTimeEndDinner;
                    model.IsCanReserve = f.IsCanReserve ?? 0;
                    model.ShopVipTypeID = f.VersionID.ToString();

                    var ssilist = db.selshopimg.Where(x => x.ShopID == ShopId && x.ImgType == 1).OrderBy(x => x.Sort).Select(x => new ViewImgUrl() { ImgUrl = x.ImgUrl }).ToList();

                    if (ssilist.Any())
                    {
                        model.ImgUrlList = ssilist;
                    }

                    var ssi2 = db.selshopimg.FirstOrDefault(x => x.ShopID == ShopId && x.ImgType == 2);
                    if (ssi2 != null && ssi2.ImgUrl.IsNotNull())
                    {
                        model.ImageBusinesslicence = ssi2.ImgUrl;
                    }
                    else
                    {
                        model.ImageBusinesslicence = string.Empty;
                    }

                    var ssi3 = db.selshopimg.FirstOrDefault(x => x.ShopID == ShopId && x.ImgType == 3);
                    if (ssi3 != null && ssi3.ImgUrl.IsNotNull())
                    {
                        model.ImagePermitlicense = ssi3.ImgUrl;
                    }
                    else
                    {
                        model.ImagePermitlicense = string.Empty;
                    }


                }
            }
            return View(model);
        }
        public ActionResult SaveAccountCenter(ViewAccountCenter model)
        {
            ViewBase b = new ViewBase();
            string id = model.ID;

            if (model.IsCanReserve == 1)
            {
                if (string.IsNullOrEmpty(model.Phone))
                {
                    b.Message = "未输入手机号";
                    return Json(b);
                }
                if (string.IsNullOrEmpty(model.VaildCode))
                {
                    b.Message = "未输入验证码";
                    return Json(b);
                }
            }

            if (string.IsNullOrEmpty(model.LinkMan))
            {
                b.Message = "未输入联系人";
                return Json(b);
            }

            if (string.IsNullOrEmpty(model.Tel))
            {
                b.Message = "未输入吧台电话";
                return Json(b);
            }
            if (model.IsCanReserve == 1)
            {
                string vaildcode = SOLib.SoLogin.ReadCookieVaildCode();
                if (vaildcode.IsNull())
                {
                    b.Message = "验证码已过期，请重新发送验证码";
                    return Json(b);
                }
                if (!model.VaildCode.Equals(vaildcode))
                {
                    b.Message = "验证码错误！";
                    return Json(b);
                }
            }
            if (model.ListImg.IsNull())
            {
                b.Message = "未上传列表图！";
                return Json(b);
            }
            if (model.imgurl.IsNull())
            {
                b.Message = "未上传环境图！";
                return Json(b);
            }

            using (var db = new EFContext())
            {
                try
                {
                    DateTime now = DateTime.Now;

                    selshop selshopModel = db.selshop.FirstOrDefault(x => x.ID == id);
                    if (selshopModel == null)
                    {
                        b.Message = "未找到当前数据";
                        return Json(b);
                    }
                    selshopModel.IsCanReserve = model.IsCanReserve;
                    selshopModel.LinkMan = model.LinkMan;

                    selshopModel.Tel = model.Tel;
                    selshopModel.Phone = model.Phone;
                    selshopModel.BusinessTimeStartDinner = model.BusinessTimeStartDinner;
                    selshopModel.BusinessTimeEndDinner = model.BusinessTimeEndDinner;
                    selshopModel.BusinessTimeStartLunch = model.BusinessTimeStartLunch;
                    selshopModel.BusinessTimeEndLunch = model.BusinessTimeEndLunch;
                    double _maplng = 0;
                    double.TryParse(model.MapLng, out _maplng);
                    selshopModel.MapLng = _maplng;

                    double _maplat = 0;
                    double.TryParse(model.MapLat, out _maplat);
                    selshopModel.MapLat = _maplat;

                    selshopModel.ListImg = model.ListImg;
                    selshopModel.Introduction = model.Introduction;

                    var imgurl = Request["imgurl"];


                    var selshopimglist = db.selshopimg.Where(x => x.ImgType == 1);
                    if (selshopimglist.Count() > 0)
                    {
                        db.selshopimg.RemoveRange(selshopimglist);
                    }
                    if (imgurl.IsNotNull())
                    {
                        var imgurllist = imgurl.Split(',');
                        for (int i = 0; i < imgurllist.Length; i++)
                        {
                            if (imgurllist[i].IsNotNull())
                            {
                                var selshopimgmodel = new selshopimg() { ID = WebTools.getGUID(), ImgUrl = imgurllist[i], ShopID = ShopId, ImgType = 1, Sort = i + 1 };
                                db.selshopimg.Add(selshopimgmodel);
                            }

                        }
                    }
                    db.SaveChanges();

                    b.Code = 1;
                    b.Message = "保存成功";
                }
                catch (Exception e)
                {
                    b.Code = 0;
                    b.Message = ConstantHelper.Failure;
                    b.Description = e.ToString();
                }
            }
            return Json(b);
        }

        public ActionResult uploadimagelistimg()
        {
            string _folderName = "listimg";
            return uploadimage(_folderName);
        }

        public ActionResult uploadimageenvironmentimg()
        {
            string _folderName = "environmentimg";
            return uploadimage(_folderName);
        }
        [HttpPost]
        public ActionResult PostVaildCode()
        {
            ViewBase b = new ViewBase();
            Random r = new Random();
            string phone = Request["phone"];
            string code = RandomHelper.GetRandom(4);
            SOLib.SoLogin.WriteCookieVaildCode(code);
            //var result = SMSHelper.SendSMS(phone, code);
            //b.Code = result.Code;
            // b.Message = result.Message;
            return Json(b);
        }

        #endregion 
    }
}