using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipesInfoDTO> GetAll();
        Task<IEnumerable<RecipesInfoDTO>> GetUserRecipesAsync(string email);
        RecipesInfoDTO Get(int id);
        EditRecipeDTO GetEditableRecipe(int id);
        Task CreateAsync(CreateRecipeDTO recipeDTO);
        OperationDetails Remove(int id);
        Task EditAsync(int id, CreateRecipeDTO recipeDTO);
    }
}
