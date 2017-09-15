using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Core;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using Microsoft.Owin.Logging;
using Microsoft.Practices.ServiceLocation;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Data.Context.Interfaces;
using ReactMusicStore.Core.IoC.Modules;

namespace ReactMusicStore.Core.IoC
{
    public class InversionOfControl
    {
        public IContainer Container { get; private set; }


        public IContainer Initialise(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();


            //const string nameOrConnectionString = "name=KiksAppDbConnection";
            //builder.Register<IDbContext>(b =>
            //{
            //    var logger = b.ResolveOptional<ILogger>();
            //    var context = new KiksAppDbContext(nameOrConnectionString, logger);
            //    return context;
            //}).InstancePerLifetimeScope();

            //builder.RegisterModule<RepositoryCapsuleModule>();
            //builder.RegisterModule<ServiceCapsuleModule>();
            //builder.RegisterModule<ControllerCapsuleModule>();


            RegisterModules(builder);

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);

            var resolver = new AutofacWebApiDependencyResolver(Container);
            config.DependencyResolver = resolver;

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(Container));
            return Container;
        }



        private static IEnumerable<Assembly> GetCapsuleModules()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }

            //  Gets all compiled assemblies.
            //  This is particularly useful when extending applications functionality from 3rd parties,
            //  if there are interfaces within the modules.
            return Directory.GetFiles(path, "React-MusicStore.Core.IoC.DLL", SearchOption.TopDirectoryOnly)
                .Select(Assembly.LoadFrom);
        }



        private static void RegisterModules(ContainerBuilder builder)
        {
            var assemblies = GetCapsuleModules();
            if (assemblies != null)
            {
                foreach (var assembly in assemblies)
                {
                    //  Gets the all modules from each assembly to be registered.
                    //  Make sure that each module **MUST** have a parameterless constructor.
                    var modules = assembly.GetTypes()
                        .Where(p => typeof(IModule).IsAssignableFrom(p) && !p.IsAbstract)
                        .Select(p => (IModule)Activator.CreateInstance(p));

                    //  Regsiters each module.
                    foreach (var module in modules)
                    {
                        builder.RegisterModule(module);
                    }
                }
            }
        }



    }
}
