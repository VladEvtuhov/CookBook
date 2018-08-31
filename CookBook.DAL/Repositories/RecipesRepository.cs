using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class RecipesRepository : IRepository<Recipe>
    {
        readonly ApplicationDbContext mobileContext;
        public RecipesRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.Recipes.Count();
        }

        public void Create(Recipe item)
        {
            mobileContext.Recipes.Add(item);
        }

        public IEnumerable<Recipe> Find(Func<Recipe, bool> predicate)
        {
            var recipes = mobileContext.Recipes.Where(predicate).ToList();
            foreach(var recipe in recipes)
            {
                SetRecipeRelationship(recipe);
            }
            return recipes;
        }

        public Recipe FirstOrDefault(Func<Recipe, bool> predicate)
        {
            var recipe = mobileContext.Recipes.FirstOrDefault(predicate);
            SetRecipeRelationship(recipe);
            return recipe;
        }

        public IEnumerable<Recipe> Take(Func<Recipe, bool> predicate, int skipCount, int takeCount)
        {
            return mobileContext.Recipes.Where(predicate).OrderBy(s => s.Id).Skip(skipCount).Take(takeCount);
        }

        public Recipe Get(int id)
        {
            var recipe = mobileContext.Recipes.First(u => u.Id == id);
            SetRecipeRelationship(recipe);
            return recipe;
        }

        public IEnumerable<Recipe> GetAll()
        {
            var recipes = mobileContext.Recipes.ToList();
            foreach (var recipe in recipes)
            {
                SetRecipeRelationship(recipe);
            }
            return recipes;
        }

        public void Remove(int id)
        {
            var recipe = mobileContext.Recipes.FirstOrDefault(u => u.Id == id);
            if (recipe != null)
            {
                mobileContext.Recipes.Remove(recipe);
            }
        }

        public void Remove(Recipe item)
        {
            var recipe = mobileContext.Recipes.FirstOrDefault(u => u == item);
            if (recipe != null)
            {
                mobileContext.Recipes.Remove(recipe);
            }
        }

        public void Update(Recipe item)
        {
            var recipe = mobileContext.Recipes.FirstOrDefault(u => u.Id == item.Id);
            if (recipe != null)
            {
                recipe.Content = item.Content;
                recipe.Title = item.Title;
                recipe.ImageUrl = item.ImageUrl;
                recipe.ShortDescription = item.ShortDescription;
                recipe.Category = item.Category;
                recipe.CookingMethod = item.CookingMethod;
                recipe.Country = item.Country;
                recipe.UpdateDate = DateTime.Now;
                recipe.Creator = item.Creator;
                recipe.IngredientType = item.IngredientType;
            }
        }

        private Recipe SetRecipeRelationship(Recipe recipe)
        {
            recipe.Creator = mobileContext.Users.First(p => p.Id == recipe.CreatorId);
            recipe.Category = mobileContext.Categories.First(p => p.Id == recipe.CategoryId);
            recipe.CookingMethod = mobileContext.CookingMethods.First(p => p.Id == recipe.CookingMethodId);
            recipe.Country = mobileContext.CuisineСountries.First(p => p.Id == recipe.CountryId);
            recipe.IngredientType = mobileContext.IngredientTypes.First(p => p.Id == recipe.IngredientTypeId);
            return recipe;
        }
    }
}
