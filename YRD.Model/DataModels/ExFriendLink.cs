using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.DataModels
{
    public class ExFriendLink
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public int? Sort { get; set; }
    }

    public class ExFriendLinkList : Base
    {
        public List<ExFriendLink> List { get; set; }
    }
}
