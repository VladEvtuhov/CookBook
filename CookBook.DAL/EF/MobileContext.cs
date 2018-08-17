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
        private readonly List<Country> countries = GenericSerializer.Deserialize<Country>();
        private readonly List<IngredientType> ingridientTypes = GenericSerializer.Deserialize<IngredientType>();
        private readonly List<Recipe> recipes = GenericSerializer.Deserialize<Recipe>();
        private readonly List<RecipeProduct> recipeProducts = GenericSerializer.Deserialize<RecipeProduct>();
        private readonly List<RecipeRating> recipeRatings = GenericSerializer.Deserialize<RecipeRating>();
        private readonly List<Comment> comments = GenericSerializer.Deserialize<Comment>();
        
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

        public List<Country> GetCountries()
        {
            return countries;
        }

        public List<IngredientType> GetIngredientTypes()
        {
            return ingridientTypes;
        }

        public List<Recipe> GetRecipes()
        {
            return recipes;
        }

        public List<RecipeProduct> GetRecipeProducts()
        {
            return recipeProducts;
        }

        public List<RecipeRating> GetRecipeRatings()
        {
            return recipeRatings;
        }

        public List<Comment> GetComments()
        {
            return comments;
        }
    }
}
