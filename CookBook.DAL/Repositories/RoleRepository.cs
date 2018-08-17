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
    public class RoleRepository : IRepository<Role>
    {
        MobileContext mobileContext;
        public RoleRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public void Create(Role item)
        {
            mobileContext.GetRoles().Add(item);
        }

        public void Remove(int id)
        {
            if (mobileContext.GetUserRoles().FirstOrDefault(r => r.RoleId == id) == null)
            {
                var role = mobileContext.GetRoles().Find(r => r.Id == id);
                if (role != null)
                    mobileContext.GetRoles().Remove(role);
            }
        }

        public void Remove(Role role)
        {
            var removedRole = mobileContext.GetRoles().FirstOrDefault(r => r.Name == role.Name);
            if (removedRole != null && mobileContext.GetUserRoles().FirstOrDefault(r => r.RoleId == removedRole.Id) == null)
                mobileContext.GetRoles().Remove(removedRole);
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return mobileContext.GetRoles().Where(predicate).ToList();
        }

        public Role FirstOrDefault(Func<Role, bool> predicate)
        {
            return mobileContext.GetRoles().FirstOrDefault(predicate);
        }

        public Role Get(int id)
        {
            var role = mobileContext.GetRoles().Find(r => r.Id == id);
            return role;
        }

        public int Count()
        {
            return mobileContext.GetRoles().Count();
        }

        public IEnumerable<Role> GetAll()
        {
            return mobileContext.GetRoles();
        }

        public void Update(Role item)
        {
            var role = mobileContext.GetRoles().FirstOrDefault(s => s.Id == item.Id);
            if (role != null) { role.Name = item.Name; }
        }
    }
}
