using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;
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

        public async Task CreateAsync(CreateRecipeViewModel item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<CreateRecipeViewModel, CreateRecipeDTO>(item);
            await recipeService.CreateAsync(recipe);
        }

        public IEnumerable<RecipesViewModel> GetUserRecipes(string email)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<RecipesInfoDTO>, List<RecipesViewModel>>(recipeService.GetUserRecipes(email));
        }

        public async Task UpdateAsync(int id, CreateRecipeViewModel item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<CreateRecipeViewModel, CreateRecipeDTO>(item);
            await recipeService.EditAsync(id, recipe);
        }

        public void Remove(int id)
        {
            recipeService.Remove(id);
        }
    }
}
