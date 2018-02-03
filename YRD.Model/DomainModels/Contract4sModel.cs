using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class Contract4sModel : Base
    {
        public int uid { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public int Level { get; set; }
    }
}
