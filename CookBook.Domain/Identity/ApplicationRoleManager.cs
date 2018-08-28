using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CookBook.Domain.Identity
{
    public class ApplicationRoleManager: RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> store)
                    : base(store)
        { }
    }
}
