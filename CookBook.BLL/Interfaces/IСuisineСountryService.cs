using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface IСuisineСountryService
    {
        IEnumerable<СuisineСountryDTO> GetAll();
        OperationDetails SetCountry(string name);
    }
}
