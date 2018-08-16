using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Role> Roles { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
