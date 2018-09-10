using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class RecipeService: IRecipeService
    {
        readonly IUnitOfWork database;
        public RecipeService(IUnitOfWork _database)
        {
            database = _database;
        }

        public async Task CreateAsync(CreateRecipeDTO recipeDTO)
        {
            var recipe = await SetRecipeAsync(recipeDTO);
            database.RecipeManager.Create(recipe);
            database.Save();
        }

        public async Task EditAsync(int id, CreateRecipeDTO recipeDTO)
        {
            var recipe = await SetRecipeAsync(recipeDTO);
            recipe.Id = id;
            database.RecipeManager.Update(recipe);
            database.Save();
        }

        public async Task<IEnumerable<RecipesInfoDTO>> GetUserRecipesAsync(string email)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipesInfoDTO>()).CreateMapper();
            var user = await database.UserManager.FindByEmailAsync(email);
            return mapper.Map<IEnumerable<Recipe>, List<RecipesInfoDTO>>(database.RecipeManager.Find(p => p.CreatorId == user.Id));
        }

        public RecipesInfoDTO Get(int id)
        {
            var recipe = database.RecipeManager.FirstOrDefault(u => u.Id == id);
            if (recipe == null)
                throw new ValidationException("An error occurred during receipt retrieving", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipesInfoDTO>()).CreateMapper();
            return mapper.Map<Recipe, RecipesInfoDTO>(recipe);
        }

        public EditRecipeDTO GetEditableRecipe(int id)
        {
            var recipe = database.RecipeManager.FirstOrDefault(u => u.Id == id);
            if (recipe == null)
                throw new ValidationException("An error occurred during receipt retrieving", "");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, EditRecipeDTO>()
            .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.Name))
            .ForMember(d => d.CookingMethod, opt => opt.MapFrom(s => s.CookingMethod.Name))
            .ForMember(d => d.CuisineCountry, opt => opt.MapFrom(s => s.Country.Name))
            .ForMember(d => d.IngredientType, opt => opt.MapFrom(s => s.IngredientType.Name))).CreateMapper();
            return mapper.Map<Recipe, EditRecipeDTO>(recipe);
        }

        public IEnumerable<RecipesInfoDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipesInfoDTO>()).CreateMapper();
            var info = mapper.Map<IEnumerable<Recipe>, List<RecipesInfoDTO>>(database.RecipeManager.GetAll());
            return info;
        }

        public OperationDetails Remove(int id)
        {
            if (database.RecipeManager.FirstOrDefault(r => r.Id == id) == null)
                return new OperationDetails(false, "Recipe not found", "");
            database.RecipeManager.Remove(id);
            database.Save();
            return new OperationDetails(true, "Recipe removed successfully", "");
        }

        private async Task<Recipe> SetRecipeAsync(CreateRecipeDTO recipeDTO)
        {
            var category = database.CategoryManager.FirstOrDefault(c => c.Name == recipeDTO.Category);
            var country = database.CitchenCountryManager.FirstOrDefault(c => c.Name == recipeDTO.CuisineCountry);
            var ingridientType = database.IngridientTypeManager.FirstOrDefault(i => i.Name == recipeDTO.IngredientType);
            var creator = await database.UserManager.FindByEmailAsync(recipeDTO.CreatorEmail);
            var cookingMethod = database.CookingMethodManager.FirstOrDefault(c => c.Name == recipeDTO.CookingMethod);
            if (category == null || country == null || ingridientType == null || creator == null || cookingMethod == null)
                throw new ValidationException("Unknown info", "");
            Recipe recipe = new Recipe()
            {
                Title = recipeDTO.Title,
                ShortDescription = recipeDTO.ShortDescription,
                Content = recipeDTO.Content,
                Category = category,
                ImageUrl = recipeDTO.ImageUrl,
                Creator = creator,
                CookingMethod = cookingMethod,
                Country = country,
                IngredientType = ingridientType,
            };
            return recipe;
        }
    }
}
