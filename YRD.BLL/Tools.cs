using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;
using YRD.Model;

namespace YRD.BLL
{
    /// <summary>
    /// 公共实现类
    /// </summary>
    public class Tools
    {

        #region 打印输入参数
        /// <summary>
        /// 打印输入参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public static void PrintPa<T>(T t) where T : class
        {
            try
            {
                StackTrace st = new StackTrace(true);
                var method = st.GetFrame(1).GetMethod();
                var url = method.ReflectedType.FullName + "/" + method.Name;
                LogHelper.Debug(url + "：" + t.ToJsonString());
            }
            catch (Exception e)
            {
                LogHelper.Error("打印输入参数出错：" + WebTools.getFinalException(e));
            }
        }
        #endregion

        #region 通过manager id 获取操作员的姓名与角色名
        /// <summary>
        /// 通过manager id 获取操作员的姓名与角色名
        /// </summary>
        /// <param name="db">数据库连接实例</param>
        /// <param name="id">manager id</param>     
        public static NewBase<string, string> getManagerNameAndRole(EFContext db, string id)
        {
            var name = string.Empty;
            var roleName = string.Empty;
            if (id.IsNotNull())
            {
                var manager = db.selmanager.FirstOrDefault(a => a.ID == id);
                if (manager != null)
                {
                    name = manager.NickName;
                    var role = (from a in db.selrole
                                join b in db.selmanager_role.Where(t => t.SelManagerID == manager.ID) on a.ID equals b.SelRoleID
                                select a.Title
                                ).FirstOrDefault();
                    if (role != null) roleName = role;
                }
            }
            var ba = new NewBase<string, string>();
            ba.Data = name;
            ba.Data2 = roleName;
            ba.setSuccess("获取数据成功");
            return ba;
        }
        #endregion

        #region 通过供应商 id 获取供应商的名称与类别
        /// <summary>
        /// 通过manager id 获取操作员的姓名与角色名
        /// </summary>
        /// <param name="db">数据库连接实例</param>
        /// <param name="id">manager id</param>     
        public static ExSupplierSimple getSupplierSimple(EFContext db, string id)
        {
            var model = new ExSupplierSimple();
            var sup = db.swhsupplier.FirstOrDefault(a => a.ID == id);

            if (sup != null)
            {
                model.ID = sup.ID;
                model.Name = sup.Title;
                model.TypeID = sup.SupplierTypeID;
                model.Money = sup.Money;
                model.Phone = sup.LinkPhone;
                var x = db.swhsuppliertype.FirstOrDefault(a => a.ID == sup.SupplierTypeID);
                if (x != null) model.TypeName = x.Title;
            }
            return model;
        }
        #endregion

        #region 获取库房名称
        /// <summary>
        /// 获取库房名称
        /// </summary>
        /// <param name="db"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string getWareHouseName(EFContext db, string id)
        {
            if (id.IsNull()) return string.Empty;
            var house = db.swhwarehouse.FirstOrDefault(a => a.ID == id);
            if (house != null) return house.Name;
            return string.Empty;
        }
        /// <summary>
        /// 通过 库管员 获取库房id
        /// </summary>
        /// <param name="applySellerID"></param>
        /// <returns></returns>
        public static string getWareHouseByManager(string applySellerID)
        {
            //暂时还不知道对应关系
            var houseid = string.Empty;

            return houseid;
        }
        #endregion
    }
}
