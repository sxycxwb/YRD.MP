namespace YRD.Model.DataModels
{
    /// <summary>
    /// 喜爱与不喜爱口味
    /// </summary>
    public class ExSelFoodtaste
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 1 口味 2忌口
        /// </summary>
        public int TasteType { get; set; }
    }
}