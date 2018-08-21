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
    public class UserRepository : IRepository<ApplicationUser>
    {
        readonly ApplicationDbContext mobileContext;
        public UserRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.Users.Count();
        }

        public void Create(ApplicationUser item)
        {
            var user = mobileContext.Users.FirstOrDefault(u => u.Email == item.Email);
            if(user == null)
                mobileContext.Users.Add(item);
        }

        public IEnumerable<ApplicationUser> Find(Func<ApplicationUser, bool> predicate)
        {
            return mobileContext.Users.Where(predicate).ToList();
        }

        public ApplicationUser FirstOrDefault(Func<ApplicationUser, bool> predicate)
        {
            return mobileContext.Users.FirstOrDefault(predicate);
        }

        public ApplicationUser Get(int id)
        {
            //Todo: remove ToString();
            return mobileContext.Users.First(u => u.Id == id.ToString());
        }

        public IEnumerable<ApplicationUser> GetAll()
        {
            return mobileContext.Users;
        }

        public void Remove(int id)
        {
            //Todo: remove ToString();
            var user = mobileContext.Users.FirstOrDefault(u => u.Id == id.ToString());
            if(user != null)
            {
                mobileContext.Users.Remove(user);
            }
        }

        public void Remove(ApplicationUser item)
        {
            var user = mobileContext.Users.FirstOrDefault(u => u == item);
            if(user != null)
            {
                mobileContext.Users.Remove(user);
            }
        }

        public void Update(ApplicationUser item)
        {
            var user = mobileContext.Users.FirstOrDefault(u => u.Id == item.Id);
            if (user != null) {
                user.Information = item.Information;
                user.AverageRating = item.AverageRating;
                user.EmailConfirmed = item.EmailConfirmed;
                user.ImageUrl = item.ImageUrl;
                user.IsDeleted = item.IsDeleted;
                user.UserName = item.UserName;
            }
        }
    }
}
