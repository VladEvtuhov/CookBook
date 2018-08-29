using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class RoleService : IRoleService
    {
        IUnitOfWork database;
        public RoleService(IUnitOfWork _database)
        {
            database = _database;
        }
        public async Task<OperationDetails> CreateRoleAsync(string role)
        {
            var isRoleExist = await database.RoleManager.RoleExistsAsync(role);
            if (isRoleExist)
                return new OperationDetails(false, "Role is already exist", "");
            var newbieRole = new IdentityRole { Name = "reader" };
            var roleResult = await database.RoleManager.CreateAsync(newbieRole);
            database.Save();
            return new OperationDetails(true, "Role created successfully", "");
        }

        public IEnumerable<string> GetRoles()
        {
            return database.RoleManager.Roles.Select(n => n.Name).ToList();
        }

        public async Task<OperationDetails> RemoveRoleAsync(string role)
        {
            var isRoleExist = await database.RoleManager.RoleExistsAsync(role);
            if (!isRoleExist)
                return new OperationDetails(false, "Role not found", "");
            var foundedRole = await database.RoleManager.FindByNameAsync(role);
            await database.RoleManager.DeleteAsync(foundedRole);
            database.Save();
            return new OperationDetails(true, "Role removed successfully", "");
        }
    }
}
