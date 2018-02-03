using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewDistribution
    {
        public decimal Jinbi { get; set; }
        public string PayPassword { get; set; }
    }

    public class ViewDistributionJinbiDetail
    {
        public string CreateTime { get; set; }
        public decimal Jinbi { get; set; }

        public int Type { get; set; }

        public string TypeName { get; set; }

        public string Remark { get; set; }
    }

    public class ViewDistributionContract
    {
        public bool IsSignAgreement { get; set; }

        public string ShopName { get; set; }

        public string LinkMan { get; set; }
        public string Phone { get; set; }
        public string SignAgreementTimeFormat { get; set; }
    }
    public class ViewDistributionOpen
    {
        public bool IsOpen { get; set; }

        public bool IsSignAgreement { get; set; }
    }
    public class ViewDistributionPercentage
    {
        public int Percentage { get; set; }

        public string SetPercentageTimeFormat { get; set; }

        public string SetPercentageTimeEndFormat { get; set; }

        public int Days { get; set; }

        public bool IsSetPercentage { get; set; }

        public bool IsAllowSet { get; set; }
    }

}
