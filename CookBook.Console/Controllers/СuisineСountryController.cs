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
    public class СuisineСountryController
    {
        private readonly IСuisineСountryService countryService;
        public СuisineСountryController(IСuisineСountryService _countryService)
        {
            countryService = _countryService;
        }

        public IEnumerable<СuisineСountryViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<СuisineСountryDTO, СuisineСountryViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<СuisineСountryDTO>, List<СuisineСountryViewModel>>(countryService.GetAll());
        }

        public void SetCountry(string name)
        {
            countryService.SetCountry(name);
        }
    }
}
