using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model.ViewModels
{
    public class UpFileModel
    {

        public string filepath { get; set; }
        public string oldfilename { get; set; }
        public int status { get; set; }
        public string filelink { get; set; }
        public string error { get; set; }
    }
}
