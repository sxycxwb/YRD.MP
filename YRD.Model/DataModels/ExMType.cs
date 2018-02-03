using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExMType
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ExMTypeList : Base
    {
        public List<ExMType> List { get; set; }
    }
}
