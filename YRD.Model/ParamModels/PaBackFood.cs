using System.Collections.Generic;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    public class PaBackFood:PaBase
    {
        public ExIndex_table tb { get; set; }
        public List<Ex_cusorderdetail> orderdetails { get; set; }
    }
}