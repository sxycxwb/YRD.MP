using System;
using System.Collections.Generic;
using System.Linq;
//using System.Data;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Transactions;
using System.Data.Entity;

namespace Repository
{
    /// <summary>
    /// 数据操作基本实现类，公用实现方法
    /// add Xin by 2017-03-19
    /// </summary>
    /// <typeparam name="T">具体操作的实体模型</typeparam>
    public abstract class EFRepositoryBase<T> where T : class
    {
        #region 数据库上下文，事务，缓存，清除EF实体状态跟踪等 

        #region 上下文 DbContext,private不向外公开其属性
        /// <summary>
        /// 数据上下文--->根据DataBase实体模型名称进行更改
        /// </summary>
        public EFContext Context
        {
            get
            {
                var context = EFContextFactory.GetHttpContextDbContext();
                #region 禁用些属性，这个MyCat 上下文 不支持
                context.Configuration.ValidateOnSaveEnabled = false;
                context.Configuration.AutoDetectChangesEnabled = false;
                #endregion
                return context;
            }
        }
        /// <summary>
        /// 公用泛型处理属性
        /// 注:所有泛型操作的基础,总体不跟踪实体状态
        /// </summary>
        private IQueryable<T> dbSet
        {
            get { return this.Context.Set<T>().AsNoTracking(); }
        }
        #endregion

        #region 在EF中使用数据库的事务接口
        /// <summary>
        /// 调用时using(var tran=DB.Member_Info.BeginTransaction)  提交：tran.Commit()   回滚：tran.Rollback()
        /// </summary>
        public TransactionScope Transaction
        {
            get
            {
                //var tran = this.Context.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
                TransactionOptions transactionOption = new TransactionOptions();
                //设置事务隔离级别
                transactionOption.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
                // 设置事务超时时间为60秒
                transactionOption.Timeout = new TimeSpan(0, 0, 60);
                var tran = new System.Transactions.TransactionScope(TransactionScopeOption.Required, transactionOption);
                return tran;
            }
        }
        /// <summary>
        /// 清空跟踪的实体对象（当事务过程中抛异常时用）
        /// 因为 当事务回滚时，实体中查询出的对象已被修改，但数据库里回滚了，这样就不一致了，
        /// 暂时没找到更好的解决办法，只能清空DbContext，以后查的数据才与数据库一致
        /// </summary>
        public void ClearDbContext()
        {
            Stopwatch sw = new Stopwatch();  //计时器
            sw.Start();
            var count = this.Context.ChangeTracker.Entries().Count();
            ClearState(this.Context.ChangeTracker.Entries());
            sw.Stop();
            LogHelper.SQL("清除实体跟踪数量:" + count + " ，执行时间：" + sw.Elapsed);
        }
        /// <summary>
        /// 清除上下文的跟踪状态
        /// </summary>
        /// <param name="list"></param>
        private void ClearState(IEnumerable<DbEntityEntry> list)
        {
            try
            {
                if (list == null) return;
                foreach (var item in list)
                {
                    if (item != null)
                    {
                        item.State = EntityState.Detached;
                    }
                }
            }
            catch (Exception e)
            {
                LogHelper.Error("ClearState出错：" + WebTools.getFinalException(e));
                throw;
            }
        }
        #endregion

        #endregion

        #region 新增
        /// <summary>
        /// 单模型新增
        /// </summary>
        /// <param name="entity">数据模型</param>
        /// <returns></returns>
        public virtual bool Insert(T entity, T e2 = null, T e3 = null)
        {
            List<T> list = new List<T>();
            list.Add(entity);
            if (e2 != null)
            {
                list.Add(e2);
            }
            if (e3 != null)
            {
                list.Add(e3);
            }
            return Insert(list) > 0;
        }
        /// <summary>
        /// 多模型新增 含事务
        /// </summary>
        /// <param name="entitys">数据模型集合</param>
        /// <returns></returns>
        public virtual int Insert(List<T> entitys, int count = 0)
        {
            return Insert<T>(entitys, count);
        }

        /// <summary>
        /// 增加多模型数据，指定独立模型集合
        /// </summary>
        public virtual int Insert<T1>(List<T1> entitys, int count = 0) where T1 : class
        {
            List<DbEntityEntry> E = new List<DbEntityEntry>();
            int r = 0;
            try
            {
                foreach (var item in entitys)
                {
                    var entry = this.Context.Entry(item);
                    entry.State = EntityState.Added;
                    E.Add(entry);
                }
                r = this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                if (count < 1)
                {
                    // 清除整体上下文的跟踪状态,然后再试一次，若再失败，就不再试了
                    ClearDbContext();
                    LogHelper.Error("添加失败：" + WebTools.getFinalException(e));
                    // 再试一次
                    return Insert(entitys, count + 1);
                }
                else
                {
                    LogHelper.Error("添加出错2：" + WebTools.getFinalException(e));
                    throw;
                }
            }
            finally
            {
                //取消跟踪状态
                ClearState(E);
            }
            return r;
        }
        #endregion

