using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using ReactMusicStore.Core.Data.Context;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.WebApi.Framework.IdentityConfig
{

    public class IdentityUserManager : UserManager<UserAccount, int>
    {
        public IdentityUserManager(IdentityUserStore userStore) : base(userStore)
        { }

        public static IdentityUserManager Create(IdentityFactoryOptions<IdentityUserManager> options, IOwinContext context)
        {
            //return new ApplicationUserManager(new ApplicationUserStore(context.Get<DbDataContext>()));

            //var applicationUserStore = new ApplicatonUserStore();
            //return new ApplicatonUserManager(applicationUserStore);

            var manager = new IdentityUserManager(new IdentityUserStore(context.Get<DbMusicStoreContext>()));
            // Configure validation logic for usernames
            //manager.UserValidator = new UserValidator<UserAccount,int>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true
            //};

            // Configure validation logic for passwords
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};

            // Configure user lockout defaults
            //manager.UserLockoutEnabledByDefault = true;
            //manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<UserAccount, int>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<UserAccount, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new IdentityEmailService();
            manager.SmsService = new IdentitySmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<UserAccount, int>(dataProtectionProvider.Create("SpartaSolution Identity"));
            }
            return manager;


        }
    }
}
