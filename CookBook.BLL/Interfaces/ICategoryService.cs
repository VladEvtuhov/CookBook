using CookBook.BLL.DTO;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        void SetCategory(string name);
    }
}
