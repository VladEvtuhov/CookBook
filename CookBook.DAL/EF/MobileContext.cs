using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.EF
{
    public class MobileContext
    {
        private List<Role> roles = GenericSerializer.Deserialize<Role>();
        
        public List<Role> GetRoles()
        {
            return roles;
        }

    }
}
