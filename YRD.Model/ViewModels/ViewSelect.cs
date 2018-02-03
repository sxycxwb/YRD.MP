using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System
{
    public class ViewSelectListItem
    {

        public string Text { get; set; }

        public string Value { get; set; }
        public ViewSelectListItem(string value, string text)
        {
            this.Value = value;
            this.Text = text;
        }

    }
}
