using CookBook.DAL.Entities;
using Microsoft.AspNet.Identity;

namespace CookBook.DAL.Identity
{
    public class ApplicationUserManager: UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
                : base(store)
        {
            
        }
    }
}
