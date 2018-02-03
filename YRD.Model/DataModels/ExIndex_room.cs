using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YRD.Dao;

namespace YRD.Model.DataModels
{
    /// <summary>
    /// 主页房间列表
    /// </summary>
    public class ExIndex_room
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 桌数
        /// </summary>
        public int TableCount { get; set; }
        /// <summary>
        /// 房间状态(1空闲2正在使用3已预订4维护中5其他状态)
        /// </summary>
        public int RoomState { get; set; }
        /// <summary>
        /// 所属店铺ID
        /// </summary>
        public string ShopID { get; set; }
    }
}
