using CookBook.BLL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.Console.Controllers
{
    public class UsersRolesController
    {
        private readonly IUserRoleService userRoleService;
        public UsersRolesController(IUserRoleService _userRoleService)
        {
            userRoleService = _userRoleService;
        }

        public async Task SetRoleAsync(string email, string role)
        {
            await userRoleService.SetRoleAsync(email, role);
        }

        public async Task PickUpRoleAsync(string email, string role)
        {
            await userRoleService.PickUpRoleAsync(email, role);
        }

        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            return await userRoleService.GetUserRolesAsync(email);
        }
    }
}
