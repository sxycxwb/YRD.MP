using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YRD.Model.ViewModels
{
    public class ViewHot
    {
        public string Name { get; set; }

        public string Url { get; set; }
    }
    public class ViewHotList:Base
    {
        public List<ViewHot> List { get; set; } 
    }
}
