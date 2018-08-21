using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<ApplicationUser> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<CookingMethod> CookingMethods { get; }
        IRepository<CitchenCountry> Countries { get; }
        IRepository<IngredientType> IngridientTypes { get; }
        IRepository<Recipe> Recipes { get; }
        IRepository<RecipeProduct> RecipeProducts { get; }
        IRepository<Comment> Comments { get; }
        IRepository<RecipeRating> RecipeRatings { get; }
        void Save();
    }
}
