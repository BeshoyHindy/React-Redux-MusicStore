
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ReactMusicStore.WebApi.Framework.IdentityConfig;

namespace ReactMusicStore.WebApi.Foundation
{
    public class BaseController : ApiController
    {
	    public IdentityUserManager UserManager => HttpContext.Current .GetOwinContext().GetUserManager<IdentityUserManager>();

	    public IdentitySignInManager SignInManager => HttpContext.Current.GetOwinContext().Get<IdentitySignInManager>();

	    public IAuthenticationManager AuthManager => HttpContext.Current.GetOwinContext().Authentication;
    }
}
