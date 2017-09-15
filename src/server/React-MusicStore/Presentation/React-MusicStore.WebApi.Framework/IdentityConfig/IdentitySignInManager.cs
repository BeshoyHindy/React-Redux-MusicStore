using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.WebApi.Framework.IdentityConfig
{
    public class IdentitySignInManager : SignInManager<UserAccount, int>
    {
        public IdentitySignInManager(IdentityUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(UserAccount user)
        {
            return user.GenerateUserIdentityAsync((IdentityUserManager)UserManager);
        }

        public static IdentitySignInManager Create(IdentityFactoryOptions<IdentitySignInManager> options, IOwinContext context)
        {
            return new IdentitySignInManager(context.GetUserManager<IdentityUserManager>(), context.Authentication);
        }
        //public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        //{
        //    return new ApplicationSignInManager(context.Get<ApplicationUserManager>(), context.Authentication);
        //}


    }
}
