using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.EF
{
    public class MobileContext
    {
        private readonly List<Role> roles = GenericSerializer.Deserialize<Role>();
        private readonly List<User> users = GenericSerializer.Deserialize<User>();
        private readonly List<UserRoles> userRoles = GenericSerializer.Deserialize<UserRoles>();
        private readonly List<Product> products = GenericSerializer.Deserialize<Product>();
        private readonly List<Category> categories = GenericSerializer.Deserialize<Category>();
        private readonly List<CookingMethod> cookingMethods = GenericSerializer.Deserialize<CookingMethod>();
        
        public List<Role> GetRoles()
        {
            return roles;
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public List<UserRoles> GetUserRoles()
        {
            return userRoles;
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Category> GetCategories()
        {
            return categories;
        }

        public List<CookingMethod> GetCookingMethods()
        {
            return cookingMethods;
        }
    }
}
