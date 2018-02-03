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
    /// 账户管理--权限设置
    /// </summary>
    public class PermissionController : BaseController
    {
        #region 权限设置
        [Authorization(1115)]
        public ActionResult RoleSet()
        {
            ViewBag.Table = "selrole";
            return View();
        }

        #region getRole
        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <param name="start">开始日期</param>
        /// <param name="end">结束日期</param>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public string getRole(string key, int start, int length)
        {
            using (var db = new EFContext())
            {
                var shop = db.selshop.FirstOrDefault(x => x.ID == ShopId);

                var query = db.selrole.AsQueryable();

                query = query.Where(x => (x.ShopID == ShopId && x.CreateManagerID == ManagerId)).AsQueryable();

                if (key.IsNotNull())
                {
                    query = query.Where(x => x.Title.Contains(key));
                }
                ///求总条数
                var total = query.EFLongCount();
                ///取当页数据列表
                var list = query.OrderBy(a => a.ID).Skip(start).Take(length).ToList();
                ///输出给DataTables
                return ToPageWithPaging(list, total);
            }

        }
        #endregion
        public ActionResult AddRole(string id)
        {
            ViewRole model = new ViewRole();

            using (var db = new EFContext())
            {
                if (id.IsNotNull())
                {
                    var role = db.selrole.FirstOrDefault(x => x.ID == id);
                    model.ID = role.ID;
                    model.Title = role.Title;
                    model.Introduction = role.Introduction;
                    if (role.IsDefault == 1)
                    {
                        return Redirect("RoleSet");
                    }
                }

                var query = new List<ViewPemit>().AsQueryable();
                //查询网店所有者用户拥有的权限

                var selmanagerowner = db.selmanager.FirstOrDefault(x => x.ShopID == ShopId && x.IsOwner == 1);
                var selmanagerroleowner = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == ManagerId);
                var rolepemitidowner = db.selrole_pemit.Where(x => x.SelRoleID == selmanagerroleowner.SelRoleID).Select(x => x.SelPemitID).ToList();
                //查询当前用户拥有的权限
                var selmanagerrole = db.selmanager_role.FirstOrDefault(x => x.SelManagerID == ManagerId);
                var rolepemitid = db.selrole_pemit.Where(x => x.SelRoleID == selmanagerrole.SelRoleID).Select(x => x.SelPemitID).ToList();
                if (IsOwner==1)
                {
                    query = db.selpemit.Where(x => rolepemitid.Contains(x.ID))
                   .Select(x => new ViewPemit() { ID = x.ID, Title = x.Title, ParentID = x.ParentID, IsDel = x.IsDel, ImgUrl = x.ImgUrl, PemitType = x.PemitType, Sort = x.Sort, Url = x.Url });
                }
                else
                {
                    query = db.selpemit.Where(x => rolepemitid.Contains(x.ID)).Where(x => !rolepemitidowner.Contains(x.ID))
                   .Select(x => new ViewPemit() { ID = x.ID, Title = x.Title, ParentID = x.ParentID, IsDel = x.IsDel, ImgUrl = x.ImgUrl, PemitType = x.PemitType, Sort = x.Sort, Url = x.Url });
                }
               

                model.ListPemit = query.ToList();
            }
            return View(model);
        }
        public ActionResult SelRoleSave(ViewRole r)
        {
            var b = new ViewBase();
            var pemits = Request["cbPemit"];

            List<selrole_pemit> role_nav = new List<selrole_pemit>();

            using (var db = new EFContext())
            {
                try
                {
                    if (r.ID.IsNull())
                    {
                        #region 添加
                        selrole entity = new selrole();
                        entity.ID = WebTools.getGUID();
                        entity.CreateTime = DateTime.Now;
                        entity.IsAvailable = 1;
                        entity.ShopID = ShopId;
                        entity.CreateManagerID = ManagerId;
                        entity.IsDefault = 0;
                        entity.Title = r.Title;
                        entity.Introduction = r.Introduction;
                        db.selrole.Add(entity);

                        if (pemits.IsNotNull())
                        {
                            var str = pemits.Split(',');
                            for (int i = 0; i < str.Length; i++)
                            {
                                var pr = new selrole_pemit();
                                pr.SelPemitID = str[i];
                                pr.SelRoleID = entity.ID;
                                pr.ID = WebTools.getGUID();
                                db.selrole_pemit.Add(pr);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        #region 修改
                        var model = db.selrole.Find(r.ID);
                        if (model != null)
                        {
                            model.Title = r.Title;
                            model.Introduction = r.Introduction;

                            var selrolepemitlist = db.selrole_pemit.Where(x => x.SelRoleID == r.ID);
                            if (selrolepemitlist.Count() > 0)
                            {
                                db.selrole_pemit.RemoveRange(selrolepemitlist);
                            }

                            if (pemits.IsNotNull())
                            {
                                var str = pemits.Split(',');
                                for (int i = 0; i < str.Length; i++)
                                {
                                    var pr = new selrole_pemit();
                                    pr.SelPemitID = str[i];
                                    pr.SelRoleID = r.ID;
                                    pr.ID = WebTools.getGUID();
                                    db.selrole_pemit.Add(pr);
                                }

                                //var str = pemits.Split(',');
                                //for (int i = 0; i < str.Length; i++)
                                //{
                                //    var pr = new selrole_pemit();
                                //    pr.SelPemitID = str[i];
                                //    pr.SelRoleID = entity.ID;
                                //    pr.ID = WebTools.getGUID();
                                //    role_nav.Add(pr);
                                //}
                                //var oldNav = db.selrole_pemit.Where(p => p.SelRoleID == entity.ID);
                                ////先删除原来多余的
                                //foreach (var item in oldNav)
                                //{
                                //    var exsit = role_nav.Any(a => a.SelPemitID == item.SelPemitID);
                                //    if (exsit == false)
                                //    {
                                //        db.selrole_pemit.Remove(item);
                                //    }
                                //}
                                ////再添加原来没有的
                                //foreach (var item in role_nav)
                                //{
                                //    var exsit = oldNav.FirstOrDefault(a => a.SelPemitID == item.SelPemitID);
                                //    if (exsit == null)
                                //    {
                                //        db.selrole_pemit.Add(item);
                                //    }
                                //}
                            }
                        }
                        #endregion
                    }
                    db.SaveChanges();
                    b.IsSuccess = true;
                }
                catch (Exception e)
                {
                    LogHelper.Error("添加角色：" + WebTools.getFinalException(e));
                    b.Message = "添加角色失败";
                }
                if (b.IsSuccess)
                {
                    b.Message = "操作成功";
                    b.Url = "/Permission/RoleSet";  //成功后跳转
                }
            }
            return Json(b);
        }

        public JsonResult DeleteRole(string id)
        {

            var b = new ViewBase();
            using (var db = new EFContext())
            {
                var selrole = db.selrole.FirstOrDefault(a => a.ID == id);
                if (selrole.IsDefault == 1)
                {
                    db.selrole.Remove(selrole);
                    var selrole_pemit = db.selrole_pemit.Where(x => x.SelRoleID == selrole.ID);
                    if (selrole_pemit.LongCount() > 0)
                    {
                        foreach (var item in selrole_pemit)
                        {
                            db.selrole_pemit.Remove(item);
                        }
                    }
                    db.SaveChanges();
                    b.Code = 1;
                    b.Message = "操作成功";
                }
                else
                {
                    b.Code = 0;
                    b.Message = "该角色为系统系统默认角色 无法删除";
                }
            }

            return Json(b);
        }
        #endregion
    }
}