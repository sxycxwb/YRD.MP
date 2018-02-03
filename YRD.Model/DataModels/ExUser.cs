using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExLoginUser : Base
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
    }

    public class ExRegUser
    {
        public string UGUID { get; set; }
    }

    public class ExUser : Base
    {
        public string GUID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string HeadPic { get; set; }
        public long? Score { get; set; }
        public decimal? Gold { get; set; }
        public decimal? TotalConsume { get; set; }
        public string Grade { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool? IsAvailable { get; set; }
    }
    public class ExUserDetail : Base
    {
        public string GUID { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string City1 { get; set; }
        public string City2 { get; set; }
        public string City3 { get; set; }
        public string Sex { get; set; }
        public DateTime? Birthday { get; set; }
        public string QQ { get; set; }
        public string Phone { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string HeadPic { get; set; }
        public string Address { get; set; }
    }

    public class ExUserBasicInfo : Base
    {
        public string UGUID { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }

        public string RealName { get; set; }

        public decimal Jinbi { get; set; }

        public decimal Score { get; set; }
    }
}
