using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExContract
    {
        public int ID { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime InTime { get; set; }
        public int Status { get; set; }
        public string Reason { get; set; }
        public int ContractType { get; set; }
        public string Consignee { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string SendExpressName { get; set; }
        public string SendExpressNum { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? AuditTime { get; set; }
        public DateTime? StampTime { get; set; }
        public string BackExpressName { get; set; }
        public string BackExpressNum { get; set; }
        public DateTime? BackTime { get; set; }
        public DateTime? CompleteTime { get; set; }
        public string AudtiMessage { get; set; }
        public string Remark { get; set; }
        public string AddId { get; set; }
        public string ZipCode { get; set; }
    }
    public class ExContractDetail
    {
        public int ID { get; set; }
        public int CID { get; set; }
        public int NewStatus { get; set; }
        public int OldStatus { get; set; }
        public DateTime DT { get; set; }
        public string Remark { get; set; }
    }

    public class ExContractModel : Base
    {
        public ExContract Entity { get; set; }
    }

    public class ExContractDetailModel : Base
    {
        public ExContract Entity { get; set; }
        public List<ExContractDetail> All { get; set; }
    }

    public class ExContractPageList : Base
    {
        public List<ExContract> All { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int CountPage { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public int CountItems { get; set; }
    }
}
