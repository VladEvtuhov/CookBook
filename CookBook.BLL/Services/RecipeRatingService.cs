using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class RecipeRatingService : IRecipeRatingService
    {
        readonly IUnitOfWork database;
        public RecipeRatingService(IUnitOfWork _database)
        {
            database = _database;
        }

        public async Task<OperationDetails> SetRatingAsync(int id, string email, int value)
        {
            if(value < 1 || value > 5)
                return new OperationDetails(false, "Rating should be 1-5", "");
            var recipe = database.RecipeManager.FirstOrDefault(r => r.Id == id);
            var user = await database.UserManager.FindByEmailAsync(email);
            if (recipe == null || email == null)
                return new OperationDetails(false, "Recipe or email not found", "");
            RecipeRating recipeRating = new RecipeRating()
            {
                Recipe = recipe,
                RecipeId = recipe.Id,
                Creator = user,
                CreatorId = user.Id,
                Rating = value
            };
            database.RecipeRatingManager.Create(recipeRating);
            database.Save();
            recipe.AverageRating = recipe.RecipesRatings.Select(s => s.Rating).ToList().Average();
            database.Save();
            return new OperationDetails(true, "Rating setted", "");
        }
    }
}
