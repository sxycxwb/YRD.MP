using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DateTimeHelper
{
    /// <summary> 
    /// 计算某日起始日期（礼拜一的日期） 
    /// </summary> 
    /// <param name="someDate">该周中任意一天</param> 
    /// <returns>返回礼拜一日期，后面的具体时、分、秒和传入值相等</returns> 
    public static DateTime GetMondayDate(DateTime someDate)
    {
        int i = someDate.DayOfWeek - DayOfWeek.Monday;
        if (i == -1) i = 6;// i值 > = 0 ，因为枚举原因，Sunday排在最前，此时Sunday-Monday=-1，必须+7=6。 
        TimeSpan ts = new TimeSpan(i, 0, 0, 0);
        return someDate.Subtract(ts);
    }
    /// <summary>
    /// 获得本月初时间
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static DateTime GetMonthStart(DateTime dt)
    {
        DateTime startMonth = dt.AddDays(1 - dt.Day);  //本月月初
        return startMonth;
    }

    /// <summary>
    /// 把空的时间转成字符串
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string ConvertDateTimeToString(DateTime? dt, string format = FormatHelper.DataTimeFormat)
    {
        string str = "";
        if (dt.HasValue)
        {
            str = dt.Value.ToString(FormatHelper.DataTimeFormat);
        }

        return str;
    }
}

