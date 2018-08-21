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
        readonly ApplicationDbContext mobileContext;
        public RecipeRatingsRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.RecipeRatings.Count();
        }

        public void Create(RecipeRating item)
        {
            var recipeRating = mobileContext.RecipeRatings.FirstOrDefault(p => p.CreatorId == item.CreatorId && p.RecipeId == item.RecipeId);
            if (recipeRating != null)
            {
                Update(item);
            }
            else
            {
                mobileContext.RecipeRatings.Add(item);
            }
        }

        public IEnumerable<RecipeRating> Find(Func<RecipeRating, bool> predicate)
        {
            return mobileContext.RecipeRatings.Where(predicate).ToList();
        }

        public RecipeRating FirstOrDefault(Func<RecipeRating, bool> predicate)
        {
            return mobileContext.RecipeRatings.FirstOrDefault(predicate);
        }

        public RecipeRating Get(int id)
        {
            return mobileContext.RecipeRatings.First(p => p.Id == id);
        }

        public IEnumerable<RecipeRating> GetAll()
        {
            return mobileContext.RecipeRatings;
        }

        public void Remove(int id)
        {
            var recipeRating = mobileContext.RecipeRatings.FirstOrDefault(p => p.Id == id);
            if (recipeRating != null)
            {
                mobileContext.RecipeRatings.Remove(recipeRating);
            }
        }

        public void Remove(RecipeRating item)
        {
            var recipeRating = mobileContext.RecipeRatings.FirstOrDefault(p => p == item);
            if (recipeRating != null)
            {
                mobileContext.RecipeRatings.Remove(recipeRating);
            }
        }

        public void Update(RecipeRating item)
        {
            var recipeRating = mobileContext.RecipeRatings.FirstOrDefault(p => p.CreatorId == item.CreatorId && p.RecipeId == item.RecipeId);
            if (recipeRating != null)
            {
                recipeRating.Rating = item.Rating;
            }
        }
    }
}
