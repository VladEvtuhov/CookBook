using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface ICookingMethodService
    {
        IEnumerable<CookingMethodDTO> GetAll();
        OperationDetails SetCookingMethod(string name);
    }
}
