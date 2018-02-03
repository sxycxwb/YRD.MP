using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class CertificateUser : Base
    {
        public int Uid { get; set; }
        public string RealName { get; set; }
        // 
        public byte RealType { get; set; }
        public int RealCheck { get; set; }
        public string EntLicenceID { get; set; }

        public string EntName { get; set; }//企业名称
        public string EntArtificialPerson { get; set; }//法人姓名
        //
        public string IdCard { get; set; }
        public string BYear { get; set; }
        public string BMonth { get; set; }
        public string BDay { get; set; }
        public string EYear { get; set; }
        public string EMonth { get; set; }
        public string EDay { get; set; }
    }
}
