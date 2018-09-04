using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;

namespace CookBook.BLL.Interfaces
{
    public interface ICuisineСountryService
    {
        IEnumerable<CuisineСountryDTO> GetAll();
        OperationDetails SetCountry(string name);
    }
}
