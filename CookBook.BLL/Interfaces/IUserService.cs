using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IUserService
    {
        void ConfirmEmail(string email);
        void DeleteUser(string email);
        void RestoreUser(string email);
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUser(int id);
        UserDTO GetUser(string email);
        void CreateUser(RegisterUserDTO registerUserDTO);
        void ChangeAboutUser(string email, string about);
        bool Login(string email, string password);
    }
}
