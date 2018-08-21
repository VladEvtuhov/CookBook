using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class RecipeProductsRepository : IRepository<RecipeProduct>
    {
        MobileContext mobileContext;
        public RecipeProductsRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetRecipeProducts().Count();
        }

        public void Create(RecipeProduct item)
        {
            mobileContext.GetRecipeProducts().Add(item);
            var recipe = mobileContext.GetRecipes().First(r => r.Id == item.RecipeId);
            var product = mobileContext.GetProducts().First(p => p.Id == item.Id);
            recipe.Products.Add(product);
        }

        public IEnumerable<RecipeProduct> Find(Func<RecipeProduct, bool> predicate)
        {
            return mobileContext.GetRecipeProducts().Where(predicate).ToList();
        }

        public RecipeProduct FirstOrDefault(Func<RecipeProduct, bool> predicate)
        {
            return mobileContext.GetRecipeProducts().FirstOrDefault(predicate);
        }

        public RecipeProduct Get(int id)
        {
            return mobileContext.GetRecipeProducts().Find(r => r.Id == id);
        }

        public IEnumerable<RecipeProduct> GetAll()
        {
            return mobileContext.GetRecipeProducts();
        }

        public void Remove(int id)
        {
            var recipeProduct = mobileContext.GetRecipeProducts().FirstOrDefault(r => r.Id == id);
            if (recipeProduct != null)
            {
                var recipe = mobileContext.GetRecipes().First(r => r.Id == recipeProduct.RecipeId);
                var product = mobileContext.GetProducts().First(p => p.Id == recipeProduct.Id);
                recipe.Products.Remove(product);
                mobileContext.GetRecipeProducts().Remove(recipeProduct);
            }
        }

        public void Remove(RecipeProduct item)
        {
            var recipeProduct = mobileContext.GetRecipeProducts().FirstOrDefault(r => r.ProductId == item.ProductId && r.RecipeId == item.RecipeId);
            if (recipeProduct != null)
            {
                var recipe = mobileContext.GetRecipes().First(r => r.Id == recipeProduct.RecipeId);
                var product = mobileContext.GetProducts().First(p => p.Id == recipeProduct.Id);
                recipe.Products.Remove(product);
                mobileContext.GetRecipeProducts().Remove(recipeProduct);
            }
        }

        public void Update(RecipeProduct item)
        {
            var recipeProduct = mobileContext.GetRecipeProducts().FirstOrDefault(p => p.Id == item.Id);
            if (recipeProduct != null)
            {
                recipeProduct.RecipeId = item.RecipeId;
                recipeProduct.ProductId = item.ProductId;
                recipeProduct.Quantity = item.Quantity;
            }
        }
    }
}
