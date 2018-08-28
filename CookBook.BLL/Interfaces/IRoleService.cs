using System.Collections.Generic;
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
