
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using ReactMusicStore.Core.Data.Context.Config;
using ReactMusicStore.Core.Data.Context.Mapping;
using ReactMusicStore.Core.Data.Context.Mapping.Identity;
using ReactMusicStore.Core.Data.Context.Migrations;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Entities.Identity;
using ReactMusicStore.Core.Utilities.Extensions;

namespace ReactMusicStore.Core.Data.Context
{
	public class DbMusicStoreContext : BaseDbContext
	{
		static DbMusicStoreContext()
		{
			Database.SetInitializer(new ContextInitializer());

		}

		public DbMusicStoreContext() : base()
		{

		}
		public DbMusicStoreContext(string nameOrConnectionString) : base(nameOrConnectionString)
		{
			if (!Database.Exists())
			{
				Database.Initialize(true);
			}
		}
		public static DbMusicStoreContext Create()
		{
			return new DbMusicStoreContext(GetConnectionString());
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			base.OnModelCreating(modelBuilder);

			//modelBuilder.Configurations.Add(new GenreMap());
			//modelBuilder.Configurations.Add(new ArtistMap());
			//modelBuilder.Configurations.Add(new AlbumMap());
			//modelBuilder.Configurations.Add(new CartMap());
			//modelBuilder.Configurations.Add(new OrderMap());
			//modelBuilder.Configurations.Add(new OrderDetailMap());

			//modelBuilder.Configurations.Add(new UserAccountMap());
			//modelBuilder.Configurations.Add(new UserAccountLoginMap());
			//modelBuilder.Configurations.Add(new UserAccountsUserRolesMap());
			//modelBuilder.Configurations.Add(new UserRoleMap());


			var typesToRegister = from t in Assembly.GetExecutingAssembly().GetTypes()
								  where t.Namespace.HasValue() &&
										t.BaseType != null &&
										t.BaseType.IsGenericType
								  let genericType = t.BaseType.GetGenericTypeDefinition()
								  where genericType == typeof(EntityTypeConfiguration<>) || genericType == typeof(ComplexTypeConfiguration<>)
								  select t;

			foreach (var type in typesToRegister)
			{
				dynamic configurationInstance = Activator.CreateInstance(type);
				modelBuilder.Configurations.Add(configurationInstance);
			}




		}

		#region DbSet
		public virtual IDbSet<UserRole> UserRoles { get; set; }
		public virtual IDbSet<UserAccount> UserAccounts { get; set; }


		public IDbSet<Genre> Genres { get; set; }
		public IDbSet<Album> Albums { get; set; }
		public IDbSet<Artist> Artists { get; set; }
		public IDbSet<Cart> Carts { get; set; }
		public IDbSet<Order> Orders { get; set; }
		public IDbSet<OrderDetail> OrderDetails { get; set; }

		#endregion
	}
}