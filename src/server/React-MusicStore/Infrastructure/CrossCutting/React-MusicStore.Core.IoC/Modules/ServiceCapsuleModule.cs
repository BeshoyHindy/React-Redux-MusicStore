using Autofac;
using ReactMusicStore.Core.Domain.Interfaces.Service;
using ReactMusicStore.Core.Domain.Interfaces.Service.Common;
using ReactMusicStore.Core.Domain.Services;
using ReactMusicStore.Core.Domain.Services.Common;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class ServiceCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterAssemblyTypes(ReferencedAssemblies.Domain).
            //    Where(_ => _.Name.EndsWith("Service")).
            //    AsImplementedInterfaces().
            //    InstancePerLifetimeScope();



            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>));

			builder.RegisterType<GenreService>().As<IGenreService>();
			builder.RegisterType<ArtistService>().As<IArtistService>();
			builder.RegisterType<AlbumService>().As<IAlbumService>();
			builder.RegisterType<CartService>().As<ICartService>();
			builder.RegisterType<OrderService>().As<IOrderService>();
			builder.RegisterType<OrderDetailService>().As<IOrderDetailService>();

			base.Load(builder);
        }
    }
}
