using CookBook.BLL.DTO;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IСuisineСountryService
    {
        IEnumerable<СuisineСountryDTO> GetAll();
        void SetCountry(string name);
    }
}
