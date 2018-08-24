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
            var products = mobileContext.RecipeProducts.Where(predicate).ToList();
            foreach(var product in products)
            {
                SetProductRelationship(product);
            }
            return products;
        }

        public RecipeProduct FirstOrDefault(Func<RecipeProduct, bool> predicate)
        {
            var product = mobileContext.RecipeProducts.FirstOrDefault(predicate);
            SetProductRelationship(product);
            return product;
        }

        public RecipeProduct Get(int id)
        {
            var product = mobileContext.RecipeProducts.First(d => d.Id == id);
            SetProductRelationship(product);
            return product;
        }

        public IEnumerable<RecipeProduct> GetAll()
        {
            var products = mobileContext.RecipeProducts;
            foreach (var product in products)
            {
                SetProductRelationship(product);
            }
            return products;
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

        private RecipeProduct SetProductRelationship(RecipeProduct recipeProduct)
        {
            recipeProduct.UserProduct = mobileContext.Products.First(p => p.Id == recipeProduct.ProductId);
            recipeProduct.UserRecipe = mobileContext.Recipes.First(p => p.Id == recipeProduct.RecipeId);
            return recipeProduct;
        }
    }
}
