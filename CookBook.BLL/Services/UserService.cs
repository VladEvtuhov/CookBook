using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        public async Task ChangeAboutUserAsync(string email, string about)
        {
            var user = await GetCurrentUserAsync(email);
            user.Information = about;
            await database.UserManager.UpdateAsync(user);
            database.Save();
        }

        public async Task CreateUserAsync(RegisterUserDTO registerUserDTO)
        {
            CheckOnValidEmail(registerUserDTO.Email);
            if (registerUserDTO.Password.Length < 6)
                throw new ValidationException("min password length = 6", "");
            var user = await database.UserManager.FindByEmailAsync(registerUserDTO.Email);
            if (user != null)
                throw new ValidationException("User is already exist", "");
            user = new ApplicationUser()
            {
                Email = registerUserDTO.Email,
                UserName = registerUserDTO.Email
            };
            var result = await database.UserManager.CreateAsync(user, registerUserDTO.Password);
            if (result.Errors.Count() > 0)
                throw new ValidationException(result.Errors.FirstOrDefault(), "");
            await database.UserManager.AddToRoleAsync(user.Id, "reader");
            database.Save();
        }

        public async Task DeleteUserAsync(string email)
        {
            var user = await GetCurrentUserAsync(email);
            user.IsDeleted = true;
            await database.UserManager.UpdateAsync(user);
            database.Save();
        }

        public async Task RestoreUserAsync(string email)
        {
            var user = await GetCurrentUserAsync(email);
            if (user == null)
                throw new ValidationException("User not found", "");
            user.IsDeleted = false;
            await database.UserManager.UpdateAsync(user);
            database.Save();
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
