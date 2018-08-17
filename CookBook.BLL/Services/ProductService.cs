using AutoMapper;
using CookBook.BLL.DTO;
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
    public class ProductService: IProductService
    {
        IUnitOfWork database;
        public ProductService(IUnitOfWork _database)
        {
            database = _database;
        }

        public void CreateProduct(ProductDTO productDTO)
        {
            if (database.Products.FirstOrDefault(p => p.Name == productDTO.Name) != null)
                throw new ValidationException("Product is already exist", "");
            var product = new Product()
            {
                Id = database.Products.GetAll().Count() == 0 ? 1 : database.Products.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Name = productDTO.Name
            };
            database.Products.Create(product);
            database.Save();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(database.Products.GetAll());
        }

        public void RemoveProduct(ProductDTO productDTO)
        {
            var product = database.Products.FirstOrDefault(p => p.Name == productDTO.Name);
            if (product == null)
                throw new ValidationException("Product not found", "");
            database.Products.Remove(product);
            database.Save();
        }
    }
}
