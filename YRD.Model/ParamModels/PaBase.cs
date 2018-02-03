using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YRD.Model
{
    /// <summary>
    /// 输入参数基类
    /// </summary>
    public class PaBase
    {
        /// <summary>
        /// 管理人员，一般是登录人的id
        /// </summary>
        public string ManagerId { get; set; }
        /// <summary>
        /// 安全验证的token    
        ///PaBase paReturn = new PaBase();
        ///PaToken patoken = new PaToken();
        ///patoken.ManagerId = "";
        ///patoken.ShopId = "";
        ///Token = RsaHelper.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(patoken), RsaHelper.public_key);
        ///登录成功的时候，端上会返回这个Token的值，每次接口提交都需要带上相关参数，Token需要带上登录成功时候返回的参数
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        ///店铺id
        /// </summary>
        public string ShopId { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string TimeStamp { get; set; }

    }


    /// <summary>
    /// 
    /// </summary>
    public class PaPage : PaBase
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; } = 1;
        /// <summary>
        /// 每页条数
        /// </summary>
        public int PageSize { get; set; } = 10;

    }


    /// <summary>
    /// Token模型
    /// </summary>
    public class PaToken
    {
        /// <summary>
        /// 管理人员编号
        /// </summary>
        public string ManagerId { get; set; }
        /// <summary>
        ///店铺id
        /// </summary>
        public string ShopId { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string TimeStamp { get; set; }

    }


    /// <summary>
    /// 输入参数基类扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaBase<T> : PaBase
    {
        /// <summary>
        /// 输入参数 数据列表
        /// </summary>
        public List<T> List;
    }
    /// <summary>
    /// 带data对象的输入参数
    /// </summary>
    /// <typeparam name="T">data</typeparam>
    public class PaData<T> : PaBase
    {
        /// <summary>
        /// 输入参数 数据列表
        /// </summary>
        public T Data;
    }
    /// <summary>
    /// 输入参数
    /// </summary>
    /// <typeparam name="T">从表 数据列表</typeparam>
    /// <typeparam name="P">主表对象数据</typeparam>
    public class PaBase<T, P> : PaBase
    {
        /// <summary>
        /// 数据列表，从表
        /// </summary>
        public List<T> List;
        /// <summary>
        /// 主表对象
        /// </summary>
        public P Data;
    }


    /// <summary>
    /// 输入参数基类扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaBaseWithPaging<T> : PaPage
    {
        /// <summary>
        /// 输入参数 数据列表
        /// </summary>
        public List<T> List;
    }
    /// <summary>
    /// 带data对象的输入参数
    /// </summary>
    /// <typeparam name="T">data</typeparam>
    public class PaDataWithPaging<T> : PaPage
    {
        /// <summary>
        /// 输入参数 数据列表
        /// </summary>
        public T Data;
    }
    /// <summary>
    /// 输入参数
    /// </summary>
    /// <typeparam name="T">从表 数据列表</typeparam>
    /// <typeparam name="P">主表对象数据</typeparam>
    public class PaBaseWithPaging<T, P> : PaPage
    {
        /// <summary>
        /// 数据列表，从表
        /// </summary>
        public List<T> List;
        /// <summary>
        /// 主表对象
        /// </summary>
        public P Data;
    }


}
