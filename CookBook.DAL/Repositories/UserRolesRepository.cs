using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Repositories
{
    public class UserRolesRepository : IRepository<UserRoles>
    {
        MobileContext mobileContext;
        public UserRolesRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }

        public int Count()
        {
            return mobileContext.GetUserRoles().Count();
        }

        public void Create(UserRoles item)
        {
            mobileContext.GetUserRoles().Add(item);
            var user = mobileContext.GetUsers().First(u => u.Id == item.UserId);
            var role = mobileContext.GetRoles().First(r => r.Id == item.RoleId);
            user.Roles.Add(role);
        }

        public IEnumerable<UserRoles> Find(Func<UserRoles, bool> predicate)
        {
            return mobileContext.GetUserRoles().Where(predicate).ToList();
        }

        public UserRoles FirstOrDefault(Func<UserRoles, bool> predicate)
        {
            return mobileContext.GetUserRoles().FirstOrDefault(predicate);
        }

        public UserRoles Get(int id)
        {
            return mobileContext.GetUserRoles().Find(r => r.Id == id);
        }

        public IEnumerable<UserRoles> GetAll()
        {
            return mobileContext.GetUserRoles();
        }

        public void Remove(int id)
        {
            var userRole = mobileContext.GetUserRoles().FirstOrDefault(r => r.Id == id);
            if (userRole != null)
            {
                var user = mobileContext.GetUsers().First(u => u.Id == userRole.UserId);
                var role = mobileContext.GetRoles().First(r => r.Id == userRole.RoleId);
                user.Roles.Remove(role);
                mobileContext.GetUserRoles().Remove(userRole);
            }
        }

        public void Remove(UserRoles item)
        {
            var userRole = mobileContext.GetUserRoles().FirstOrDefault(r => r.RoleId == item.RoleId && r.UserId == item.UserId);
            if (userRole != null)
            {
                var user = mobileContext.GetUsers().First(u => u.Id == userRole.UserId);
                var role = mobileContext.GetRoles().First(r => r.Id == userRole.RoleId);
                user.Roles.Remove(role);
                mobileContext.GetUserRoles().Remove(userRole);
            }
        }

        public void Update(UserRoles item)
        {
            var userRole = mobileContext.GetUserRoles().FirstOrDefault(p => p.Id == item.Id);
            if (userRole != null)
            {
                userRole.RoleId = item.RoleId;
                userRole.UserId = item.UserId;
            }
        }
    }
}
