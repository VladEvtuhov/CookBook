using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IUserService
    {
        Task ConfirmEmailAsync(string email);
        Task DeleteUserAsync(string email);
        Task<OperationDetails> RestoreUserAsync(string email);
        IEnumerable<UserDTO> GetUsers();
        Task<UserDTO> GetUserByIdAsync(string id);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<OperationDetails> CreateUserAsync(RegisterUserDTO registerUserDTO);
        Task ChangeAboutUserAsync(string email, string about);
        Task<ClaimsIdentity> LoginAsync(string email, string password);
    }
}
