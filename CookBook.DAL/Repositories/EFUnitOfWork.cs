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
    public class EFUnitOfWork : IUnitOfWork
    {
        private MobileContext mobileContext;
        private RoleRepository roleRepository;

        public EFUnitOfWork()
        {
            mobileContext = new MobileContext();
        }
        public IRepository<Role> Roles {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(mobileContext);
                return roleRepository;
            }
        }

        public void Save()
        {
            GenericSerializer.Serialize(roleRepository.GetAll());
        }
    }
}
