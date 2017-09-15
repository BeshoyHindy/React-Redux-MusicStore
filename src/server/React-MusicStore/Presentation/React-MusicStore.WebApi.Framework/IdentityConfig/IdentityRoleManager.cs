using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.WebApi.Framework.IdentityConfig
{
    public class IdentityRoleManager : RoleManager<UserRole, int>
    {
        public IdentityRoleManager(IdentityRoleStore roleStore) : base(roleStore)
        { }

        public static IdentityRoleManager Create(IOwinContext context)
        {
            return new IdentityRoleManager(new IdentityRoleStore(context: context.Get<DbMusicStoreContext>()));
        }

    }
}
