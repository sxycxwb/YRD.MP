using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class RealCheckInfo : Base
    {
        public string AuditMessage { get; set; }
        public int RealCheckId { get; set; }
        public int RealCheck { get; set; }
        public byte RealType { get; set; }
        public string IDCard { get; set; }
        public string Passport { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        public string EntName { get; set; }
        public string EntLicenceID { get; set; }
        public string EntArtificialPerson { get; set; }
        //新添加
        public string EntPhone { get; set; }
        public int EntBankType { get; set; }
        public string EntHolder { get; set; }
        public string EntAccount { get; set; }
        public string EntOpenBank { get; set; }
        public string EntPrincipal { get; set; }
        public string EntPrincipalPhone { get; set; }
        public DateTime InTime { get; set; }
        public string Address { get; set; }
        public int RegistrationType { get; set; }
        public bool IsSpecial { get; set; }
        //new 用户真实姓名
        public string RealName { get; set; }
        //new
        public string LicenceIDPhoto { get; set; }
        public string OpenBankPhoto { get; set; }
        public string Depart { get; set; }

    }
}
