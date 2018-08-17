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
    public class RecipeRatingsRepository : IRepository<RecipeRating>
    {
        readonly MobileContext mobileContext;
        public RecipeRatingsRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetRecipeRatings().Count();
        }

        public void Create(RecipeRating item)
        {
            var recipeRating = mobileContext.GetRecipeRatings().FirstOrDefault(p => p.CreatorId == item.CreatorId && p.RecipeId == item.RecipeId);
            if (recipeRating == null)
            {
                mobileContext.GetRecipeRatings().Add(item);
                item.Creator.RecipesRatings.Add(item);
                item.Recipe.RecipesRatings.Add(item);
            }
        }

        public IEnumerable<RecipeRating> Find(Func<RecipeRating, bool> predicate)
        {
            return mobileContext.GetRecipeRatings().Where(predicate).ToList();
        }

        public RecipeRating FirstOrDefault(Func<RecipeRating, bool> predicate)
        {
            return mobileContext.GetRecipeRatings().FirstOrDefault(predicate);
        }

        public RecipeRating Get(int id)
        {
            return mobileContext.GetRecipeRatings().Find(p => p.Id == id);
        }

        public IEnumerable<RecipeRating> GetAll()
        {
            return mobileContext.GetRecipeRatings();
        }

        public void Remove(int id)
        {
            var recipeRating = mobileContext.GetRecipeRatings().FirstOrDefault(p => p.Id == id);
            if (recipeRating != null)
            {
                recipeRating.Recipe.RecipesRatings.Remove(recipeRating);
                recipeRating.Creator.RecipesRatings.Remove(recipeRating);
                mobileContext.GetRecipeRatings().Remove(recipeRating);
            }
        }

        public void Remove(RecipeRating item)
        {
            var recipeRating = mobileContext.GetRecipeRatings().FirstOrDefault(p => p == item);
            if (recipeRating != null)
            {
                recipeRating.Recipe.RecipesRatings.Remove(recipeRating);
                recipeRating.Creator.RecipesRatings.Remove(recipeRating);
                mobileContext.GetRecipeRatings().Remove(recipeRating);
            }
        }

        public void Update(RecipeRating item)
        {
            var recipeRating = mobileContext.GetRecipeRatings().FirstOrDefault(p => p.Id == item.Id);
            if (recipeRating != null)
            {
                recipeRating.Rating = item.Rating;
            }
        }
    }
}
