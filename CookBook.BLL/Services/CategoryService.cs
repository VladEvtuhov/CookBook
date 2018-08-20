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
            return mapper.Map<IEnumerable<Category>, List<CategoryDTO>>(database.Categories.GetAll());
        }

        public void SetCategory(string name)
        {
            var category = database.Categories.FirstOrDefault(c => c.Name == name);
            if (category != null)
                throw new ValidationException("Category is already exist", "");
            category = new Category()
            {
                Id = database.Categories.Count() == 0 ? 1 : database.Categories.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Name = name
            };
            database.Categories.Create(category);
            database.Save();
        }
    }
}
