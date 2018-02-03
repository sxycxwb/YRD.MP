using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExArticle
    {
        public int ID { get; set; }
        public string Title { get; set; }
        
        public int? Sort { get; set; }
        public DateTime CreateTime { get; set; }
    }
    public class ExChannelArticle 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ExArticle> List { get; set; }
    }
    public class ExChannelArticleList : Base
    {
        public List<ExChannelArticle> List { get; set; }
    }
    public class ExArticleList:Base
    {
        public List<ExArticle> List { get; set; }
    }
    public class ExArticleDetail:Base
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int ChannelID { get; set; }
        public string Source { get; set; }
        public string ToURL { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }
        public int Clicks { get; set; }
        public int? Sort { get; set; }
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public string Keyword { get; set; }
    }
}
