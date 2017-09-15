using System.Data.Entity.Migrations;

namespace ReactMusicStore.Core.Data.Context.Migrations
{
	internal sealed class MigrationsConfiguration : DbMigrationsConfiguration<DbMusicStoreContext>
	{
		public MigrationsConfiguration()
		{
			AutomaticMigrationsEnabled = false;
			//AutomaticMigrationDataLossAllowed = true;
			ContextKey = "ReactMusicStore.Core";

		}

	
    }
}
