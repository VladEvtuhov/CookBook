using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IUserRoleService
    {
        void SetRole(string email, string role);
        void PickUpRole(string email, string role);
        List<string> GetUserRoles(string email);
    }
}
