using Autofac;
using Autofac.Extras.DynamicProxy;
using Bootcamp.WebAPI.Core.Aspects;
using Bootcamp.WebAPI.Core.Utilities.Interceptor;
using Bootcamp.WebAPI.Filters;
using Bootcamp.WebAPI.Repositories;
using Castle.DynamicProxy;

namespace Bootcamp.WebAPI.Services.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CheckProductIdActionFilter>().InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
                new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
