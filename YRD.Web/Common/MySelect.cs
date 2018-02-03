using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System
{
    /// <summary>
    /// 下拉框列表数据源
    /// </summary>
    public class MySelect
    {
        #region 打印机
        public static List<ViewSelectListItem> getPrint(string shopid)
        {
            var list = DB.selprinter.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 打印机类型
        public static List<ViewSelectListItem> getPrinterType()
        {
            var list = DB.selprintertype.Value.Where()
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 菜品类型
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public static List<ViewSelectListItem> getFoodType(string shopid)
        {
            var list = DB.selfoodtype.Value.Where(x => x.ShopID == shopid)
                .OrderBy(x => x.Sort)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 菜品成品半成品类型
        /// <summary>
        /// 全部
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public static List<ViewSelectListItem> getFinishType()
        {
            var a1 = new ViewSelectListItem("1", "成品");
            var a2 = new ViewSelectListItem("0", "半成品");
            List<ViewSelectListItem> list = new List<ViewSelectListItem>();
            list.Add(a1);
            list.Add(a2);
            return list;
        }
        #endregion

        #region 菜品类型
        /// <summary>
        /// 套餐分类
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public static List<ViewSelectListItem> getFoodTypeState1(string shopid)
        {
            var list = DB.selfoodtype.Value.Where(x => x.ShopID == shopid && x.IsPackage==true)
                .OrderBy(x => x.Sort)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 菜品类型
        /// <summary>
        /// 不包含套餐分类
        /// </summary>
        /// <param name="shopid"></param>
        /// <returns></returns>
        public static List<ViewSelectListItem> getFoodTypeState0(string shopid)
        {
            var list = DB.selfoodtype.Value.Where(x => x.ShopID == shopid && x.IsPackage==false)
                .OrderBy(x => x.Sort)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 菜品类型
        public static List<ViewSelectListItem> getType(string shopid)
        {
            var list = DB.selfoodtype.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 套餐分类
        public static List<ViewSelectListItem> getPackageType(string shopid)
        {
            var list = DB.selpackage.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 特价 ：有 无
        public static List<ViewSelectListItem> getTeJia()
        {
            var a1 = new ViewSelectListItem("1", "有");
            var a2 = new ViewSelectListItem("0", "无");
            List<ViewSelectListItem> list = new List<ViewSelectListItem>();
            list.Add(a1);
            list.Add(a2);
            return list;
        }
        #endregion

        #region 角色列表 
        public static List<ViewSelectListItem> getRole(string shopid)
        {
            var list = DB.selrole.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 材料单位 
        public static List<ViewSelectListItem> getMaterialUnit(string shopid)
        {
            var list = DB.swhmaterialunit.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }

        public static List<ViewSelectListItem> getMaterialMainUnit(string shopid)
        {
            var list = DB.swhmaterialunit.Value.Where(x => x.ShopID == shopid && x.UnitType == 1 && x.IsAvailable == true)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }

        public static List<ViewSelectListItem> getMaterialUnitByMaterialMainUnit(string mainunitid)
        {
            var list = DB.swhmaterialunit.Value.Where(x => x.MainUnitID == mainunitid && x.IsAvailable == true)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }

        #endregion

        #region 角色列表 
        public static List<ViewSelectListItem> getMaterialBrand(string shopid)
        {
            var list = DB.swhmaterialbrand.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 角色列表 
        //public static List<ViewSelectListItem> getMaterialPackageUnit(string shopid)
        //{
        //    var list = DB.swhmaterialpackageunit.Value.Where(x => x.ShopID == shopid)
        //        .Select(a => new { a.ID, a.Title })
        //        .ToList()
        //        .Select(a => new ViewSelectListItem(a.ID, a.Title))
        //        .ToList();
        //    return list;
        //}
        #endregion

        #region 材料类型 
        public static List<ViewSelectListItem> getMaterialType(string shopid, string parentid)
        {
            var list = DB.swhmaterialtype.Value.Where(x => x.ShopID == shopid && x.ParentID == parentid && x.IsAvailable == true)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion
        #region 材料 
        public static List<ViewSelectListItem> getMaterial(string shopid)
        {
            var list = DB.swhmaterial.Value.Where(x => x.ShopID == shopid && x.IsAvailable == true)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion


        #region 供应商类型 
        public static List<ViewSelectListItem> getSupplierType(string shopid)
        {
            var list = DB.swhsuppliertype.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion


        #region 员工 
        public static List<ViewSelectListItem> getManager(string shopid)
        {
            var list = DB.selmanager.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.NickName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.NickName))
                .ToList();
            return list;
        }
        #endregion

        #region 库房 
        public static List<ViewSelectListItem> getWareHouse(string shopid)
        {
            var list = DB.swhwarehouse.Value.Where(x => x.ShopID == shopid && x.IsAvailable == true)
                .Select(a => new { a.ID, a.Name })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Name))
                .ToList();
            return list;
        }
        #endregion

        #region 供应商 
        public static List<ViewSelectListItem> getSupplier(string shopid)
        {
            var list = DB.swhsupplier.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 短信类型 
        public static List<ViewSelectListItem> getTemplage()
        {
            var list = DB.syssmstemplate.Value.Where(x => true)
                .Select(a => new { a.TemplateID, a.TemplateName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.TemplateID.ToString(), a.TemplateName))
                .ToList();
            return list;
        }
        #endregion

        #region 菜品单位
        public static List<ViewSelectListItem> getFoodUnit()
        {
            var list = DB.selfoodunit.Value.Where()
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 选择楼层
        public static List<ViewSelectListItem> getDepartment(string shopid)
        {
            var list = DB.seldepartment.Value.Where(x => x.ShopID == shopid).OrderBy(x => x.Sort)
                .Select(a => new { a.ID, a.Title })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.Title))
                .ToList();
            return list;
        }
        #endregion

        #region 房间
        public static List<ViewSelectListItem> getRoom(string shopid)
        {
            var list = DB.selroom.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, a.RoomName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.RoomName))
                .ToList();
            return list;
        }
        public static List<ViewSelectListItem> getRoom(string shopid, string department)
        {
            var list = DB.selroom.Value.Where(x => x.ShopID == shopid && x.DepartmentID == department)
                .Select(a => new { a.ID, a.RoomName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.RoomName))
                .ToList();
            return list;
        }
        #endregion

        #region 排号字母A-Z
        public static List<ViewSelectListItem> getAZ()
        {
            List<ViewSelectListItem> list = new List<ViewSelectListItem>();
            var A = (int)'A';
            for (int i = 0; i < 26; i++)
            {
                var x = Convert.ToChar(A + i).ToString();
                list.Add(new ViewSelectListItem(x, x));
            }
            return list;
        }
        #endregion

        #region 服务员
        public static List<ViewSelectListItem> getFWY(string shopid)
        {
            var list = DB.selmanager.Value.Where(x => x.ShopID == shopid)
                .Select(a => new { a.ID, text = a.NickName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.text))
                .ToList();
            return list;
        }
        #endregion

        #region 性别
        public static List<ViewSelectListItem> getSex()
        {
            var a1 = new ViewSelectListItem("1", "男");
            var a2 = new ViewSelectListItem("0", "女");
            List<ViewSelectListItem> list = new List<ViewSelectListItem>();
            list.Add(a1);
            list.Add(a2);
            return list;
        }
        #endregion

        #region 卡类型:充值卡 优惠卡 打折卡等
        public static List<ViewSelectListItem> getCardType()
        {
            var a1 = new ViewSelectListItem("1", "充值卡");
            var a2 = new ViewSelectListItem("2", "打折卡");
            var a3 = new ViewSelectListItem("3", "特惠卡");
            var a4 = new ViewSelectListItem("4", "专享卡");
            var a5 = new ViewSelectListItem("5", "记次卡");
            List<ViewSelectListItem> list = new List<ViewSelectListItem>();
            list.Add(a1);
            list.Add(a2);
            list.Add(a3);
            list.Add(a4);
            list.Add(a5);
            return list;
        }
        #endregion

        #region 店面 店铺
        public static List<ViewSelectListItem> getShop(string shopid)
        {
            var list = DB.selshop.Value.Where(x => x.ID == shopid)
                .Select(a => new { a.ID, text = a.ShopName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.text))
                .ToList();
            return list;
        }
        #endregion

        #region 收银员
        public static List<ViewSelectListItem> getSYY()
        {
            var list = DB.selmanager.Value.Where()
                .Select(a => new { a.ID, text = a.NickName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.text))
                .ToList();
            return list;
        }
        #endregion

        #region 传菜打印规则

        public static List<ViewSelectListItem> getFoodPrintRule()
        {
            var list = DB.selImp.Value.FoodPrintRule
                .Select(a => new { a.ID, a.Name })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID.ToString(), a.Name))
                .ToList();
            return list;
        }

        #endregion

        #region 固定费用规则 
        public static List<ViewSelectListItem> getFixedCostType()
        {
            var list = DB.selImp.Value.FixedCostType
                .Select(a => new { a.ID, a.Name })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID.ToString(), a.Name))
                .ToList();
            return list;
        }

        #endregion

        #region 客户评价
        public static List<ViewSelectListItem> getKHPJ()
        {
            List<ViewSelectListItem> list = new List<ViewSelectListItem>();
            list.Add(new ViewSelectListItem("5", "五星"));
            list.Add(new ViewSelectListItem("4", "四星"));
            list.Add(new ViewSelectListItem("3", "三星"));
            list.Add(new ViewSelectListItem("2", "二星"));
            list.Add(new ViewSelectListItem("1", "一星"));

            return list;
        }
        #endregion

        #region 充值类型
        //public static List<ViewSelect> get()
        //{
        //    var list = DB.selmanager.Where()
        //        .Select(a => new { a.ID, text = a.NickName })
        //        .ToList()
        //        .Select(a => new ViewSelect(a.ID, a.text))
        //        .ToList();
        //    return list;
        //}
        #endregion

        #region 商家类型
        public static List<ViewSelectListItem> getShopType()
        {
            var list = DB.selshoptype.Value.Where()
              .Select(a => new { a.ID, text = a.Title })
              .ToList()
              .Select(a => new ViewSelectListItem(a.ID, a.text))
              .ToList();
            return list;
        }
        #endregion

        #region 所有的子区域

        public static List<ViewSelectListItem> getChildArea(string parentId)
        {
            var list = DB.syschinaarea.Value.Where(x => x.parentId == parentId)
              .Select(a => new { a.code, text = a.name })
              .ToList()
              .Select(a => new ViewSelectListItem(a.code, a.text))
              .ToList();
            return list;
        }


        #endregion

        #region 组合DDL
        /// <summary>
        /// 组合select
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToSelectOrigin(string methodName, string value = "", string nullText = "")
        {
            MethodInfo mi = typeof(MySelect).GetMethod(methodName);
            var list = mi.Invoke(null, null) as List<ViewSelectListItem>;
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(nullText))
            {
                sb.AppendFormat("<option value=\"\">{0}</option>", nullText);
            }
            foreach (var item in list)
            {
                if (item.Value == value)
                {
                    sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\"  >{1}</option>", item.Value, item.Text);
                }
            }
            return sb.ToString();
        }

        public static string ToSelectOrigin(string name, List<ViewSelectListItem> list, string value = "", string nullText = "", string datatype = "", string classvalue = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<select id=\"{0}\" name=\"{0}\"  class=\"{1}\" {2} >", name, classvalue, datatype);
            if (!string.IsNullOrEmpty(nullText))
            {
                sb.AppendFormat("<option value=\"\">{0}</option>", nullText);
            }
            foreach (var item in list)
            {
                if (item.Value == value)
                {
                    sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\"  >{1}</option>", item.Value, item.Text);
                }
            }
            sb.AppendFormat("</select>");
            return sb.ToString();
        }

        public static string ToSelectOrigin(List<ViewSelectListItem> list, string value = "", string nullText = "")
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(nullText))
            {
                sb.AppendFormat("<option value=\"\">{0}</option>", nullText);
            }
            foreach (var item in list)
            {
                if (item.Value == value)
                {
                    sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value, item.Text);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\"  >{1}</option>", item.Value, item.Text);
                }
            }
            return sb.ToString();
        }


        public static string ToSelectNew(string name, string methodName, string nullText = "", string id = "", string text = "")
        {
            MethodInfo mi = typeof(MySelect).GetMethod(methodName);
            var list = mi.Invoke(null, null) as List<ViewSelectListItem>;
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("<div class=\"select-text\">");
            sb.AppendFormat("<input type = \"text\" readonly=\"readonly\" value=\"{0}\" />", text);
            sb.AppendFormat("<input type = \"hidden\" id=\"{0}\"  name=\"{0}\" value=\"{1}\" />", name, id);
            sb.AppendFormat("<a href = \"javascript:;\" ><img src=\"{0}/Content/image/icon/select-down.png\"/></a>", ConfigHelper.GetCdnUrl);
            sb.AppendFormat("</div>");
            sb.AppendFormat("<ul class=\"select-box\">");
            if (!string.IsNullOrEmpty(nullText))
            {
                sb.AppendFormat("<li id=\"\">{0}</li>", nullText);
            }
            foreach (var item in list)
            {
                sb.AppendFormat("<li id=\"{0}\">{1}</li>", item.Value, item.Text);
            }
            sb.AppendFormat(" </ul>");
            return sb.ToString();
        }
        #endregion

        #region 餐桌
        public static List<ViewSelectListItem> getTable(string roomID)
        {
            var list = DB.seltable.Value.Where(x=>x.RoomID==roomID)
                .Select(a => new { a.ID, text = a.TableName })
                .ToList()
                .Select(a => new ViewSelectListItem(a.ID, a.text))
                .ToList();
            return list;
        }
        #endregion

        #region 挂账人

        //public static List<ViewSelectListItem> getOrderDebt(string shopid)
        //{
        //    var list = DB.cusorderdebt.Value.Where(x=>x.ShopID==shopid)
        //        .Select(a => new { a.ID, text = a.Name })
        //        .ToList()
        //        .Select(a => new ViewSelectListItem(a.ID, a.text))
        //        .ToList();
        //    return list;
        //}

        #endregion
    }
}
