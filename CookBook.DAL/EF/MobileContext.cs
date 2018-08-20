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

        public MobileContext()
        {
            foreach (var user in users)
            {
                var rolesId = userRoles.Where(s => s.UserId == user.Id).Select(s => s.RoleId).ToList();
                user.Roles.AddRange(roles.Where(s => rolesId.Contains(s.Id)).ToList());
                user.Comments.AddRange(comments.Where(s => s.CreatorId == user.Id).ToList());
                user.RecipesRatings.AddRange(recipeRatings.Where(s => s.CreatorId == user.Id).ToList());
                user.UserRecipes.AddRange(recipes.Where(s => s.CreatorId == user.Id));
            }
            foreach(var recipe in recipes)
            {
                var productsId = recipeProducts.Where(s => s.RecipeId == recipe.Id).Select(s => s.ProductId).ToList();
                recipe.Products.AddRange(products.Where(s => productsId.Contains(s.Id)).ToList());
                recipe.Comments.AddRange(comments.Where(s => s.RecipeId == recipe.Id).ToList());
                recipe.RecipesRatings.AddRange(recipeRatings.Where(s => s.RecipeId == recipe.Id).ToList());
            }

        }

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
