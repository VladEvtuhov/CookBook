using CookBook.DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CookBook.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        UserManager<ApplicationUser> UserManager { get; }
        RoleManager<IdentityRole> RoleManager { get; }
        IRepository<Product> ProductManager { get; }
        IRepository<Category> CategoryManager { get; }
        IRepository<CookingMethod> CookingMethodManager { get; }
        IRepository<CitchenCountry> CitchenCountryManager { get; }
        IRepository<IngredientType> IngridientTypeManager { get; }
        IRepository<Recipe> RecipeManager { get; }
        IRepository<RecipeProduct> RecipeProductManager { get; }
        IRepository<Comment> CommentManager { get; }
        IRepository<RecipeRating> RecipeRatingManager { get; }
        void Save();
    }
}
