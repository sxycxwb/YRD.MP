using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace YRD.SOLib
{
    public class ConstantManager
    {
        SM manager;
        public ConstantManager(SM manager)
        {
            this.manager = manager;

        }
        public string key = "niyrdccn";
        public string CookieValidCodeKey = "ni.rd.cc";
    }
}