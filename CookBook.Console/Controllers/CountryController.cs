using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Console.Controllers
{
    public class CountryController
    {
        private readonly ICountryService countryService;
        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }

        public IEnumerable<CountryViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CountryDTO, CountryViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CountryDTO>, List<CountryViewModel>>(countryService.GetAll());
        }

        public void SetCountry(string name)
        {
            countryService.SetCountry(name);
        }
    }
}
