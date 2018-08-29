using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;

namespace CookBook.BLL.Services
{
    public class ProductService: IProductService
    {
        IUnitOfWork database;
        public ProductService(IUnitOfWork _database)
        {
            database = _database;
        }

        public OperationDetails CreateProduct(ProductDTO productDTO)
        {
            if (database.ProductManager.FirstOrDefault(p => p.Name == productDTO.Name) != null)
                return new OperationDetails(false, "Product is already exist", "");
            var product = new Product()
            {
                Name = productDTO.Name
            };
            database.ProductManager.Create(product);
            database.Save();
            return new OperationDetails(true, "Product created successfully", "");
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(database.ProductManager.GetAll());
        }

        public OperationDetails RemoveProduct(ProductDTO productDTO)
        {
            var product = database.ProductManager.FirstOrDefault(p => p.Name == productDTO.Name);
            if (product == null)
                return new OperationDetails(false, "Product not found", "");
            database.ProductManager.Remove(product);
            database.Save();
            return new OperationDetails(true, "Product removed successfully", "");
        }
    }
}
