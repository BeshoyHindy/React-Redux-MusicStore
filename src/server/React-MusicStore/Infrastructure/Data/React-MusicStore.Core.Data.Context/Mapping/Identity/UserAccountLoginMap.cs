using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities.Identity;

namespace ReactMusicStore.Core.Data.Context.Mapping.Identity
{
    public class UserAccountLoginMap : EntityTypeConfiguration<UserAccountLogin>
    {
        public UserAccountLoginMap()
        {
            HasKey(l => new
            {
                l.UserId,
                l.LoginProvider,
                l.ProviderKey
            });
        }
    }
}