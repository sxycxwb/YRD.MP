using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExJinbi_AccountDetailPage : Base
    {
        public List<ExJinbi_AccountDetail> ALL { get; set; }
        //当前页
        public int CurrentPage { get; set; }
        //每页条数
        public int PageSize { get; set; }
        //总页数
        public int CountPage { get; set; }
        //总条数
        public int CountItems { get; set; }
    }

    public class ExJinbi_AccountDetail
    {
        public int ID { get; set; }
        public string uid { get; set; }
        public string date { get; set; }
        //public float? data { get; set; }
        public decimal? data { get; set; }
        public string remark { get; set; }
        public int state { get; set; }
        public int? jinbitype { get; set; }
    }

    public class ExJinbiSendRecive
    {
        public int ID { get; set; }
        public Nullable<int> uidsend { get; set; }
        public Nullable<int> uidrecive { get; set; }
        public Nullable<double> jinbi { get; set; }
        public Nullable<int> hasRecive { get; set; }
        public string remark { get; set; }
        public Nullable<System.DateTime> senddate { get; set; }
        public string ordernumber { get; set; }
        public string batchid { get; set; }
    }
    public class ExJinbiSendRecivePage
    {
        public List<ExJinbiSendRecive> ALL { get; set; }
        //当前页
        public int CurrentPage { get; set; }
        //每页条数
        public int PageSize { get; set; }
        //总页数
        public int CountPage { get; set; }
        //总条数
        public int CountItems { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
    }


    public class ExGoldSendRecive
    {
        public string uidsend { get; set; }
        public string uidsendname { get; set; }
        public string uidrecive { get; set; }
        public string uidrecivename { get; set; }
        public string jinbi { get; set; }
        public string remark { get; set; }
        public string senddate { get; set; }
    }


    public class ExGoldSendRecivePage : Base
    {
        public List<ExGoldSendRecive> ALL { get; set; }
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
