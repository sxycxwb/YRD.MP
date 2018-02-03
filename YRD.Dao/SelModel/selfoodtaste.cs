namespace YRD.Dao
{
    /// <summary>
    /// 口味表
    /// </summary>
    public class selfoodtaste
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