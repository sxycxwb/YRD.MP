using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class ViewMyFruit : ViewBase
    {
        /// <summary>
        /// 播种编号
        /// </summary>
        public string FPGUID { get; set; }
        /// <summary>
        /// 种子类型
        /// </summary>
        public int FruitType { get; set; }

        /// <summary>
        /// 是否需要播种
        /// </summary>
        public bool IsPlant { get; set; }

        /// <summary>
        /// 是否需要收获
        /// </summary>
        public bool IsHavest { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public string UserGUID { get; set; }
        /// <summary>
        /// 上次收获描述
        /// </summary>
        public string LastHavestDesc { get; set; }
    }
}
