using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;

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

        public OperationDetails SetCountry(string name)
        {
            var country = database.CitchenCountryManager.FirstOrDefault(c => c.Name == name);
            if (country != null)
                return new OperationDetails(false, "Cuisine country is already exist", "");
            country = new СuisineСountry()
            {
                Name = name
            };
            database.CitchenCountryManager.Create(country);
            database.Save();
            return new OperationDetails(true, "Cuisine country created successfully", "");
        }
    }
}
