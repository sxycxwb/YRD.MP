using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class ViewOrderFood : ViewBase
    {
        public string FoodName { get; set; }
        public string FoodTypeName { get; set; }
        public string FoodSpecificationsName { get; set; }
        public decimal GoodsCount { get; set; }
        public decimal GoodsPrice { get; set; }
        public decimal GoodsTotalPrice { get; set; }
        public int AddType { get; set; }
    }
    public class ViewModel
    {
        /// <summary>
        /// gggggg
        /// </summary>
        public string Name { get; set; }

        public List<ViewOrderFood> ListOrder { get; set; }
    }

}
