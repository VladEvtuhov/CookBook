using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;

namespace CookBook.Console.Controllers
{
    public class ProductController
    {
        private readonly IRecipeProductsService productService;
        public ProductController(IRecipeProductsService _productService)
        {
            productService = _productService;
        }

        public void UpdateProducts(int id, List<ProductViewModel> _products)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ProductViewModel, RecipeProductDTO>()).CreateMapper();
            var products = mapper.Map<IEnumerable<ProductViewModel>, List<RecipeProductDTO>>(_products);
            productService.UpdateProducts(id, products);
        }
    }
}
