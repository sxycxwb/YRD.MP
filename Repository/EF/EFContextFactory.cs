using System;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;
using System.Web;
using YRD.Dao;

namespace Repository
{
    public sealed class EFContextFactory
    {
        #region Fields        
        /// <summary>
        /// 锁定方法用到的对象
        /// </summary>
        private readonly static object lockobj = new object();
        private static string name = "dbContext";
        private static long DBCount = 0;
        #endregion

        #region 获取当前请求对应的DbContext上下文        
        public static EFContext GetHttpContextDbContext()
        {
            lock (lockobj)
            {
                var dbContext = HttpContext.Current.Items[name] as EFContext;
                if (dbContext == null)
                {
                    #region 记录实例过多少次上下文
                    DBCount++;
                    LogHelper.SQL(name + DBCount);
                    if (DBCount > Int64.MaxValue - 10)
                    {
                        DBCount = 0;
                    }
                    #endregion

                    dbContext = new EFContext();
                    HttpContext.Current.Items[name] = dbContext;
                }
                return dbContext;
            }
        }
        #endregion 
    }
}
