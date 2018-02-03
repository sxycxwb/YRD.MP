namespace YRD.Model.ParamModels
{
    /// <summary>
    /// 
    /// </summary>
    public class PaFood:PaBase
    {
        /// <summary>
        /// 类型名称
        /// </summary>
        public string FoodTypeID;
        /// <summary>
        /// 类别 对应名称的类别 1菜品名称 2套餐名称 3固定费用
        /// </summary>
        public int Type;

        /// <summary>
        /// 菜品id
        /// </summary>
        public string FoodId { get; set; }
        /// <summary>
        /// 菜品名称
        /// </summary>
        public string FoodName { get; set; }
        /// <summary>
        /// 规格Id
        /// </summary>
        public string Ruleid { get; set; }
        /// <summary>
        /// 规格名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 属性id
        /// </summary>
        public string Aubitid { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string AubitName { get; set; }
        /// <summary>
        /// 对应价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 订单Id
        /// </summary>
        public string oid { get; set; }
    }
}