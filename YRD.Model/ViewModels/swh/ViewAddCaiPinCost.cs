using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model.DataModels;

namespace YRD.Model.ViewModels
{
    /// <summary>
    /// 菜品费用
    /// </summary>
    public class ViewAddCaiPinCost
    {
        /// <summary>
        /// 菜品编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 0 半成品 1 成品
        /// </summary>
        public int FinishType { get; set; }

        /// <summary>
        /// 是否有规格
        /// </summary>
        public int IsHavePecification { get; set; }
        /// <summary>
        /// 规格编号
        /// </summary>

        public string FoodSpecificationsID { get; set; }

        /// <summary>
        /// 规格名称
        /// </summary>
        public string SpecTitle { get; set; }

        /// <summary>
        /// 主料成本
        /// </summary>
        public List<ViewMaterial> MainMaterial { get; set; }
        /// <summary>
        /// 辅料成本
        /// </summary>
        public List<ViewMaterial> ChildMaterial { get; set; }

        /// <summary>
        /// 是否展示主料
        /// </summary>
        public bool IsMainMaterial { get; set; }
        /// <summary>
        /// 是否展示副料
        /// </summary>
        public bool IsChildMaterial { get; set; }
        /// <summary>
        /// 主料成本
        /// </summary>
        public decimal MainMaterialAveragePrice { get; set; }
        /// <summary>
        /// 辅料成本
        /// </summary>

        public decimal AuxiliaryMaterialAveragePrice { get; set; }

        /// <summary>
        /// 物料成本
        /// </summary>
        public decimal TotalMaterialAveragePrice { get; set; }




    }

}
