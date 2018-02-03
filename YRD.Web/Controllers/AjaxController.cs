using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace YRD.Web.Controllers
{
    public class AjaxController : Controller
    {
        #region 删除数据
        /// <summary>
        /// 通用的删除数据的方法
        /// </summary>
        /// <param name="table">要删除表的表名</param>
        /// <param name="id">主键列表，以逗号分隔</param>
        /// <returns></returns>
        public JsonResult Delete(string table, string id)
        {
            var b = new Base("删除数据失败");
            if (string.IsNullOrEmpty(id))
            {
                b.Message = "未选中批量删除的数据";
                return Json(b, JsonRequestBehavior.AllowGet);
            }
            try
            {
                var ids = id.TrimEnd(',').Split(',').Distinct().ToList();
                if (!ids.Any())
                {
                    b.Message = "未找到要删除的数据";
                    return Json(b, JsonRequestBehavior.AllowGet);
                }
                using (var db = new EFContext())
                {
                    //string typeName = string.Format("YRD.Dao.{0}, YRD.Dao", table);
                    //var type = Type.GetType(typeName);
                    //foreach (var item in ids)
                    //{
                    //    var model = db.Find(type, item);
                    //    if (model != null)
                    //    {
                    //        db.Remove(model);
                    //    }
                    //}
                    db.SaveChanges();

                    b.IsSuccess = true;
                    b.Message = "删除数据成功";

                }
            }
            catch (Exception e)
            {
                b.IsSuccess = false;
                b.Message = ConstantHelper.Failure;
                b.Description = e.ToString();
            }
            return Json(b, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 获取下级地区
        public string GetChildArea(string id, int n)
        {
            using (var db = new EFContext())
            {
                var list = db.syschinaarea.Where(p => p.parentId == id).Select(a => new { id = a.code, text = a.name }).ToList();
                StringBuilder sb = new StringBuilder();
                if (n == 1)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", string.Empty, "请选择省");
                }
                else if (n == 2)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", string.Empty, "请选择市");
                }
                else if (n == 3)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", string.Empty, "请选择区县");
                }
                else
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", string.Empty, "请选择商圈");
                }

                foreach (var item in list)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", item.id, item.text);
                }
                return sb.ToString();
            }
        }
        #endregion

        #region 根据楼层取 房间 下拉
        public string GetRoomBy(string department)
        {
            var list = DB.selroom.Value.Where(p => p.DepartmentID == department).Select(a => new { id = a.ID, text = a.RoomName }).ToList();
            list.Insert(0, new { id = string.Empty, text = "请选择" });
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", item.id, item.text);
            }
            return sb.ToString();
        }
        #endregion

        #region 获取材料类别 下拉
        public string GetMaterialTypeChild(string materialtypeid)
        {
            var list = DB.swhmaterialtype.Value.Where(x => x.ParentID == materialtypeid).Select(x => new { id = x.ID, text = x.Title }).ToList();
            list.Insert(0, new { id = string.Empty, text = "请选择" });
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", item.id, item.text);
            }
            return sb.ToString();
        }
        #endregion

        #region 获取同一组单位根据主单位
        public string GetMaterialUnitByMaterialMainUnit(string mainunitid)
        {
            var list = DB.swhmaterialunit.Value.Where(x => x.MainUnitID == mainunitid && x.IsAvailable == true).Select(x => new { id = x.ID, text = x.Title }).ToList();
            list.Insert(0, new { id = string.Empty, text = "请选择单位" });
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                sb.AppendFormat("<option value='{0}'>{1}</option>", item.id, item.text);
            }
            return sb.ToString();
        }
        #endregion

        #region 根据角色获取管理员
        public string getManagerByRole(string id)
        {
            using (var db = new EFContext())
            {
                var list = (from a in db.selmanager
                            join b in db.selmanager_role.Where(x => x.SelRoleID == id) on a.ID equals b.SelManagerID
                            select a)
                    .Select(a => new { id = a.ID, text = a.LoginName }).ToList();
                list.Insert(0, new { id = string.Empty, text = "请选择" });
                StringBuilder sb = new StringBuilder();
                foreach (var item in list)
                {
                    sb.AppendFormat("<option value='{0}'>{1}</option>", item.id, item.text);
                }
                return sb.ToString();
            }
        }
        #endregion
    }
}