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
    public class CitchenCountryController
    {
        private readonly ICitchenCountryService countryService;
        public CitchenCountryController(ICitchenCountryService _countryService)
        {
            countryService = _countryService;
        }

        public IEnumerable<CitchenCountryViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CitchenCountryDTO, CitchenCountryViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CitchenCountryDTO>, List<CitchenCountryViewModel>>(countryService.GetAll());
        }

        public void SetCountry(string name)
        {
            countryService.SetCountry(name);
        }
    }
}
