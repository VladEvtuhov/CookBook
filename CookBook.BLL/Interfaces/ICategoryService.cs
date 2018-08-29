using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        OperationDetails SetCategory(string name);
    }
}
