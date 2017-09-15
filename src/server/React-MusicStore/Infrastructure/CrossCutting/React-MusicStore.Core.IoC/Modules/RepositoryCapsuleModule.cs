using Autofac;
using ReactMusicStore.Core.Data.Repository.Dapper;
using ReactMusicStore.Core.Data.Repository.EntityFramework;
using ReactMusicStore.Core.Data.Repository.EntityFramework.Common;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Repository;
using ReactMusicStore.Core.Domain.Interfaces.Repository.Common;
using ReactMusicStore.Core.Domain.Interfaces.Repository.ReadOnly;

namespace ReactMusicStore.Core.IoC.Modules
{
    public class RepositoryCapsuleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

			builder.RegisterType<GenreRepository>().As<IGenreRepository>(); 
			builder.RegisterType<GenreDapperRepository>().As<IGenreReadOnlyRepository>(); 
			builder.RegisterType<GenreDapperRepository>().As<IReadOnlyRepository<Genre>>(); 

			builder.RegisterType<ArtistRepository>().As<IArtistRepository>();
			builder.RegisterType<ArtistDapperRepository>().As<IArtistReadOnlyRepository>();
			builder.RegisterType<ArtistDapperRepository>().As<IReadOnlyRepository<Artist>>();

			builder.RegisterType<AlbumRepository>().As<IAlbumRepository>();
			builder.RegisterType<AlbumDapperRepository>().As<IAlbumReadOnlyRepository>();
			builder.RegisterType<AlbumDapperRepository>().As<IReadOnlyRepository<Album>>();

			builder.RegisterType<CartRepository>().As<ICartRepository>();
			builder.RegisterType<CartDapperRepository>().As<ICartReadOnlyRepository>();
			builder.RegisterType<CartDapperRepository>().As<IReadOnlyRepository<Cart>>();

			builder.RegisterType<OrderRepository>().As<IOrderRepository>();
			builder.RegisterType<OrderDapperRepository>().As<IOrderReadOnlyRepository>();
			builder.RegisterType<OrderDapperRepository>().As<IReadOnlyRepository<Order>>();

			builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>();
			builder.RegisterType<OrderDetailDapperRepository>().As<IOrderDetailReadOnlyRepository>();
			builder.RegisterType<OrderDetailDapperRepository>().As<IReadOnlyRepository<OrderDetail>>();

			base.Load(builder);
        }
    }
}
