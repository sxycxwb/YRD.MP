namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 开台
    /// </summary>
    public class paOpenTable:PaBase
    {
        /// <summary>
        /// 餐桌位Id
        /// </summary>
        public string TableId { get; set; }
        /// <summary>
        /// 就餐人数
        /// </summary>
        public int PeopleCount { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Des { get; set; }

    
    }
}