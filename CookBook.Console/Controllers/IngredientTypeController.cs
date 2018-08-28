using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;

namespace CookBook.Console.Controllers
{
    public class IngredientTypeController
    {
        private readonly IIngredientTypeService ingredientTypeService;
        public IngredientTypeController(IIngredientTypeService _ingredientTypeService)
        {
            ingredientTypeService = _ingredientTypeService;
        }

        public IEnumerable<IngredientTypeViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<IngredientTypeDTO, IngredientTypeViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<IngredientTypeDTO>, List<IngredientTypeViewModel>>(ingredientTypeService.GetAll());
        }

        public void SetIngredientType(string name)
        {
            ingredientTypeService.SetIngredientType(name);
        }
    }
}
