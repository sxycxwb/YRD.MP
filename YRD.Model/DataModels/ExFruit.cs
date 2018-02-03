using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExFruit : Base
    {
        /// <summary>
        /// 收获类型
        /// </summary>
        public int HavestType { get; set; }
        /// <summary>
        /// 消耗价格
        /// </summary>
        public decimal Consume { get; set; }
        /// <summary>
        /// 收入价格
        /// </summary>
        public decimal Income { get; set; }
    }

    public class MyFruit : Base
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
        /// 上次收获描述
        /// </summary>
        public string LastHavestDesc { get; set; }


    }

    /// <summary>
    /// 种植模型
    /// </summary>
    public class PlantModel
    {
        public string uguid { get; set; }
        public decimal price { get; set; }
        public int FruitType { get; set; }

    }

    /// <summary>
    /// 收获模型
    /// </summary>
    public class HavestModel
    {
        public string uguid { get; set; }
        public string fpguid { get; set; }
    }


    public class ExPlant
    {
        public string UserName { get; set; }
        public int FruitType { get; set; }

        public string FruitTypeDesc { get; set; }
        public decimal Consume { get; set; }

        /// <summary>
        /// 播种状态 1 已播种 2 已收获
        /// </summary>
        public int Status { get; set; }
        public DateTime DT { get; set; }
        public string BatchId { get; set; }
    }

    public class ExPlantList : Base
    {
        public List<ExPlant> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }

    public class ExHavest
    {
        public string UserName { get; set; }
        public int HavestType { get; set; }
        public decimal Income { get; set; }
        public string Remark { get; set; }
        public DateTime DT { get; set; }
        public string BatchId { get; set; }
    }

    public class ExHavestList : Base
    {
        public List<ExHavest> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }



    /// <summary>
    /// 果实类型
    /// </summary>
    public class FruitType
    {
        public int Key { get; set; }

        public string Value { get; set; }
    }
}
