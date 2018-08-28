using CookBook.BLL.DTO;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeProductsService
    {
        IEnumerable<string> GetProducts(int id);
        void UpdateProducts(int id, List<RecipeProductDTO> products);
    }
}
