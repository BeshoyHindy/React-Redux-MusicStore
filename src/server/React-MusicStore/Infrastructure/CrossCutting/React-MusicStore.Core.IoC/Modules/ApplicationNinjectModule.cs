using Ninject.Modules;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenreAppService>().To<GenreAppService>();
            Bind<IArtistAppService>().To<ArtistAppService>();
            Bind<IAlbumAppService>().To<AlbumAppService>();
            Bind<ICartAppService>().To<CartAppService>();
            Bind<IOrderAppService>().To<OrderAppService>();
            Bind<IOrderDetailAppService>().To<OrderDetailAppService>();
        }
    }
}
