using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using HtmlToPdf.Lib;

namespace HtmlToPdf.Web.App_Start
{
    public class IocConfig
    {
        private static IContainer _container;
        public static IContainer Container => _container;

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            var current = typeof(IocConfig).Assembly;

            builder.RegisterControllers(current).PropertiesAutowired();
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.RegisterFilterProvider();
            builder.RegisterModelBinders(current);
            builder.RegisterModelBinderProvider();

            builder.RegisterType<HtmlToPdfConverter>().As<IHtmlToPdfConverter>().InstancePerLifetimeScope();

            var container = builder.Build();

            _container = container;

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}