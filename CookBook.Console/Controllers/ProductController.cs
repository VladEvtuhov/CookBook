using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Console.Controllers
{
    public class ProductController
    {
        private readonly IRecipeProductsService productService;
        public ProductController(IRecipeProductsService _productService)
        {
            productService = _productService;
        }

        public void UpdateProducts(int id, List<string> products)
        {
            productService.UpdateProducts(id, products);
        }
    }
}
