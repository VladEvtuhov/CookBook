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
    public class RecipeService: IRecipeService
    {
        readonly IUnitOfWork database;
        public RecipeService(IUnitOfWork _database)
        {
            database = _database;
        }

        public void Create(CreateRecipeDTO recipeDTO)
        {
            var recipe = SetRecipe(recipeDTO);
            recipe.Id = database.Recipes.GetAll().Count() == 0 ? 1 : database.Recipes.GetAll().OrderBy(o => o.Id).Last().Id + 1;
            database.Recipes.Create(recipe);
            database.Save();
        }

        public void Edit(int id, CreateRecipeDTO recipeDTO)
        {
            var recipe = SetRecipe(recipeDTO);
            recipe.Id = id;
            database.Recipes.Update(recipe);
            database.Save();
        }

        public RecipeInfoDTO Get(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeInfoDTO>()).CreateMapper();
            return mapper.Map<Recipe, RecipeInfoDTO>(database.Recipes.FirstOrDefault(u => u.Id == id));
        }

        public IEnumerable<RecipeInfoDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Recipe, RecipeInfoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Recipe>, List<RecipeInfoDTO>>(database.Recipes.GetAll());
        }

        public void Remove(int id)
        {
            if (database.Recipes.FirstOrDefault(r => r.Id == id) == null)
                throw new ValidationException("Recipe not found", "");
            database.Recipes.Remove(id);
        }

        private Recipe SetRecipe(CreateRecipeDTO recipeDTO)
        {
            var category = database.Categories.FirstOrDefault(c => c.Name == recipeDTO.Category);
            var country = database.Countries.FirstOrDefault(c => c.Name == recipeDTO.Country);
            var ingridientType = database.IngridientTypes.FirstOrDefault(i => i.Name == recipeDTO.IngredientType);
            var creator = database.Users.FirstOrDefault(c => c.Email == recipeDTO.CreatorEmail);
            var cookingMethod = database.CookingMethods.FirstOrDefault(c => c.Name == recipeDTO.CookingMethod);
            if (category == null || country == null || ingridientType == null || creator == null || cookingMethod == null)
                throw new ValidationException("Unknown info", "");
            Recipe recipe = new Recipe()
            {
                Headline = recipeDTO.Headline,
                ShortDescription = recipeDTO.ShortDescription,
                Content = recipeDTO.Content,
                Category = category,
                CategoryId = category.Id,
                ImageUrl = recipeDTO.ImageUrl,
                Creator = creator,
                CreatorId = creator.Id,
                CookingMethod = cookingMethod,
                CookingMethodId = cookingMethod.Id,
                Country = country,
                CountryId = country.Id,
                IngredientType = ingridientType,
                IngredientTypeId = ingridientType.Id
            };
            return recipe;
        }
    }
}
