using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void ConfirmEmail(string email)
        {
            var user = GetCurrentUser(email);
            user.EmailConfirmed = true;
            database.Users.Update(user);
            database.Save();
        }

        public void ChangeAboutUser(string email, string about)
        {
            var user = GetCurrentUser(email);
            user.Information = about;
            database.Users.Update(user);
            database.Save();
        }

        public void CreateUser(RegisterUserDTO registerUserDTO)
        {
            CheckOnValidEmail(registerUserDTO.Email);
            if (registerUserDTO.Password.Length < 6)
                throw new ValidationException("min password length = 6", "");
            var user = database.Users.FirstOrDefault(u => u.Email == registerUserDTO.Email);
            if (user != null)
                throw new ValidationException("User is already exist", "");
            User newbie = new User()
            {
                Id = database.Users.GetAll().Count() == 0 ? 1 : database.Users.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Email = registerUserDTO.Email,
                ImageUrl = "http://missingkids-stage.adobecqms.net/etc/clientlibs/ncmec/poster/images/poster/en_US/noPhotoAvailable.jpg",
                Password = registerUserDTO.Password.GetHashCode().ToString(),
                UserName = registerUserDTO.Email,
                AverageRating = 0,
                Information = ""
            };
            database.Users.Create(newbie);
            database.Save();
        }

        public void DeleteUser(string email)
        {
            var user = GetCurrentUser(email);
            user.IsDeleted = true;
            database.Users.Update(user);
            database.Save();
        }

        public void RestoreUser(string email)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new ValidationException("User not found", "");
            user.IsDeleted = false;
            database.Users.Update(user);
            database.Save();
        }

        public UserDTO GetUser(int id)
        {
            var user = database.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                throw new ValidationException("User not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public UserDTO GetUser(string email)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new ValidationException("User not found", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<User>, List<UserDTO>>(database.Users.GetAll());
        }

        public bool Login(string email, string password)
        {
            CheckOnValidEmail(email);
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
                throw new ValidationException("User not found", "");
            if (user.Password != password.GetHashCode().ToString() || user.IsDeleted)
                return false;
            return true;
        }

        private User GetCurrentUser(string email)
        {
            var user = database.Users.FirstOrDefault(u => u.Email == email);
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
