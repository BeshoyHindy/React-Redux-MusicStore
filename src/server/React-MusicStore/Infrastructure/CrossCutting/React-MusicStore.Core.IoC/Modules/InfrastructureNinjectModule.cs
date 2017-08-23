using Ninject.Modules;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbContext>().To<MusicStoreContext>();
            Bind(typeof (IContextManager<>)).To(typeof (ContextManager<>));
            Bind(typeof(IUnitOfWork<>)).To((typeof(UnitOfWork<>)));
        }
    }
}
