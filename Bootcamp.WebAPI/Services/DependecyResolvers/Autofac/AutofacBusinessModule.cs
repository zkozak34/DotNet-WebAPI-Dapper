using Autofac;
using Bootcamp.WebAPI.Filters;
using Bootcamp.WebAPI.Repositories;

namespace Bootcamp.WebAPI.Services.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<CheckProductIdActionFilter>().InstancePerLifetimeScope();



        }
    }
}
