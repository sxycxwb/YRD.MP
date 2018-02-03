using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ParamModels
{
    public class PaShop: PaBase
    {
        /// <summary>
        /// 测试店铺编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 测试店铺名称
        /// </summary>
        public string Name { get; set; }
    }
}
