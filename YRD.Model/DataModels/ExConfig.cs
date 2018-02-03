using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExConfig
    {
        public string Keyword { get; set; }
        public string Value { get; set; }
    }

    public class ExConfigList : Base
    {
        public List<ExConfig> List { get; set; }
    }
}
