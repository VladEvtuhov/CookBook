using System.Collections.Generic;
using System.Security.Claims;
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

        public async Task CreateUserAsync(RegisterViewModel register)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegisterViewModel, RegisterUserDTO>()).CreateMapper();
            var registerModel = mapper.Map<RegisterViewModel, RegisterUserDTO>(register);
            await userService.CreateUserAsync(registerModel);
        }

        public async Task DeleteUserAsync(string email)
        {
            await userService.DeleteUserAsync(email);
        }

        public async Task RestoreUserAsync(string email)
        {
            await userService.RestoreUserAsync(email);
        }

        public async Task ConfirmEmailAsync(string email)
        {
            await userService.ConfirmEmailAsync(email);
        }

        public async Task<UserViewModel> GetByIdAsync(string id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            return mapper.Map<UserDTO, UserViewModel>(await userService.GetUserByIdAsync(id));
        }

        public async Task<UserViewModel> GetByEmailAsync(string email)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            return mapper.Map<UserDTO, UserViewModel>(await userService.GetUserByEmailAsync(email));
        }
        
        public async Task SetAboutAsync(UserViewModel model)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>()).CreateMapper();
            var info = mapper.Map<UserViewModel, UserDTO>(model);
            await userService.UpdateUserInformation(info);
        }

        public async Task<ClaimsIdentity> LoginAsync(string email, string password)
        {
            return await userService.LoginAsync(email, password);
        }
    }
}