        #region 更新
        /// <summary>
        /// 单模型更新
        /// </summary>
        /// <param name="entity">数据模型</param>
        /// <returns></returns>
        //public virtual bool Update(T entity)
        //{
        //    List<T> list = new List<T>();
        //    list.Add(entity);
        //    return Update(list) > 0;
        //}
        public virtual bool Update(T entity1, T entity2 = null, T entity3 = null)
        {
            List<T> list = new List<T>();
            list.Add(entity1);
            if (entity2 != null)
            {
                list.Add(entity2);
            }
            if (entity3 != null)
            {
                list.Add(entity3);
            }
            return Update(list) > 0;
        }
        /// <summary>
        /// 单模型更新
        /// </summary>
        /// <param name="list">数据模型</param>
        /// <returns></returns>
        public virtual int Update(List<T> list, int count = 0)
        {
            List<DbEntityEntry> E = new List<DbEntityEntry>();
            int r = 0;
            try
            {
                foreach (var item in list)
                {
                    var entry = this.Context.Entry(item);
                    entry.State = EntityState.Modified;
                    E.Add(entry);
                }
                r = this.Context.SaveChanges();
            }
            catch (Exception e)
            {
                if (count < 1)
                {
                    // 清除整体上下文的跟踪状态,然后再试一次，若再失败，就不再试了
                    ClearDbContext();
                    LogHelper.Error("更新失败：" + WebTools.getFinalException(e));
                    // 再试一次
                    return Update(list, count + 1);
                }
                else
                {
                    LogHelper.Error("更新出错2：" + WebTools.getFinalException(e));
                    throw;
                }
            }
            finally
            {
                //取消跟踪状态
                ClearState(E);
            }
            return r;
        }
        /// <summary>
        /// 更新模型记录，如不存在进行添加操作
        /// </summary>
        public virtual bool SaveOrUpdate(T entity, bool isEdit)
        {
            try
            {
                return isEdit ? Update(entity) : Insert(entity);
            }
            catch (Exception e) { throw e; }
        }
        #endregion

        #region 删除

        /// <summary>
        /// 删除一条或多条模型记录，含事务
        /// </summary>
        public virtual int Delete(Expression<Func<T, bool>> predicate = null, int count = 0)
        {
            int rows = 0;
            List<DbEntityEntry> E = new List<DbEntityEntry>();   //记录跟踪状态的对象集合
            try
            {
                IQueryable<T> list = Where(predicate);
                if (list.Any())
                {
                    foreach (var item in list)
                    {
                        var entry = this.Context.Entry(item);
                        entry.State = EntityState.Deleted;
                        E.Add(entry);
                    }
                    rows = this.Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                if (count < 1)
                {
                    // 清除整体上下文的跟踪状态,然后再试一次，若再失败，就不再试了
                    ClearDbContext();
                    LogHelper.Error("删除出错：" + WebTools.getFinalException(e));
                    // 再试一次
                    return Delete(predicate, count + 1);
                }
                else
                {
                    LogHelper.Error("删除出错2：" + WebTools.getFinalException(e));
                    throw;
                }
            }
            finally
            {
                //取消跟踪状态
                ClearState(E);
            }
            return rows;
        }

        /// <summary>
        /// 使用原始SQL语句,含事务处理
        /// </summary>
        public virtual int Delete(string sql, params DbParameter[] para)
        {
            try
            {
                return this.Context.Database.ExecuteSqlCommand(sql, para);
            }
            catch
            {
                throw;
            }
        }
        public virtual int Delete(T t, int count = 0)
        {
            List<T> list = new List<T>();
            list.Add(t);
            return Delete<T>(list, count);
        }
        /// <summary>
        /// 批量删除数据，当前模型
        /// </summary>
        public virtual int Delete(List<T> list, int count = 0)
        {
            return Delete<T>(list, count);
        }
        /// <summary>
        /// 批量删除数据，自定义模型
        /// </summary>
        public virtual int Delete<M>(List<M> list, int count = 0) where M : class
        {
            int rows = 0;
            List<DbEntityEntry> E = new List<DbEntityEntry>();   //记录跟踪状态的对象集合
            try
            {
                if (list.Any())
                {
                    foreach (var item in list)
                    {
                        var entry = this.Context.Entry(item);
                        entry.State = EntityState.Deleted;
                        E.Add(entry);
                    }
                    rows = this.Context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                if (count < 1)
                {
                    // 清除整体上下文的跟踪状态,然后再试一次，若再失败，就不再试了
                    ClearDbContext();
                    LogHelper.Error("删除出错：" + WebTools.getFinalException(e));
                    // 再试一次
                    return Delete(list, count + 1);
                }
                else
                {
                    LogHelper.Error("删除出错2：" + WebTools.getFinalException(e));
                    throw;
                }
            }
            finally
            {
                //取消跟踪状态
                ClearState(E);
            }
            return rows;
        }

        #endregion


        #region EF lamada表达式封装常用语法

        #region Where 根据条件查找
        /// <summary>
        /// 根据拉姆达表达式查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IQueryable<T> Where(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.dbSet.AsQueryable<T>();
            }
            return this.dbSet.Where(predicate);
        }
        #endregion

