using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 供应商简表
    /// </summary>
    public class ExSupplierSimple
    {
        /// <summary>
        /// 供应商id
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 供应商类别ID
        /// </summary>
        public string TypeID { get; set; }
        /// <summary>
        /// 供应商类别名
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 供应商欠款金额
        /// </summary>
        public decimal Money { get; set; }
        /// <summary>
        /// 联系人、负责人
        /// </summary>
        public string LinkMan { get; set; }
    }
}
