using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
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

        public async Task PickUpRoleAsync(string email, string _role)
        {
            var user = await database.UserManager.FindByEmailAsync(email);
            var role = await database.RoleManager.FindByNameAsync(_role);
            if(user == null || role == null)
                throw new ValidationException("Incorrect data", "");
            var userRole = database.UserManager.GetRolesAsync(user.Id);
            if(!userRole.Result.Contains(role.Name))
                throw new ValidationException("User and role combination not found", "");
            await database.UserManager.RemoveFromRoleAsync(user.Id, role.Name);
            database.Save();
        }

        public async Task SetRoleAsync(string email, string _role)
        {
            var user = await database.UserManager.FindByEmailAsync(email);
            var role = await database.RoleManager.FindByNameAsync(_role);
            if (user == null || role == null)
                throw new ValidationException("Incorrect data", "");
            var userRole = database.UserManager.GetRolesAsync(user.Id);
            if (userRole.Result.Contains(role.Name))
                throw new ValidationException("User already has this role", "");
            await database.UserManager.AddToRoleAsync(user.Id, role.Name);
            database.Save();
        }
    }
}
