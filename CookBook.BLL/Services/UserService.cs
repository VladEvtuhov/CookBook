using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork database;
        public UserService(IUnitOfWork _database)
        {
            database = _database;
        }

        public async Task ConfirmEmailAsync(string email)
        {
            var user = await GetCurrentUserAsync(email);
            user.EmailConfirmed = true;
            await database.UserManager.UpdateAsync(user);
            database.Save();
        }

        public async Task UpdateUserInformation(UserDTO userDTO)
        {
            var user = await GetCurrentUserAsync(userDTO.Email);
            user.Information = userDTO.Information;
            user.ImageUrl = userDTO.ImageUrl;
            user.UserName = userDTO.UserName;
            await database.UserManager.UpdateAsync(user);
            database.Save();
        }

        public async Task<OperationDetails> CreateUserAsync(RegisterUserDTO registerUserDTO)
        {
            CheckOnValidEmail(registerUserDTO.Email);
            if (registerUserDTO.Password.Length < 6)
                return new OperationDetails(false, "min password length = 6", "");
            var user = await database.UserManager.FindByEmailAsync(registerUserDTO.Email);
            if (user != null)
                return new OperationDetails(false, "User is already exist", "");
            user = new ApplicationUser()
            {
                Email = registerUserDTO.Email,
                UserName = registerUserDTO.Email
            };
            var result = await database.UserManager.CreateAsync(user, registerUserDTO.Password);
            if (result.Errors.Count() > 0)
                return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
            await database.UserManager.AddToRoleAsync(user.Id, "reader");
            database.Save();
            return new OperationDetails(true, "User created successfully", "");
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await GetCurrentUserAsync(email);
            user.IsDeleted = true;
            await database.UserManager.UpdateAsync(user);
            database.Save();
        }

        public async Task<OperationDetails> RestoreUserAsync(string email)
        {
            var user = await GetCurrentUserAsync(email);
            if (user == null)
                return new OperationDetails(false, "User not found", "");
            user.IsDeleted = false;
            await database.UserManager.UpdateAsync(user);
            database.Save();
            return new OperationDetails(true, "User restored successfully", "");
        }

        public async Task<UserDTO> GetUserByIdAsync(string id)
        {
            var user = await database.UserManager.FindByIdAsync(id);
            if (user == null)
                throw new ValidationException("User not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDTO>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email)
        {
            var user = await GetCurrentUserAsync(email);
            if (user == null)
                throw new ValidationException("User not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDTO>()).CreateMapper();
            return mapper.Map<ApplicationUser, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ApplicationUser, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ApplicationUser>, List<UserDTO>>(database.UserManager.Users);
        }

        public async Task<ClaimsIdentity> LoginAsync(string email, string password)
        {

            ClaimsIdentity claim = null;
            ApplicationUser user = await database.UserManager.FindAsync(email, password);
            if (user != null)
                claim = await database.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        private async Task<ApplicationUser> GetCurrentUserAsync(string email)
        {
            var user = await database.UserManager.FindByEmailAsync(email);
            if (user == null)
                throw new ValidationException("User not found", "");
            if(user.IsDeleted)
                throw new ValidationException("User is deleted", "");
            return user;
        }
        private void CheckOnValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
            }
            catch
            {
                throw new ValidationException("Email is not valid", "");
            }
        }
    }
}
