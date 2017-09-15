using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReactMusicStore.Core.Domain.Entities.Identity
{
    [Table("UserAccounts")]
    public class UserAccount : IdentityUser<int, UserAccountLogin, UserAccountsUserRoles, UserAccountClaim>
    {
        public string FierstName { get; set; }
        public string LastName { get; set; }

        public string DisplayName { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserAccount,int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

    }

    #region identity -int-

    //public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}


    //public class ApplicationRole : IdentityRole<int, ApplicationUserRole>
    //{
    //}

    //public class ApplicationDbContext
    //    : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection")
    //    {
    //    }
    //}

    #endregion
}