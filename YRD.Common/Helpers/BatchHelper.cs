using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BatchHelper
{
    public static string GetBatchId
    {
        get
        {
            string batchId = WebTools.getGUID();
            return batchId;
        }
    }



}

