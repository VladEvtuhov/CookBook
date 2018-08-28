using CookBook.Domain.Entities;
using Microsoft.AspNet.Identity;

namespace CookBook.Domain.Identity
{
    public class ApplicationUserManager: UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
            
        }
    }
}
