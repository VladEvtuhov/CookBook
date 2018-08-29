using CookBook.BLL.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRoleService
    {
        Task<OperationDetails> CreateRoleAsync(string role);
        IEnumerable<string> GetRoles();
        Task<OperationDetails> RemoveRoleAsync(string role);
    }
}
