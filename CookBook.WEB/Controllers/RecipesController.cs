using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.WEB.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CookBook.WEB.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService _recipeService)
        {
            recipeService = _recipeService;
        }
        public virtual ActionResult Index()
        {
            var recipesCount = recipeService.GetCount();
            ViewData["RecipesCount"] = recipesCount;
            return View();
        }

        public virtual string GetRecipes(int page = 0)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            var recipes = mapper.Map<IEnumerable<RecipesInfoDTO>, List<RecipesViewModel>>(recipeService.GetRecipesByPage(page, 6));
            return JsonConvert.SerializeObject(recipes);
        }
    }
}