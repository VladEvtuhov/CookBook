using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class UserRoleService: IUserRoleService
    {
        IUnitOfWork database;
        public UserRoleService(IUnitOfWork _database)
        {
            database = _database;
        }

        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            var user = await database.UserManager.FindByEmailAsync(email);
            IList<string> roles = new List<string>();
            if (user != null) {
                roles = await database.UserManager.GetRolesAsync(user.Id);
            }
            return roles;
        }

        public async Task<OperationDetails> PickUpRoleAsync(string email, string _role)
        {
            var user = await database.UserManager.FindByEmailAsync(email);
            var role = await database.RoleManager.FindByNameAsync(_role);
            if(user == null || role == null)
                return new OperationDetails(false, "User or Role not found", "");
            var userRole = database.UserManager.GetRolesAsync(user.Id);
            if(!userRole.Result.Contains(role.Name))
                return new OperationDetails(false, "User and role combination not found", "");
            await database.UserManager.RemoveFromRoleAsync(user.Id, role.Name);
            database.Save();
            return new OperationDetails(true, "Role pickuped successfully", "");
        }

        public async Task<OperationDetails> SetRoleAsync(string email, string _role)
        {
            var user = await database.UserManager.FindByEmailAsync(email);
            var role = await database.RoleManager.FindByNameAsync(_role);
            if (user == null || role == null)
                return new OperationDetails(false, "User or role not found", "");
            var userRole = database.UserManager.GetRolesAsync(user.Id);
            if (userRole.Result.Contains(role.Name))
                return new OperationDetails(false, "User already has this role", "");
            await database.UserManager.AddToRoleAsync(user.Id, role.Name);
            database.Save();
            return new OperationDetails(true, "Role was setted for user successfully", "");
        }
    }
}
