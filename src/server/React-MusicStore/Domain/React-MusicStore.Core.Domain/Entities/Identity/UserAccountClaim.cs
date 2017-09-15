using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReactMusicStore.Core.Domain.Entities.Identity
{
    [Table("UserAccountClaim")]
    public class UserAccountClaim : IdentityUserClaim<int>
    {
        
    }
}