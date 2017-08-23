using Ninject.Modules;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IService<>)).To(typeof (Service<>));

            Bind<IGenreService>().To<GenreService>();
            Bind<IArtistService>().To<ArtistService>();
            Bind<IAlbumService>().To<AlbumService>();
            Bind<ICartService>().To<CartService>();
            Bind<IOrderService>().To<OrderService>();
            Bind<IOrderDetailService>().To<OrderDetailService>();
        }
    }
}
