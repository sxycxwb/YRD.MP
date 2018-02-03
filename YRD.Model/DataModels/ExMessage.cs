using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExMessage
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TypeName { get; set; }
        public DateTime CreateTime { get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
        public string TypeCode { get; set; }
        public string ImgURL { get; set; }
        public int SupplyOrDemand { get; set; }
        public bool IsFirst { get; set; }
        public string Content { get; set; }
        public string MinContent { get; set; }
        public int? TopImg { get; set; }
        public bool IsRedPacket { get; set; }
    }

    public class ExMessageList : Base
    {
        public List<ExMessage> List { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageIndex { get; set; }
    }

    public class ExMessageImgList : Base
    {
        public List<ExMessageImg> List { get; set; }
    }
    public class ExMessageImg
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImgURL { get; set; }
    }
    #region 信息详情
    public class ExMessageDetail : Base
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string TypeName { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EndTime { get; set; }
        public string ProductPlace { get; set; }
        public string ProductUnit { get; set; }
        public string ProductNumber { get; set; }
        public string ProductPrice { get; set; }
        public string WebSite { get; set; }
        public string Brand { get; set; }
        public string CityCode { get; set; }
        public string TypeCode { get; set; }
        public string ImgURL { get; set; }
        public int SupplyOrDemand { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public string MinContent { get; set; }
        public int Click { get; set; }
        public int IsCheck { get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
        public string IP { get; set; }
        public string GUID { get; set; }
        public int Audit { get; set; }
        public string AuditReason { get; set; }
        public int Days { get; set; }
        public int? TopImg { get; set; }

        public int Spread { get; set; }

        public string BatchId { get; set; }
    }


    public class ExMessageDetailList : Base
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public List<ExMessageDetail> List { get; set; }
    }
    #endregion

    public class ExMessageContact
    {
        public int HasPermission { get; set; }
        public string ContactName { get; set; }
        public string Mobile { get; set; }
        public string Telephone { get; set; }
        public string QQ { get; set; }
        public string Email { get; set; }
    }
}
