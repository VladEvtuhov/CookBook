using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeService
    {
        IEnumerable<RecipeInfoDTO> GetAll();
        RecipeInfoDTO Get(int id);
        void Create(CreateRecipeDTO recipeDTO);
        void Remove(int id);
        void Edit(int id, CreateRecipeDTO recipeDTO);
    }
}
