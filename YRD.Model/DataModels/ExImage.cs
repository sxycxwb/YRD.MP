using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExImage
    {
        public string GUID { get; set; }
        public string ImageUrl { get; set; }
        public string ThumImageUrl { get; set; }
        public string ImageName { get; set; }
        public int? Sort { get; set; }
    }
    public class ExNewResource
    {
        public string GUID { get; set; }
        public string OriginalURL { get; set; }
        public string ThumbnailURL { get; set; }
        public string ImageName { get; set; }
        public int? Audit { get; set; }
    }
    public class ExImageList : Base
    {
       public List<ExImage> List { get; set; }
    }
}
