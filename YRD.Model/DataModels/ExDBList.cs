using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExDBList
    {
        public string GUID { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int? Sort { get; set; }
        public string Remark { get; set; }
        public string EnCode { get; set; }

    }

    public class ExDBListList : Base
    {
        public List<ExDBList> List { get; set; }
    }
}
