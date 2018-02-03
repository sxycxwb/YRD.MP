using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace YRD.SO.Common
{
    public class ConstantManager
    {
        Manager manager;
        public ConstantManager(Manager manager)
        {
            this.manager = manager;

        }

        private string datetimeFormat;
        /// <summary>
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string DataTimeFormat
        {
            get
            {
                if (string.IsNullOrEmpty(datetimeFormat))
                {
                    datetimeFormat = "yyyy-MM-dd HH:mm:ss";
                }
                return datetimeFormat;
            }
        }

        private string dateFormat;

        public string DateFormat
        {
            get
            {
                if (string.IsNullOrEmpty(dateFormat))
                {
                    dateFormat = "yyyy-MM-dd";
                }
                return dateFormat;
            }
        }


    }
}