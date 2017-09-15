using Microsoft.AspNet.Identity.EntityFramework;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.WebApi.Framework.IdentityConfig
{
    public class IdentityUserStore : UserStore<UserAccount, UserRole, int, UserAccountLogin, UserAccountsUserRoles, UserAccountClaim>
    {
        //public IdentityUserStore() : base(null)
        //{

        //}

        //public IdentityUserStore(DbIdentityDataContext context) : base(context)
        //{
        //}

        public IdentityUserStore() : this(new DbMusicStoreContext())
        {

        }

        public IdentityUserStore(DbMusicStoreContext context) : base(context)
        {
        }




    }
}