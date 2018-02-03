using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Model.DataModels;

namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 主页请求
    /// </summary>
   public  class PaIndex:PaBase
    {
        /// <summary>
        /// 商户id
        /// </summary>
        public string selShopId { get; set; }
        /// <summary>
        /// 房间id
        /// </summary>
        public string selroomId { get; set; }
        /// <summary>
        /// 房间类型id
        /// </summary>
        public string selroomtypeId { get; set; }
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 区域ID
        /// </summary>
        public string SelDepartmentID { get; set; }
        /// <summary>
        /// 固定
        /// </summary>
     
        /// <summary>
        /// 菜品类型ID
        /// </summary>
        public string SelfoodtypeID { get; set; }
        /// <summary>
        /// 预定表Id
        /// </summary>
        public string SelTableID { get; set; }
        /// <summary>
        /// 预定表时间
        /// </summary>
        public DateTime MData { get; set; }
        /// <summary>
        /// 规则类型ID
        /// </summary>
        public string RuleTypeId { get; set; }
        /// <summary>
        /// 套餐ID
        /// </summary>
        public string SelpackageID { get; set; }

        public ExIndex_table Table { get; set; }
        /// <summary>
        /// 口味1 口味 2忌口
        /// </summary>
        public int TasteType { get; set; }
        /// <summary>
        /// 服务员ID
        /// </summary>
        public string sellerId { get; set; }
        /// <summary>
        /// 上交现金（交班用）
        /// </summary>
        public decimal SjMoney { get; set; }
        /// <summary>
        /// 下一班备用金
        /// </summary>
        public decimal BMoney { get; set; }
        /// <summary>
        /// 打印机ID
        /// </summary>
        public string PrintID { get; set; }
        
    }
}
