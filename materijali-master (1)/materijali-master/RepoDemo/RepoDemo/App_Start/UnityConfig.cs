using RepoDemo.Persistance;
using RepoDemo.Persistance.Repository;
using RepoDemo.Persistance.UnitOfWork;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace RepoDemo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<DbContext, DemoContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IServiceRepository, ServiceRepository>();
            container.RegisterType<IUnitOfWork, DemoUnitOfWork>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}