using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;

namespace CookBook.Console.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CategoryDTO>, List<CategoryViewModel>>(categoryService.GetAll());
        }

        public void SetCategory(string name)
        {
            categoryService.SetCategory(name);
        }
    }
}
