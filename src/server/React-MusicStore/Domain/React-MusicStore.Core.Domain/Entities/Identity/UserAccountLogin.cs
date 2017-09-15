using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReactMusicStore.Core.Domain.Entities.Identity
{
    [Table("UserAccountLogin")]
    public class UserAccountLogin : IdentityUserLogin<int>
    {
        public UserAccount User { get; set; }

    }
}