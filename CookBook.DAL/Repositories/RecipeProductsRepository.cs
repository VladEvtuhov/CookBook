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
        ApplicationDbContext mobileContext;
        public RecipeProductsRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.RecipeProducts.Count();
        }

        public void Create(RecipeProduct item)
        {
            mobileContext.RecipeProducts.Add(item);
        }

        public IEnumerable<RecipeProduct> Find(Func<RecipeProduct, bool> predicate)
        {
            return mobileContext.RecipeProducts.Where(predicate).ToList();
        }

        public RecipeProduct FirstOrDefault(Func<RecipeProduct, bool> predicate)
        {
            return mobileContext.RecipeProducts.FirstOrDefault(predicate);
        }

        public RecipeProduct Get(int id)
        {
            return mobileContext.RecipeProducts.First(d => d.Id == id);
        }

        public IEnumerable<RecipeProduct> GetAll()
        {
            return mobileContext.RecipeProducts;
        }

        public void Remove(int id)
        {
            var recipeProduct = mobileContext.RecipeProducts.FirstOrDefault(r => r.Id == id);
            if (recipeProduct != null)
            {
                mobileContext.RecipeProducts.Remove(recipeProduct);
            }
        }

        public void Remove(RecipeProduct item)
        {
            var recipeProduct = mobileContext.RecipeProducts.FirstOrDefault(r => r.ProductId == item.ProductId && r.RecipeId == item.RecipeId);
            if (recipeProduct != null)
            {
                mobileContext.RecipeProducts.Remove(recipeProduct);
            }
        }

        public void Update(RecipeProduct item)
        {
            var recipeProduct = mobileContext.RecipeProducts.FirstOrDefault(p => p.Id == item.Id);
            if (recipeProduct != null)
            {
                recipeProduct.RecipeId = item.RecipeId;
                recipeProduct.ProductId = item.ProductId;
                recipeProduct.Quantity = item.Quantity;
            }
        }
    }
}
