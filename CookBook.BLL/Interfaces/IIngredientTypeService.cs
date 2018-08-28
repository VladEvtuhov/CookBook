using CookBook.BLL.DTO;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IIngredientTypeService
    {
        IEnumerable<IngredientTypeDTO> GetAll();
        void SetIngredientType(string name);
    }
}
