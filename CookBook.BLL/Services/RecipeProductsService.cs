using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class RecipeProductsService : IRecipeProductsService
    {

        IUnitOfWork database;
        public RecipeProductsService(IUnitOfWork _database)
        {
            database = _database;
        }
        public IEnumerable<string> GetProducts(int id)
        {
            var recipe = database.Recipes.FirstOrDefault(u => u.Id == id);
            List<string> products = new List<string>();
            if (recipe != null)
            {
                var productsId = database.RecipeProducts.Find(r => r.RecipeId == recipe.Id);
                foreach (var productId in productsId)
                {
                    products.Add(database.Products.Get(productId.Id).Name);
                }
            }
            return products;
        }

        public void UpdateProducts(int id, List<string> products)
        {
            var recipe = database.Recipes.Get(id);
            if (recipe == null)
                throw new ValidationException("Recipe not found", "");
            foreach(var product in recipe.Products)
            {
                database.RecipeProducts.Remove(database.RecipeProducts.FirstOrDefault(s => s.ProductId == product.Id && s.RecipeId == id));
            }
            foreach(var product in products)
            {
                var _product = database.Products.FirstOrDefault(s => s.Name == product);
                if(_product == null)
                {
                    _product = new Product()
                    {
                        Id = database.Products.GetAll().Count() == 0 ? 1 : database.Products.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                        Name = product
                    };
                    database.Products.Create(_product);
                }
                AddProduct(recipe.Id, _product.Id);
            }
        }

        private void AddProduct(int recipeId, int productId)
        {
            var recipe = database.Recipes.FirstOrDefault(s => s.Id == recipeId);
            var product = database.Products.FirstOrDefault(s => s.Id == productId);
            RecipeProduct recipeProduct = new RecipeProduct()
            {
                Id = database.RecipeProducts.GetAll().Count() == 0 ? 1 : database.RecipeProducts.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                RecipeId = recipeId,
                ProductId = productId
            };
            database.RecipeProducts.Create(recipeProduct);
            recipe.Products.Add(product);
            database.Save();
        }
    }
}
