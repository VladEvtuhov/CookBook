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
    public class CountryService:ICountryService
    {
        IUnitOfWork database;
        public CountryService(IUnitOfWork _database)
        {
            database = _database;
        }

        public IEnumerable<CountryDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Country, CountryDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Country>, List<CountryDTO>>(database.Countries.GetAll());
        }

        public void SetCountry(string name)
        {
            var country = database.Countries.FirstOrDefault(c => c.Name == name);
            if (country != null)
                throw new ValidationException("Country is already exist", "");
            country = new Country()
            {
                Id = database.Countries.Count() == 0 ? 1 : database.Countries.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                Name = name
            };
            database.Countries.Create(country);
            database.Save();
        }
    }
}
