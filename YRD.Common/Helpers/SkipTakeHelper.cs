using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


public class SkipTakeHelper
{
    /// <summary>
    /// 根据总数，每页数，和当前第几页，算出应该skip多少条，超出最大页数后不返回多余数据
    /// </summary>
    /// <param name="allcount">信息总数</param>
    /// <param name="pagesize">每页条数</param>
    /// <param name="pageindex">当前页</param>
    /// <returns></returns>
    public static SkipTakeModel GetSkipNotShowFinalPage(int allcount, int pagesize, int pageindex)
    {
        SkipTakeModel model = new SkipTakeModel();
        if (pageindex > 0)
        {
            int maxpage = allcount / pagesize;
            if (allcount % pagesize > 0) maxpage++;
            if (pageindex > maxpage)
            {
                model.Skip = allcount;
                model.Take = pagesize;
                model.MaxPage = maxpage;
            }
            else
            {
                pageindex = Math.Min(maxpage, pageindex);
                var max = Math.Max(0, pagesize * (pageindex - 1));
                model.Skip = max;
                model.Take = pagesize;
                model.MaxPage = maxpage;
            }
        }
        return model;
    }

    /// <summary>
    /// 根据总数，每页数，和当前第几页，算出应该skip多少条，超出最大页数之后，返回最后一页面数据
    /// </summary>
    /// <param name="allcount">信息总数</param>
    /// <param name="pagesize">每页条数</param>
    /// <param name="pageindex">当前页</param>
    /// <returns></returns>
    public static SkipTakeModel GetSkipShowFinalPage(int allcount, int pagesize, int pageindex)
    {
        SkipTakeModel model = new SkipTakeModel();
        if (pageindex > 0)
        {
            int maxpage = allcount / pagesize;
            if (allcount % pagesize > 0) maxpage++;
            pageindex = Math.Min(maxpage, pageindex);
            var max = Math.Max(0, pagesize * (pageindex - 1));
            model.Skip = max;
            model.Take = pagesize;
            model.MaxPage = maxpage;
        }
        else
        {
            model.Skip = 0;
            model.Take = pagesize;
            model.MaxPage = 1;
        }
        return model;
    }


    /// <summary>
    /// 分页模型
    /// </summary>
    public class SkipTakeModel
    {
        /// <summary>
        /// 跳过记录
        /// </summary>
        public int Skip { get; set; }
        /// <summary>
        /// 获取条数
        /// </summary>
        public int Take { get; set; }
        /// <summary>
        /// 最大页数
        /// </summary>
        public int MaxPage { get; set; }
    }
}





