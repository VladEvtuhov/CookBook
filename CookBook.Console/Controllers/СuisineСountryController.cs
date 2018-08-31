using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;

namespace CookBook.Console.Controllers
{
    public class СuisineСountryController
    {
        private readonly ICuisineСountryService countryService;
        public СuisineСountryController(ICuisineСountryService _countryService)
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
