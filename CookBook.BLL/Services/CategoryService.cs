using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;

namespace CookBook.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        IUnitOfWork database;
        public CategoryService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<CategoryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(database.CategoryManager.GetAll());
        }

        public OperationDetails SetCategory(string name)
        {
            var category = database.CategoryManager.FirstOrDefault(c => c.Name == name);
            if (category != null)
                return new OperationDetails(false, "Category is already exist", "");
            category = new Category()
            {
                Name = name
            };
            database.CategoryManager.Create(category);
            database.Save();
            return new OperationDetails(true, "Category was created", "");
        }
    }
}
