using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRoleService
    {
        Task CreateRoleAsync(string role);
        IEnumerable<string> GetRoles();
        Task RemoveRoleAsync(string role);
    }
}
