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
        readonly MobileContext mobileContext;
        public RecipesRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetRecipes().Count();
        }

        public void Create(Recipe item)
        {
            mobileContext.GetRecipes().Add(item);
            item.Creator.UserRecipes.Add(item);
        }

        public IEnumerable<Recipe> Find(Func<Recipe, bool> predicate)
        {
            return mobileContext.GetRecipes().Where(predicate).ToList();
        }

        public Recipe FirstOrDefault(Func<Recipe, bool> predicate)
        {
            return mobileContext.GetRecipes().FirstOrDefault(predicate);
        }

        public Recipe Get(int id)
        {
            return mobileContext.GetRecipes().Find(u => u.Id == id);
        }

        public IEnumerable<Recipe> GetAll()
        {
            return mobileContext.GetRecipes();
        }

        public void Remove(int id)
        {
            var recipe = mobileContext.GetRecipes().FirstOrDefault(u => u.Id == id);
            if (recipe != null)
            {
                recipe.Creator.UserRecipes.Remove(recipe);
                mobileContext.GetRecipes().Remove(recipe);
            }
        }

        public void Remove(Recipe item)
        {
            var recipe = mobileContext.GetRecipes().FirstOrDefault(u => u == item);
            if (recipe != null)
            {
                recipe.Creator.UserRecipes.Remove(recipe);
                mobileContext.GetRecipes().Remove(recipe);
            }
        }

        public void Update(Recipe item)
        {
            var recipe = mobileContext.GetRecipes().FirstOrDefault(u => u.Id == item.Id);
            if (recipe != null)
            {
                recipe.Content = item.Content;
                recipe.Title = item.Title;
                recipe.ImageUrl = item.ImageUrl;
                recipe.ShortDescription = item.ShortDescription;
                recipe.CategoryId = item.Category.Id;
                recipe.Category = item.Category;
                recipe.CookingMethodId = item.CookingMethod.Id;
                recipe.CookingMethod = item.CookingMethod;
                recipe.CountryId = item.Country.Id;
                recipe.Country = item.Country;
                recipe.UpdateDate = DateTime.Now;
                recipe.CreatorId = item.Creator.Id;
                recipe.Creator = item.Creator;
                recipe.IngredientTypeId = item.IngredientType.Id;
                recipe.IngredientType = item.IngredientType;
            }
        }
    }
}
