using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ReactMusicStore.Core.Data.Context.Utilities.Hooks
{
    public class HookedEntityEntry
    {
        public DbEntityEntry Entry { get; set; }
        public EntityState PreSaveState { get; set; }
    }
}
