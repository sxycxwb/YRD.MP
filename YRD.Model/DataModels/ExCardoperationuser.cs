using System;

namespace YRD.Model.DataModels
{
    public class ExCardoperationuser
    {
        public string ID { get; set; }
        public DateTime CreateTime { get; set; }
        public string CardUserPhone { get; set; }
        public int Integral { get; set; }
        public int MoneyCount { get; set; }
        public decimal Money1 { get; set; }
        public decimal Money2 { get; set; }
        public string CardName { get; set; }
        public decimal MoneyDiscount { get; set; }
        public string CardUserName { get; set; }
        public decimal ChangeMoney { get; set; }
    }
}