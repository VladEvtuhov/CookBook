using CookBook.BLL.DTO;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface ICookingMethodService
    {
        IEnumerable<CookingMethodDTO> GetAll();
        void SetCookingMethod(string name);
    }
}
