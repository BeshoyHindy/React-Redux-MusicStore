using Microsoft.AspNet.Identity.EntityFramework;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.WebApi.Framework.IdentityConfig
{
    public class IdentityRoleStore : RoleStore<UserRole, int, UserAccountsUserRoles>
    {
        public IdentityRoleStore() : base(new DbMusicStoreContext())
        {

        }

        public IdentityRoleStore(DbMusicStoreContext context) : base(context)
        {
        }

    }
}
