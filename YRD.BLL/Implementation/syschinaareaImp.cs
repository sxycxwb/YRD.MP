using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;

namespace YRD.BLL
{
    public class syschinaareaImp : EFRepositoryBase<syschinaarea>
    {
        #region 获取省地区
        public List<syschinaarea> getArea1()
        {
            var area1 = DB.syschinaarea.Value.Where(a => a.parentId == "0" || string.IsNullOrEmpty(a.parentId)).ToList();
            return area1;
        }
        #endregion

        #region 获取下级分类地区
        public List<syschinaarea> getChilds(string id)
        {
            var area1 = DB.syschinaarea.Value.Where(a => a.parentId == id).ToList();
            return area1;
        }
        #endregion

    }
}

