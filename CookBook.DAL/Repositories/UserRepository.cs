using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        readonly MobileContext mobileContext;
        public UserRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetUsers().Count();
        }

        public void Create(User item)
        {
            var user = mobileContext.GetUsers().FirstOrDefault(u => u.Email == item.Email);
            if(user == null)
                mobileContext.GetUsers().Add(item);
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return mobileContext.GetUsers().Where(predicate).ToList();
        }

        public User FirstOrDefault(Func<User, bool> predicate)
        {
            return mobileContext.GetUsers().FirstOrDefault(predicate);
        }

        public User Get(int id)
        {
            return mobileContext.GetUsers().Find(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return mobileContext.GetUsers();
        }

        public void Remove(int id)
        {
            var user = mobileContext.GetUsers().FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                mobileContext.GetUsers().Remove(user);
            }
        }

        public void Remove(User item)
        {
            var user = mobileContext.GetUsers().FirstOrDefault(u => u == item);
            if(user != null)
            {
                mobileContext.GetUsers().Remove(user);
            }
        }

        public void Update(User item)
        {
            var user = mobileContext.GetUsers().FirstOrDefault(u => u.Id == item.Id);
            if (user != null) {
                user.Information = item.Information;
                user.AverageRating = item.AverageRating;
                user.Comments = item.Comments;
                user.EmailConfirmed = item.EmailConfirmed;
                user.ImageUrl = item.ImageUrl;
                user.IsDeleted = item.IsDeleted;
                user.Password = item.Password;
                user.RecipesRatings = item.RecipesRatings;
                user.UserName = item.UserName;
                user.UserRecipes = item.UserRecipes;
            }
        }
    }
}
