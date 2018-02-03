using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExScoreDetail
    {
        public long ID { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public class ExScoreDetailList : Base
    {
        public List<ExScoreDetail> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }
}
