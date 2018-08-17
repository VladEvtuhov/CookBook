using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;

namespace CookBook.Console.Controllers
{
    public class UsersController
    {
        private readonly IUserService userService;
        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<UserDTO>, List<UserViewModel>>(userService.GetUsers());
        }

        public void CreateUser(RegisterViewModel register)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegisterViewModel, RegisterUserDTO>()).CreateMapper();
            var registerModel = mapper.Map<RegisterViewModel, RegisterUserDTO>(register);
            userService.CreateUser(registerModel);
        }

        public void DeleteUser(string email)
        {
            userService.DeleteUser(email);
        }

        public void RestoreUser(string email)
        {
            userService.RestoreUser(email);
        }

        public void ConfirmEmail(string email)
        {
            userService.ConfirmEmail(email);
        }

        public UserViewModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            return mapper.Map<UserDTO, UserViewModel>(userService.GetUser(id));
        }

        public UserViewModel Get(string email)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            return mapper.Map<UserDTO, UserViewModel>(userService.GetUser(email));
        }
        
        public void SetAbout(string email, string about)
        {
            userService.ChangeAboutUser(email, about);
        }
    }
}
