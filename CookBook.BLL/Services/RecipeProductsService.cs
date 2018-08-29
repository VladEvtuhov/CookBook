using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;

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
            var recipe = database.RecipeManager.FirstOrDefault(u => u.Id == id);
            List<string> products = new List<string>();
            if (recipe != null)
            {
                var productsId = database.RecipeProductManager.Find(r => r.RecipeId == recipe.Id);
                foreach (var productId in productsId)
                {
                    products.Add(database.ProductManager.Get(productId.Id).Name);
                }
            }
            return products;
        }

        public OperationDetails UpdateProducts(int id, List<RecipeProductDTO> products)
        {
            var recipe = database.RecipeManager.Get(id);
            if (recipe == null)
                return new OperationDetails(false, "Recipe not found", "");
            foreach(var product in recipe.Products)
            {
                database.RecipeProductManager.Remove(database.RecipeProductManager.FirstOrDefault(s => s.ProductId == product.Id && s.RecipeId == id));
            }
            foreach(var product in products)
            {
                var _product = database.ProductManager.FirstOrDefault(s => s.Name == product.Name);
                if(_product == null)
                {
                    _product = new Product()
                    {
                        Name = product.Name
                    };
                    database.ProductManager.Create(_product);
                }
                AddProduct(product.Quantity, recipe.Id, _product.Id);
            }
            return new OperationDetails(true, "Products updated successfully", "");
        }

        private void AddProduct(string quantity, int recipeId, int productId)
        {
            var recipe = database.RecipeManager.FirstOrDefault(s => s.Id == recipeId);
            var product = database.ProductManager.FirstOrDefault(s => s.Id == productId);
            RecipeProduct recipeProduct = new RecipeProduct()
            {
                RecipeId = recipeId,
                ProductId = productId,
                Quantity = quantity
            };
            database.RecipeProductManager.Create(recipeProduct);
            database.Save();
        }
    }
}
