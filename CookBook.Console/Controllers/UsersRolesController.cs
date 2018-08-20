using CookBook.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void SetRole(string email, string role)
        {
            userRoleService.SetRole(email, role);
        }

        public void PickUpRole(string email, string role)
        {
            userRoleService.PickUpRole(email, role);
        }

        public List<string> GetUserRoles(string email)
        {
            return userRoleService.GetUserRoles(email);
        }
    }
}
