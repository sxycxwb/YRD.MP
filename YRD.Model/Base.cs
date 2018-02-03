using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YRD.Model;

/// <summary>
/// 基类
/// </summary>
public class Base
{
    #region 构造器
    /// <summary>
    /// 空的构造方法,为了反序列化时使用
    /// </summary>
    public Base()
    {

    }
    public Base(string msg = null)
    {
        this.Message = msg;
    }
    public Base(bool isSuccess, string msg = null)
    {
        this.IsSuccess = isSuccess;
        if (isSuccess && msg == null)
        {
            msg = "操作成功";
        }
        this.Message = msg;
    }
    public Base(int code, string msg = null)
    {
        this.Code = code;
        if (code == 1 && msg == null)
        {
            msg = "操作成功";
        }
        this.Message = msg;
    }
    public Base(Exception e)
    {
        this.IsSuccess = false;
        var msg = e.InnerException == null ? e.Message : e.InnerException.Message;
        this.Message = msg;
        this.Description = msg;
    }
    #endregion

    #region 简单的设置成功或失败的方法
    /// <summary>
    /// 设置结果为失败
    /// </summary>
    /// <param name="message">失败的提示信息</param>
    /// <param name="description">异常信息</param>
    /// <returns></returns>
    public Base setFail(string message = "操作失败", string description = "")
    {
        this.Message = message;
        this.Description = description;
        this.Code = 0;
        return this;
    }
    /// <summary>
    /// 设置结果为失败
    /// </summary>
    /// <param name="code">设置code</param>
    /// <param name="message">设置message</param>
    /// <param name="description">异常信息</param>
    /// <returns></returns>
    public Base setFail(int code, string message = "操作失败", string description = "")
    {
        this.Message = message;
        this.Description = description;
        this.Code = code;
        return this;
    }

    /// <summary>
    /// 设置结果为成功
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <returns></returns>
    public Base setSuccess(string message = "操作成功")
    {
        this.Message = message;
        this.Code = 1;
        return this;
    }
    #endregion

