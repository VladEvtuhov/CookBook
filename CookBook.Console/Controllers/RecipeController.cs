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

        public IEnumerable<RecipesViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<RecipesInfoDTO>, List<RecipesViewModel>>(recipeService.GetAll());
        }

        public RecipesViewModel Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            return mapper.Map<RecipesInfoDTO, RecipesViewModel>(recipeService.Get(id));
        }

        public void Create(CreateRecipeViewModel item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<CreateRecipeViewModel, CreateRecipeDTO>(item);
            recipeService.Create(recipe);
        }

        public IEnumerable<RecipesViewModel> GetUserRecipes(string email)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<RecipesInfoDTO>, List<RecipesViewModel>>(recipeService.GetUserRecipes(email));
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