        #region FirstOrDefault 查找第一条
        /// <summary>
        /// 查询单模型对象
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return dbSet.FirstOrDefault();
            }
            return dbSet.FirstOrDefault(predicate);
        }
        #endregion

        #region Find 通过主键查找第一个
        /// <summary>
        /// 通过主键查找第一个
        /// </summary>
        /// <param name="parameters">主键值，类型要一致</param>
        /// <returns>查找结果</returns>
        public T Find(params object[] parameters)
        {
            var model = this.Context.Set<T>().Find(parameters);
            if (model != null)
            {
                //清除跟踪状态
                var e = this.Context.Entry(model);
                if (e != null)
                {
                    e.State = EntityState.Detached;
                }
            }
            return model;
        }
        #endregion

        #region ToList 查找并转化成List<T>
        public virtual List<T> ToList(Expression<Func<T, bool>> predicate = null)
        {
            return Where(predicate).ToList();
        }
        #endregion

        #region Any 是否存在记录
        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual bool Any(Expression<Func<T, bool>> predicate = null)
        {
            return FirstOrDefault(predicate) != null;
            //if (predicate == null)
            //{
            //    return this.dbSet.Any(a => true);
            //}
            //return this.dbSet.Any(predicate);
        }
        #endregion

        #region Count 求取记录条数
        /// <summary>
        /// 查询条数Count
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual long LongCount(Expression<Func<T, bool>> predicate = null)
        {
            return Where(predicate).LongCount();
        }
        public virtual long EFCount(Expression<Func<T, bool>> predicate = null)
        {
            return (int)LongCount(predicate);
        }
        #endregion

        #region Include 主外键表时
        //public IQueryable<T> Include(string name)
        //{
        //    //Context.Configuration.LazyLoadingEnabled = false;
        //    //Context.Configuration.ProxyCreationEnabled = false;
        //    return this.dbSet.Include(name);
        //}
        #endregion

        #region OrderBy
        /// <summary>
        /// 正序
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IOrderedQueryable<T> OrderBy<Key>(Expression<Func<T, Key>> selector)
        {
            return this.dbSet.OrderBy(selector);
        }
        /// <summary>
        /// 倒序
        /// </summary>
        /// <typeparam name="Key"></typeparam>
        /// <param name="selector"></param>
        /// <returns></returns>
        public IOrderedQueryable<T> OrderByDescending<Key>(Expression<Func<T, Key>> selector)
        {
            return this.dbSet.OrderByDescending(selector);
        }
        #endregion

        #endregion

        #region SqlQuery 执行sql语句查询
        //public IEnumerable<N> SqlQuery<N>(string sql)
        //{
        //    return Context.Database.SqlQuery<N>(sql);
        //}
        #endregion

        #region 执行存储过程
        /// <summary>
        /// 执行返回影响行数的存储过程
        /// </summary>
        /// <param name="procname">过程名称</param>
        /// <param name="parameter">参数对象</param>
        /// <returns></returns>
        public virtual object ExecuteProc(string procname, params DbParameter[] parameter)
        {
            try
            {
                return ExecuteSqlCommand(procname, parameter);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region ADO.NET增删改查方法 ExecuteSqlCommand
        /// <summary>
        /// 执行增删改方法,含事务处理
        /// </summary>
        public virtual object ExecuteSqlCommand(string sql, params DbParameter[] para)
        {
            return this.Context.Database.ExecuteSqlCommand(sql, para);
        }
        /// <summary>
        /// 执行多条SQL，增删改方法,含事务处理
        /// </summary>
        public virtual object ExecuteSqlCommand(Dictionary<string, object> sqllist)
        {
            int rows = 0;
            IEnumerator<KeyValuePair<string, object>> enumerator = sqllist.GetEnumerator();
            while (enumerator.MoveNext())
            {
                rows += this.Context.Database.ExecuteSqlCommand(enumerator.Current.Key, enumerator.Current.Value);
            }
            return rows;
        }
        #endregion
    }
}
