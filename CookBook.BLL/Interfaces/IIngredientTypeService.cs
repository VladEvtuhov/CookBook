using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IIngredientTypeService
    {
        IEnumerable<IngredientTypeDTO> GetAll();
        OperationDetails SetIngredientType(string name);
    }
}
