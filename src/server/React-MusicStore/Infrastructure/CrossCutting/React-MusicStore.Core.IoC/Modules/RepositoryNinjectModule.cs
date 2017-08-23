using Ninject.Modules;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepository<>)).To(typeof (Repository<>));

            Bind<IGenreRepository>().To<GenreRepository>();
            Bind<IGenreReadOnlyRepository>().To<GenreDapperRepository>();
            Bind<IReadOnlyRepository<Genre>>().To<GenreDapperRepository>();

            Bind<IArtistRepository>().To<ArtistRepository>();
            Bind<IArtistReadOnlyRepository>().To<ArtistDapperRepository>();
            Bind<IReadOnlyRepository<Artist>>().To<ArtistDapperRepository>();

            Bind<IAlbumRepository>().To<AlbumRepository>();
            Bind<IAlbumReadOnlyRepository>().To<AlbumDapperRepository>();
            Bind<IReadOnlyRepository<Album>>().To<AlbumDapperRepository>();

            Bind<ICartRepository>().To<CartRepository>();
            Bind<ICartReadOnlyRepository>().To<CartDapperRepository>();
            Bind<IReadOnlyRepository<Cart>>().To<CartDapperRepository>();

            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IOrderReadOnlyRepository>().To<OrderDapperRepository>();
            Bind<IReadOnlyRepository<Order>>().To<OrderDapperRepository>();

            Bind<IOrderDetailRepository>().To<OrderDetailRepository>();
            Bind<IOrderDetailReadOnlyRepository>().To<OrderDetailDapperRepository>();
            Bind<IReadOnlyRepository<OrderDetail>>().To<OrderDetailDapperRepository>();
        }
    }
}
