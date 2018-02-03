using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace YRD.Model.EnumModels
{
    public enum EnumPrinterType
    {
        [Description("无线")]
        WuXian = 1,
        [Description("有线")]
        YouXian = 2,
        [Description("USB")]
        USB = 3



    }
}
