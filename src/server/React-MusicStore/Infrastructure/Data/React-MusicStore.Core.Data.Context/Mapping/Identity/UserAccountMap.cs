using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.Core.Data.Context.Mapping.Identity
{
    public class UserAccountMap : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountMap()
        {
            Property(u => u.UserName).IsRequired();
            HasMany(u => u.Roles);
        }
    }
}