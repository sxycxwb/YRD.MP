using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public partial class ExBankCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string BankOwner { get; set; }
        public string BankName { get; set; }
        public string BankAddress { get; set; }
        public string BankNum { get; set; }
        public int BankType { get; set; }
        public int IsAvailable { get; set; }
        public bool IsDefault { get; set; }
        public DateTime AddTime { get; set; }
        public string Remark { get; set; }
    }

    public class ExBankCardList
    {
        public List<ExBankCard> List { get; set; }
    }

    public class ExBankOwner
    {
        public int UserId { get; set; }
        public string BankOwner { get; set; }
        public bool IsFirmCertified { get; set; }

    }
}
