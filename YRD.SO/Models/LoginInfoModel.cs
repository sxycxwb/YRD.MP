using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YRD.SO.Models
{
    public class LoginModel
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Url { get; set; }
    }
}