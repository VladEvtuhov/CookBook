using CookBook.BLL.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IUserRoleService
    {
        Task<OperationDetails> SetRoleAsync(string email, string role);
        Task<OperationDetails> PickUpRoleAsync(string email, string role);
        Task<IList<string>> GetUserRolesAsync(string email);
    }
}
