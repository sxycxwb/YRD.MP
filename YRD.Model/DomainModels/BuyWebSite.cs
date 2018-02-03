using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExBuyWebSite
    {
        public int ID { get; set; }
        public string UGUID { get; set; }
        public string UserName { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Data { get; set; }
        public System.DateTime Start { get; set; }
        public System.DateTime End { get; set; }
        public System.DateTime DT { get; set; }
        public int WebSiteType { get; set; }
        public int Origin { get; set; }
        public bool IsAvailable { get; set; }
        public string BatchId { get; set; }
    }
    public class ExBuyWebSiteList : Base
    {
        public List<ExBuyWebSite> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }

}
