using CookBook.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public void SetRaiting(int id, int value, string email)
        {
            recipeRatingService.SetRating(id, email, value);
        }
    }
}
