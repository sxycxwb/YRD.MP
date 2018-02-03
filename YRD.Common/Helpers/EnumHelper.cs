using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EnumHelper
{
    public static string GetEnumDescription(object e)
    {
        //获取字段信息 
        System.Reflection.FieldInfo[] ms = e.GetType().GetFields();
        Type t = e.GetType();
        foreach (System.Reflection.FieldInfo f in ms)
        {
            //判断名称是否相等 
            if (f.Name != e.ToString()) continue;

            //反射出自定义属性 
            foreach (Attribute attr in f.GetCustomAttributes(true))
            {
                //类型转换找到一个Description，用Description作为成员名称 
                System.ComponentModel.DescriptionAttribute dscript = attr as System.ComponentModel.DescriptionAttribute;
                if (dscript != null)
                    return dscript.Description;
            }
        }
        //如果没有检测到合适的注释，则用默认名称 
        return e.ToString();
    }

    /// <summary>
    /// 根据枚举获得其对应的注释描述
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Dictionary<int, string> GetEnumDescription(Type type)
    {
        Dictionary<int, string> dic = new Dictionary<int, string>();
        Array arrValues = Enum.GetValues(type);

        foreach (object value in arrValues)
        {
            string text = GetEnumDescription(value);
            dic.Add(Convert.ToInt32(value), text);
        }
        return dic;
    }

}

