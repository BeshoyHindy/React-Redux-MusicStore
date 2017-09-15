using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.Core.Data.Context.Mapping.Identity
{
    public class UserRoleMap : EntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            Property(r => r.Name).IsRequired();
        }

    }
}