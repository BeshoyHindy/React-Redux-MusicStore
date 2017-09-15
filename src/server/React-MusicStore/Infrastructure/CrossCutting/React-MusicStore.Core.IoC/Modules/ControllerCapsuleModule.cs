using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Module = Autofac.Module;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class ControllerCapsuleModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            // Register the Web API Controllers
            //builder.RegisterApiControllers(Assembly.GetCallingAssembly());
            builder.RegisterApiControllers(ReferencedAssemblies.WebApi).PreserveExistingDefaults();

            base.Load(builder);
        }
    }
}