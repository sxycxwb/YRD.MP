using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExCity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Sort { get; set; }
    }

    public class ExCityList : Base
    {
        public List<ExCity> List { get; set; }
    }
}
