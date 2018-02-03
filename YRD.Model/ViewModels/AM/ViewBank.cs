using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewShopJinbi : ViewBase
    {
        public decimal Jinbi { get; set; }
    }

    public class ViewUserScore : ViewBase
    {
        public decimal Score { get; set; }
    }
    public class ViewDistributionJinbi : ViewBase
    {
        public decimal Jinbi { get; set; }
        public decimal Deposit { get; set; }

        public decimal Usable { get; set; }

        public string VersionText { get; set; }
        public int VersionID { get; set; }
    }

}
