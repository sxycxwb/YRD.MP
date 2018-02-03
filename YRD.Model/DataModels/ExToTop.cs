using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExToTop
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public int MessageID { get; set; }
        public int Type { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public int Audit { get; set; }
        public string AuditMessage { get; set; }
        public int Effective { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class ExToTopList : Base
    {
        public List<ExToTop> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }

    /// <summary>
    /// 正在排队的置顶或生效的置顶
    /// </summary>
    public class ExToTopQueue
    {
        public int MessageID { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    }
}
