using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Data
{
    /// <summary>
    ///     Demo项目单元操作类
    /// </summary>
    //[Export(typeof(IUnitOfWork))]
    public class EFUnitOfWorkContext : UnitOfWorkContextBase
    {
        /// <summary>
        ///     获取或设置 当前使用的数据访问上下文对象
        /// </summary>
        protected override DbContext Context
        {
            get { return EFDbContext; }
        }
        //protected override DbContext Context
        //{
        //    get
        //    {
        //        bool secondCachingEnabled = ConfigurationManager.AppSettings["EntityFrameworkCachingEnabled"].CastTo(false);
        //        return secondCachingEnabled ? EFCachingDbContext.Value : EFDbContext;
        //    }
        //}
        //protected override DbContext Context
        //{
        //    get
        //    {
        //        bool secondCachingEnabled = ConfigurationManager.AppSettings["EntityFrameworkCachingEnabled"].CastTo(false);
        //        return secondCachingEnabled ? EFCachingDbContext.Value : EFDbContext;
        //    }
        //}
        /// <summary>
        ///     获取或设置 默认的Demo项目数据访问上下文对象
        /// </summary>
        //[Import("EF",typeof (DbContext))]不能用这个？
        //[Import(typeof(DbContext))]
        //private EFDbContext EFDbContext { get; set; }
        //[Import]
        public EFDbContext EFDbContext = new EFDbContext();

        //[Import("EFCaching", typeof(DbContext))]
        //private Lazy<EFCachingDbContext> EFCachingDbContext { get; set; }
        //[Import]
        //public EFCachingDbContext EFCachingDbContext = new EFCachingDbContext();
        //[Import(typeof(DbContext))]
        //public EFDbContext EFDbContext { get; set; }
        //public EFDbContext EFDbContext = new EFDbContext();
    }
}
