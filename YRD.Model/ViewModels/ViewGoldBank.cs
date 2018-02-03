using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Dao;

namespace YRD.Model.ViewModels
{
    public class ViewShopSms
    {
        public int SmsCount { get; set; }
    }



    public class ViewAddMessageRecharge
    {
        public List<syssmspackageprice> ListSmsPackagePrice { get; set; }

        public int SmsCount { get; set; }

        public decimal Price { get; set; }

        public string PayPassword { get; set; }
    }




}
