using L.Test.Core;
//using L.Test.Data;
using L.Test.Data.Initialize;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
namespace L.Test.API
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //设依赖注入容器
           
            //IUnityContainer container = GetUnityContainer();
            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            //数据库生成初始入口
            DatabaseInitializer.Initialize();

            //关闭XML返回格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            //序列化与反序列化，不是特别优秀的解决循环引用的一种方式
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            //using (var dbcontext = new EFDbContext())
            //{
            //    var objectContext = ((IObjectContextAdapter)dbcontext).ObjectContext;
            //    var mappingCollection = (StorageMappingItemCollection)objectContext.MetadataWorkspace.GetItemCollection(DataSpace.CSSpace);
            //    mappingCollection.GenerateViews(new List<EdmSchemaError>());
            //}
        }

        private IUnityContainer GetUnityContainer()
        {
            //Create UnityContainer          
            IUnityContainer container = new UnityContainer()
                //.RegisterType<IControllerActivator, CustomControllerActivator>() // No nned to a controller activator
            .RegisterType<IUserCore, IUserCore>();
            return container;
        }
    }
}