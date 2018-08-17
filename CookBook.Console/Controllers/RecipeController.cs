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
    public class RecipeController
    {
        private readonly IRecipeService recipeService;
        public RecipeController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }

        public IEnumerable<RecipeViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipeInfoDTO, RecipeViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<RecipeInfoDTO>, List<RecipeViewModel>>(recipeService.GetAll());
        }

        public RecipeViewModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipeInfoDTO, RecipeViewModel>()).CreateMapper();
            return mapper.Map<RecipeInfoDTO, RecipeViewModel>(recipeService.Get(id));
        }

        public void Create(CreateRecipeViewModel item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<CreateRecipeViewModel, CreateRecipeDTO>(item);
            recipeService.Create(recipe);
        }

        public void Update(int id, CreateRecipeViewModel item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<CreateRecipeViewModel, CreateRecipeDTO>(item);
            recipeService.Edit(id, recipe);
        }

        public void Remove(int id)
        {
            recipeService.Remove(id);
        }
    }
}
