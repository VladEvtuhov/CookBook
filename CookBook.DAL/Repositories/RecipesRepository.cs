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
            return mobileContext.Recipes.Where(predicate).ToList();
        }

        public Recipe FirstOrDefault(Func<Recipe, bool> predicate)
        {
            return mobileContext.Recipes.FirstOrDefault(predicate);
        }

        public Recipe Get(int id)
        {
            return mobileContext.Recipes.First(u => u.Id == id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return mobileContext.Recipes;
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
    }
}
