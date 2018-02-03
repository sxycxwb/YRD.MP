using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExRedPacket
    {
        /// <summary>
        /// 消息编号
        /// </summary>
        public int MessageId { get; set; }
        /// <summary>
        /// 红包Int编号
        /// </summary>
        public int RedPacketId { get; set; }
        /// <summary>
        /// 红包GUID编号
        /// </summary>
        public string BatchId { get; set; }
        /// <summary>
        /// 红包标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 是否可以被领取
        /// </summary>
        public bool IsAvailable { get; set; }
    }



    public class ExRedPacketDetail
    {
        public string UserId { get; set; }
        public int RedPacketId { get; set; }
        public decimal Amount { get; set; }
        public string DT { get; set; }
        /// <summary>
        /// 是否领取
        /// </summary>
        public bool IsReceive { get; set; }
    }

    public class ExRedPacketDetailList : Base
    {
        public List<ExRedPacketDetail> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }


    public class ExMessageRedPacket
    {
        public int Id { get; set; }

        public int MessageId { get; set; }
        public int RedPacketId { get; set; }

        public bool IsAvailable { get; set; }

        public decimal Amount { get; set; }

        public DateTime DT { get; set; }
    }

    public class ExMessageRedPacketList : Base
    {
        public List<ExMessageRedPacket> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }

}
