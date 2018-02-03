using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExGrade:Base
    {
        public string GUID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string  Logo { get; set; }
        public decimal Consumption { get; set; }
    }
}
