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
        private readonly MobileContext mobileContext;
        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private UserRolesRepository userRolesRepository;

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

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(mobileContext);
                return userRepository;
            }
        }

        public IRepository<UserRoles> UsersRoles
        {
            get
            {
                if (userRolesRepository == null)
                    userRolesRepository = new UserRolesRepository(mobileContext);
                return userRolesRepository;
            }
        }

        public void Save()
        {
            if(roleRepository != null)
                GenericSerializer.Serialize(roleRepository.GetAll());
            if (userRepository != null)
                GenericSerializer.Serialize(userRepository.GetAll());
            if (userRolesRepository != null)
                GenericSerializer.Serialize(userRolesRepository.GetAll());
        }
    }
}
