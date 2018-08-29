using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeProductsService
    {
        IEnumerable<string> GetProducts(int id);
        OperationDetails UpdateProducts(int id, List<RecipeProductDTO> products);
    }
}
