using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExJinbiApplyDrawMoney
    {
        public int ID { get; set; }
        public int Apply_UID { get; set; }
        public System.DateTime Apply_InTime { get; set; }
        public int Apply_Amount { get; set; }
        public string Process_Admin { get; set; }
        public Nullable<System.DateTime> Process_InTime { get; set; }
        public Nullable<int> Process_Status { get; set; }
        public string Process_Suggestion { get; set; }
        public string RemitBankAccount { get; set; }
    }
    public class ExJinbiApplyDrawMoneyPage
    {
        public List<ExJinbiApplyDrawMoney> ALL { get; set; }
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

    public class UserPaypassState:Base
    {
        public byte state { get; set; }
    }

}
