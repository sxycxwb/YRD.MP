using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.DomainModels
{
    public class ExPublishSuccessModel
    {
        /// <summary>
        /// 0 发布异常 1发布成功 2发布失败
        /// </summary>
        public bool Flag { get; set; }

        /// <summary>
        /// 发布还是更新 1发布 2更新
        /// </summary>
        public int AddOrUpdate { get; set; }
        /// <summary>
        /// 消息编号
        /// </summary>
        public int ID { get; set; }
    }


}
