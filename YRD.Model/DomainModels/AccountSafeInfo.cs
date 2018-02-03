using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class AccountSafeInfo : Base
    {
        public string Email { get; set; }
        public int EmailCheck { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string AuditMessage { get; set; }
        public int RealCheckId { get; set; }
        public int RealCheck { get; set; }
        public int RealType { get; set; }
        public string IDCard { get; set; }
        public string Passport { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string EntName { get; set; }
        public string EntLicenceID { get; set; }
        public string EntArtificialPerson { get; set; }
    }
}
