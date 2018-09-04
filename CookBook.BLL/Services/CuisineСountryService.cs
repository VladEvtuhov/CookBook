using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;

namespace CookBook.BLL.Services
{
    public class CuisineСountryService:ICuisineСountryService
    {
        IUnitOfWork database;
        public CuisineСountryService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<CuisineСountryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CuisineСountry, CuisineСountryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CuisineСountry>, List<CuisineСountryDTO>>(database.CitchenCountryManager.GetAll());
        }

        public OperationDetails SetCountry(string name)
        {
            var country = database.CitchenCountryManager.FirstOrDefault(c => c.Name == name);
            if (country != null)
                return new OperationDetails(false, "Cuisine country is already exist", "");
            country = new CuisineСountry()
            {
                Name = name
            };
            database.CitchenCountryManager.Create(country);
            database.Save();
            return new OperationDetails(true, "Cuisine country created successfully", "");
        }
    }
}
