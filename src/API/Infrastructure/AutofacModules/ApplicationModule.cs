using Autofac;
using Domain.WalletAggregate;
using Infrastructure.Repositories;

namespace API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WalletRepository>()
                   .As<IWalletRepository>()
                   .InstancePerLifetimeScope();
        }
    }
}
