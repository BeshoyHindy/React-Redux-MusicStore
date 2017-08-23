using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using ReactMusicStore.Core.IoC.Modules;

namespace ReactMusicStore.Core.IoC
{
    public class InversionOfControl
    {
        public IKernel Kernel { get; private set; }

        public InversionOfControl()
        {
            Kernel = GetNinjectModules();
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }

        public StandardKernel GetNinjectModules()
        {
            return new StandardKernel(
                new ServiceNinjectModule(),
                new InfrastructureNinjectModule(),
                new RepositoryNinjectModule(),
                new ApplicationNinjectModule());
        }
    }
}
