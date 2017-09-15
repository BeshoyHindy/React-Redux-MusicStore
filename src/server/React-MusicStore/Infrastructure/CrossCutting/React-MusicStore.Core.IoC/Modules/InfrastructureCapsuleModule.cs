using Autofac;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Data.Context.Interfaces;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class InfrastructureCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(ContextManager<>)).As(typeof(IContextManager<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>)).InstancePerLifetimeScope();

			builder.RegisterType<DbMusicStoreContext>().As<IDbContext>().InstancePerLifetimeScope();

			base.Load(builder);
        }
    }
}
