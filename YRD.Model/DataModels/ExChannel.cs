using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExChannel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Keyword { get; set; }
        public string Name { get; set; }
        public int? PID { get; set; }
        public int? PageSize { get; set; }
    }

    public class ExChannelList : Base
    {
        public List<ExChannel> List { get; set; }
    }
}