    #region field 
    /// <summary>
    /// 所有处理逻辑正常的情况都应该返回 1
    /// 所有处理逻辑不正常的情况返回0
    /// 如果需要附带其他逻辑 可以返回其他参数
    ///  -200 登录超时 
    /// </summary>
    public int Code { get; set; }
    /// <summary>
    /// 返回提示的错误信息
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// 记录异常描述
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 执行是否成功，完全根据Code的值判断
    /// </summary>
    [JsonIgnore()]
    public bool IsSuccess
    {
        get
        {
            if (Code == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        set
        {
            Code = Convert.ToInt16(value);
        }
    }
    #endregion
}

/// <summary>
/// 分页基类
/// </summary>
public class PageListBase : Base
{
    /// <summary>
    /// 当前页
    /// </summary>
    public int PageIndex { get; set; } = 1;
    /// <summary>
    /// 页大小
    /// </summary>
    public int PageSize { get; set; } = 10;
    /// <summary>
    /// 记录条数
    /// </summary> 
    public int RecordCount { get; set; }
}
/// <summary>
/// 实体模型集合
/// </summary>
/// <typeparam name="T"></typeparam>
public class NewBase<T> : Base
{
    /// <summary>
    /// 扩展对象
    /// </summary>
    public T Data { get; set; }

    #region 简单的设置成功或失败的方法

    /// <summary>
    /// 设置结果为失败
    /// </summary>
    /// <param name="message">描述信息</param>
    /// <param name="description">异常信息</param>
    /// <returns></returns>
    public new NewBase<T> setFail(string message = "操作失败", string description = "")
    {
        this.Message = message;
        this.Description = description;
        this.Code = 0;
        return this;
    }
    /// <summary>
    /// 设置结果为失败
    /// </summary>
    /// <param name="code">设置code</param>
    /// <param name="message">设置message</param>
    /// <param name="description">异常信息</param>
    /// <returns></returns>
    public new NewBase<T> setFail(int code, string message = "操作失败", string description = "")
    {
        this.Message = message;
        this.Description = description;
        this.Code = code;
        return this;
    }
    /// <summary>
    /// 设置结果为成功
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <returns></returns>
    public new NewBase<T> setSuccess(string message = "操作成功")
    {
        this.Message = message;
        this.Code = 1;
        return this;
    }
    #endregion
}
/// <summary>
/// 实体模型扩展
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="P"></typeparam>
public class NewBase<T, P> : NewBase<T>
{
    /// <summary>
    /// 扩展对象2
    /// </summary>
    public P Data2 { get; set; }
}

/// <summary>
/// 列表模型带分页
/// </summary>
public class PageListWithPaging<T> : PageListBase
{
    /// <summary>
    /// 列表集合
    /// </summary>
    public List<T> List { get; set; }
    /// <summary>
    /// 空构造器
    /// </summary>
    public PageListWithPaging()
    {
    }
    /// <summary>
    /// 分页的简单构造
    /// </summary>
    /// <param name="pageIndex"></param>
    /// <param name="pageSize"></param>
    public PageListWithPaging(int pageIndex, int pageSize)
    {
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
    }
    /// <summary>
    /// 无分页构造器
    /// </summary>
    /// <param name="code">Code为1时成功，其他失败</param>
    /// <param name="list">数据列表</param>
    /// <param name="message">提示信息</param>
    /// <param name="description">错误描述信息</param>
    public PageListWithPaging(int code, List<T> list, string message = "", string description = "")
    {
        this.Code = code;
        this.List = list;
        this.PageIndex = 1;
        this.PageSize = int.MaxValue;
        this.RecordCount = list.Count;
        this.Message = message;
        this.Description = description;
    }
    /// <summary>
    /// 分页构造器
    /// </summary>
    /// <param name="code">Code为1时成功，其他失败</param>
    /// <param name="list">数据列表</param>
    /// <param name="pageIndex">当前页</param>
    /// <param name="pageSize">每页大小</param>
    /// <param name="recordCount">记录总行数</param>
    /// <param name="message">提示信息</param>
    /// <param name="description">错误描述信息</param>
    public PageListWithPaging(int code, List<T> list, int pageIndex, int pageSize, int recordCount, string message = "", string description = "")
    {
        this.Code = code;
        this.List = list;
        this.PageIndex = pageIndex;
        this.PageSize = pageSize;
        this.RecordCount = recordCount;
        this.Message = message;
        this.Description = description;
    }
    /// <summary>
    /// 设置成功
    /// </summary>
    /// <param name="list">数据列表</param>
    /// <param name="message">提示信息</param>
    public PageListWithPaging<T> setSuccess(List<T> list, string message = "操作成功")
    {
        this.Code = 1;
        if (list != null)
            this.List = list;
        if (!string.IsNullOrEmpty(message))
            this.Message = message;

        return this;
    }
    /// <summary>
    /// 设置失败
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <param name="desc">异常信息</param>
    public new PageListWithPaging<T> setFail(string message = "操作失败", string desc = null)
    {
        this.Code = 0;
        if (!string.IsNullOrEmpty(desc))
            this.Description = desc;
        if (!string.IsNullOrEmpty(message))
            this.Message = message;

        return this;
    }
    /// <summary>
    /// 设置失败
    /// </summary>
    /// <param name="e">异常对象</param>
    /// <param name="message">信息</param>
    public new PageListWithPaging<T> setFail(Exception e, string message = "操作失败")
    {
        this.Code = -100;
        if (!string.IsNullOrEmpty(message))
            this.Message = message;
        this.Description = e.Message;
        //LogHelper.Error(this.Message, e);
        return this;
    }
}

/// <summary>
/// 列表模型带分页+附加对象
/// </summary>
/// <typeparam name="T">列表对象</typeparam>
/// <typeparam name="P">附加对象，比如计算累计值或其他独立对象</typeparam>
public class PageListWithPaging<T, P> : PageListWithPaging<T>
{
    /// <summary>
    /// 附加对象，比如计算累计值或其他独立对象
    /// </summary>
    public P Data { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public PageListWithPaging() : base()
    {
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageindex"></param>
    /// <param name="pagesize"></param>
    public PageListWithPaging(int pageindex, int pagesize) : base(pageindex, pagesize)
    {
    }
}

/// <summary>
/// 列表模型不带分页
/// </summary>
public class PageListWithoutPaging<T> : Base
{
    /// <summary>
    /// 列表集合
    /// </summary>
    public List<T> List { get; set; }
    /// <summary>
    /// 空构造器
    /// </summary>
    public PageListWithoutPaging()
    {
    }
    /// <summary>
    /// 无分页构造器
    /// </summary>
    /// <param name="code">Code为1时成功，其他失败</param>
    /// <param name="list">数据列表</param>
    /// <param name="message">提示信息</param>
    /// <param name="description">错误描述信息</param>
    public PageListWithoutPaging(int code, List<T> list, string message = "", string description = "")
    {
        this.Code = code;
        this.List = list;
        this.Message = message;
    }

    /// <summary>
    /// 设置成功
    /// </summary>
    /// <param name="list">数据列表</param>
    /// <param name="message">提示信息</param>
    public PageListWithoutPaging<T> setSuccess(List<T> list, string message = "操作成功")
    {
        this.Code = 1;
        if (list != null)
            this.List = list;
        if (!string.IsNullOrEmpty(message))
            this.Message = message;

        return this;
    }
    /// <summary>
    /// 设置失败
    /// </summary>
    /// <param name="message">提示信息</param>
    /// <param name="desc">异常信息</param>
    public new PageListWithoutPaging<T> setFail(string message = "操作失败", string desc = null)
    {
        this.Code = 0;
        if (!string.IsNullOrEmpty(desc))
            this.Description = desc;
        if (!string.IsNullOrEmpty(message))
            this.Message = message;

        return this;
    }
    /// <summary>
    /// 设置失败
    /// </summary>
    /// <param name="e">异常对象</param>
    /// <param name="message">信息</param>
    public new PageListWithoutPaging<T> setFail(Exception e, string message = "操作失败")
    {
        this.Code = -100;
        if (!string.IsNullOrEmpty(message))
            this.Message = message;
        this.Description = e.Message;
        //LogHelper.Error(this.Message, e);
        return this;
    }
}