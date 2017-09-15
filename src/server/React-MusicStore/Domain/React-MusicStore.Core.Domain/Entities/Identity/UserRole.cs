using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ReactMusicStore.Core.Domain.Entities.Identity
{
    [Table("UserRoles")]
    public class UserRole : IdentityRole<int, UserAccountsUserRoles>
    {
        public UserRole() : base()
        {
        }
        public UserRole(string name, string roleDescription) : base()
        {
            RoleDescription = roleDescription;
        }

        public virtual string RoleDescription { get; set; }


    }
}
