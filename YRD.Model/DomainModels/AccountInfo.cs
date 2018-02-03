using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.DomainModels
{
    public class AccountInfo : Base
    {
        public int Uid { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string Idcn { get; set; }
        public string RegDate { get; set; }
        public string Qualitity { get; set; }
        public string SignCheck { get; set; }
        public string SignDate { get; set; }
        public int RealCheck { get; set; }
    }
}
