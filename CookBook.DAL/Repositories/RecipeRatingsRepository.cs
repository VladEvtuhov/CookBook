using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var ratings = mobileContext.RecipeRatings.Where(predicate).ToList();
            foreach(var rating in ratings)
            {
                SetRatingRelationship(rating);
            }
            return ratings;
        }

        public IEnumerable<RecipeRating> Take(Func<RecipeRating, bool> predicate, int skipCount, int takeCount)
        {
            return mobileContext.RecipeRatings.Where(predicate).OrderBy(s => s.Id).Skip(skipCount).Take(takeCount);
        }

        public RecipeRating FirstOrDefault(Func<RecipeRating, bool> predicate)
        {
            var rating = mobileContext.RecipeRatings.FirstOrDefault(predicate);
            SetRatingRelationship(rating);
            return rating;
        }

        public RecipeRating Get(int id)
        {
            var rating = mobileContext.RecipeRatings.First(p => p.Id == id);
            SetRatingRelationship(rating);
            return rating;
        }

        public IEnumerable<RecipeRating> GetAll()
        {
            var ratings = mobileContext.RecipeRatings;
            foreach (var rating in ratings)
            {
                SetRatingRelationship(rating);
            }
            return ratings;
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

        private RecipeRating SetRatingRelationship(RecipeRating recipeRating)
        {
            recipeRating.Creator = mobileContext.Users.First(p => p.Id == recipeRating.CreatorId);
            recipeRating.Recipe = mobileContext.Recipes.First(p => p.Id == recipeRating.RecipeId);
            return recipeRating;
        }
    }
}
