using CookBook.BLL.DTO;
using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IСuisineСountryService
    {
        IEnumerable<СuisineСountryDTO> GetAll();
        void SetCountry(string name);
    }
}
