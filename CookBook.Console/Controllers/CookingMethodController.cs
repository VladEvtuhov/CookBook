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
    public class CookingMethodController
    {
        private readonly ICookingMethodService cookingMethodService;
        public CookingMethodController(ICookingMethodService _cookingMethodService)
        {
            cookingMethodService = _cookingMethodService;
        }

        public IEnumerable<CookingMethodViewModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CookingMethodDTO, CookingMethodViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CookingMethodDTO>, List<CookingMethodViewModel>>(cookingMethodService.GetAll());
        }

        public void SetCookingMethod(string name)
        {
            cookingMethodService.SetCookingMethod(name);
        }
    }
}
