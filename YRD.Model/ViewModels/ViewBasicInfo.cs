using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class ViewBasicInfo : ViewBase
    {
        public string UserName { get; set; }

        public bool UserNameEnabled { get; set; }
        public string RealName { get; set; }
        public bool RealNameEnabled { get; set; }
        public int Sex { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }

        public bool AddressEnabled { get; set; }
        public string ZipCode { get; set; }
        public string BankName { get; set; }
        public string BankAccount { get; set; }
        public int IsAvailable { get; set; }
    }
}
