using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class СuisineСountryService:IСuisineСountryService
    {
        IUnitOfWork database;
        public СuisineСountryService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<СuisineСountryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<СuisineСountry, СuisineСountryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<СuisineСountry>, List<СuisineСountryDTO>>(database.CitchenCountryManager.GetAll());
        }

        public void SetCountry(string name)
        {
            var country = database.CitchenCountryManager.FirstOrDefault(c => c.Name == name);
            if (country != null)
                throw new ValidationException("Country is already exist", "");
            country = new СuisineСountry()
            {
                Name = name
            };
            database.CitchenCountryManager.Create(country);
            database.Save();
        }
    }
}
