using CookBook.BLL.Interfaces;
using System.Threading.Tasks;

namespace CookBook.Console.Controllers
{
    public class RatingController
    {
        private readonly IRecipeRatingService recipeRatingService;
        public RatingController(IRecipeRatingService _recipeRatingService)
        {
            recipeRatingService = _recipeRatingService;
        }

        public async Task SetRaitingAsync(int id, int value, string email)
        {
            await recipeRatingService.SetRatingAsync(id, email, value);
        }
    }
}
