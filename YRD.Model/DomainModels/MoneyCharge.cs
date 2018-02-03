using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExMoneyCharge
    {
        public string ID { get; set; }
        public string ShopID { get; set; }
        public string ManagerID { get; set; }
        public decimal Data { get; set; }
        public DateTime DT { get; set; }
        public int PayType { get; set; }
        public int Origin { get; set; }
        public bool IsAvailable { get; set; }
        public string BatchId { get; set; }
        public Nullable<DateTime> ConfirmDT { get; set; }
        public byte[] RowVersion { get; set; }
    }
    //public class ExJinbiChargeList : Base
    //{
    //    public List<ExJinbiCharge> List { get; set; }
    //    public int PageSize { get; set; }
    //    public int RecordCount { get; set; }
    //    public int PageIndex { get; set; }
    //}

    public class ExAddRecharge
    {
        public string Id { get; set; }
        public string BatchId { get; set; }
    }

}
