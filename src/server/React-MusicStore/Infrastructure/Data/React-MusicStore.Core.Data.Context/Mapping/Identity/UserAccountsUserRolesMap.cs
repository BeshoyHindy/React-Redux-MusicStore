using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.Core.Data.Context.Mapping.Identity
{
    public class UserAccountsUserRolesMap : EntityTypeConfiguration<UserAccountsUserRoles>
    {
        public UserAccountsUserRolesMap()
        {
            HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}