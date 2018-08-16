using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<string> GetUserRoles(string email)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            List<string> roles = new List<string>();
            if (user != null) {
                var rolesId = database.UsersRoles.Find(r => r.UserId == user.Id);
                foreach(var roleId in rolesId)
                {
                    roles.Add(database.Roles.Get(roleId.Id).Name);
                }
            }
            return roles;
        }

        public void PickUpRole(string email, string _role)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            var role = database.Roles.FirstOrDefault(r => r.Name == _role);
            if(user == null || role == null)
                throw new ValidationException("Incorrect data", "");
            var userRole = database.UsersRoles.FirstOrDefault(r => r.RoleId == role.Id && r.UserId == user.Id);
            if(userRole == null)
                throw new ValidationException("User and role combination not found", "");
            database.UsersRoles.Remove(userRole);
            database.Save();
        }

        public void SetRole(string email, string _role)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            var role = database.Roles.FirstOrDefault(r => r.Name == _role);
            if (user == null || role == null)
                throw new ValidationException("Incorrect data", "");
            var userRole = database.UsersRoles.FirstOrDefault(r => r.RoleId == role.Id && r.UserId == user.Id);
            if (userRole != null)
                throw new ValidationException("User already has this role", "");
            UserRoles userRoles = new UserRoles()
            {
                Id = database.UsersRoles.GetAll().Count() == 0 ? 1 : database.UsersRoles.GetAll().Last().Id + 1,
                RoleId = role.Id,
                UserId = user.Id
            };
            database.UsersRoles.Create(userRoles);
            database.Save();
        }
    }
}
