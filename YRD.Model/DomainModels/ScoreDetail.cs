using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ScoreDetail
    {
        public int id { get; set; }
        public decimal score { get; set; }
        public string type { get; set; }
        public int orderid { get; set; }
        public int uid { get; set; }
        public DateTime ischeck { get; set; }
        public int status { get; set; }
        public int scoretype { get; set; }
        public string BatchId { get; set; }
    }

    public class ScoreList : Base
    {
        public List<ScoreDetail> All { get; set; }
        //当前页
        public int CurrentPage { get; set; }
        //每页条数
        public int PageSize { get; set; }
        //总页数
        public int CountPage { get; set; }
        //总条数
        public int CountItems { get; set; }
    }
}
