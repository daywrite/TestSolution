using L.Test.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Data.Initialize
{
    /// <summary>
    /// 数据库初始化操作类
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// 数据库初始化
        /// </summary>
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFDbContext, Configuration>());
            using (var db = new EFDbContext())
            {
                db.Database.Initialize(false);

                //var objectContext = ((IObjectContextAdapter)db).ObjectContext;
                //var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
                //mappingCollection.GenerateViews(new List<EdmSchemaError>());
            }
        }
        /// <summary>
        /// 数据库初始化
        /// </summary>
        //public static void Initialize()
        //{
        //    Database.SetInitializer(new SampleData());
        //    using (var db = new EFDbContext())
        //    {
        //        db.Database.Initialize(false);
        //    }
        //}
    }
}
