using CookBook.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipesInfoDTO> GetAll();
        IEnumerable<RecipesInfoDTO> GetUserRecipes(string email);
        RecipesInfoDTO Get(int id);
        Task CreateAsync(CreateRecipeDTO recipeDTO);
        void Remove(int id);
        Task EditAsync(int id, CreateRecipeDTO recipeDTO);
    }
}
