using Autofac;
using ReactMusicStore.Services;
using ReactMusicStore.Services.Interfaces;
using ReactMusicStore.Services.Interfaces.Common;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class ApplicationCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(ReferencedAssemblies.Services)
            //       .Where(_ => _.Name.EndsWith("AppService"))
            //       .AsImplementedInterfaces()
            //       .InstancePerLifetimeScope();


			// builder.RegisterGeneric(typeof(AppService<>)).As(typeof(IAppService<>));


			builder.RegisterType<GenreAppService>().As<IGenreAppService>();
			builder.RegisterType<ArtistAppService>().As<IArtistAppService>();
			builder.RegisterType<AlbumAppService>().As<IAlbumAppService>().PreserveExistingDefaults();
			builder.RegisterType<CartAppService>().As<ICartAppService>();
			builder.RegisterType<OrderAppService>().As<IOrderAppService>();
			builder.RegisterType<OrderDetailAppService>().As<IOrderDetailAppService>();

			base.Load(builder);
        }
    }
}
