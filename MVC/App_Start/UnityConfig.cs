using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.EfCommands;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace MVC.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(Container);
        }

        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new UnityContainer();
                    _container.SetupContainer();
                }

                return _container;
            }
        }

        private static void SetupContainer(this IUnityContainer container)
        {
            container.RegisterInstance<IDbConnection>(new SqlConnection(@"Data Source=SHEKIBRATE\SQLEXPRESS04;Initial Catalog=WM;Integrated Security=True"));
            container.RegisterType<DbContext, WMContext>();

            container.RegisterType(typeof(IGetProductsCommand), typeof(EfGetProductsCommand));
			container.RegisterType(typeof(IAddProductCommand), typeof(EfAddProductCommand));
			container.RegisterType(typeof(IAddProductCommand), typeof(EfAddProductManufacturersCommand));
			container.RegisterType(typeof(IAddProductCommand), typeof(EfAddProductSuppliersCommand));
			container.RegisterType(typeof(IGetCategoriesCommand), typeof(EfGetCategoriesCommand));
        }
    }
}