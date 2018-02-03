using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class RegexHelper
{
    /// <summary>
    /// 生成N位随机数
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static Base CheckPassword(string password)
    {
        Base b = new Base();
        Regex regex = new Regex("^[/@A-Za-z0-9/!/#/$/%/^/&/*/./~/</>/?/-/+]{6,30}$");
        if (regex.IsMatch(password))
        {
            b.Code = 1;
        }
        else
        {
            b.Code = 0;
            b.Message = "密码格式不正确，密码长度不能低于6位且不能带有特殊字符！";
        }
        return b;
    }
    /// <summary>
    ///验证消息标题
    /// </summary>
    /// <param name="length"></param>
    /// <returns></returns>
    public static Base CheckMessageTitle(string title)
    {
        Base b = new Base();
        Regex regex = new Regex("^[\u4e00-\u9fa5]{1,50}$");
        if (regex.IsMatch(title))
        {
            b.Code = 1;
        }
        else
        {
            b.Code = 0;
            b.Message = "信息标题只能为汉字,不能输入数字字母及其他特殊字！";
        }
        return b;
    }

    public static Base CheckUserName(string username)
    {
        Base b = new Base();
        Regex regex = new Regex("^[\u4e00-\u9fa5a-zA-Z0-9]{4,16}$");
        if (regex.IsMatch(username))
        {
            b.Code = 1;
        }
        else
        {
            b.Code = 0;
            b.Message = "用户名长度不能少于4位且不允许带有特殊符号！";
        }
        return b;
    }


    public static Base CheckContent(string content)
    {
        Base b = new Base();
        Regex regex = new Regex(@"[0123456789零一二三四五六七八九壹贰叁肆伍陆柒捌玖]{1}[0-9零一二三四五六七八九壹贰叁肆伍陆柒捌玖^(\s\S)]{5,15}[0123456789零一二三四五六七八九壹贰叁肆伍陆柒捌玖]{1}");
        if (regex.IsMatch(content))
        {
            b.Code = 0;
            b.Message = "信息内容不允许包含联系方式等词语，请检查后重新发布！";

        }
        else
        {
            b.Code = 1;
        }
        return b;
    }

}

