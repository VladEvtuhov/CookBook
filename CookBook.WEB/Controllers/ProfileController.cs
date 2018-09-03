using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;

namespace CookBook.WEB.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IRecipeService recipeService;

        public ProfileController(IUserService _userService, IRecipeService _recipeService)
        {
            userService = _userService;
            recipeService = _recipeService;
        }

        [HttpGet]
        public ActionResult UserProfile()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> About(string email = null)
        {
            email = email ?? User.Identity.Name;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserViewModel>()).CreateMapper();
            UserViewModel profile = new UserViewModel();
            try
            {
                profile = mapper.Map<UserDTO, UserViewModel>(await userService.GetUserByEmailAsync(email));
            }
            catch
            {
                //Todo: change here
                //return RedirectToAction("Index", "Home");
            }
            return View(profile);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUserName(string email, string value)
        {
            await userService.UpdateUserInformation(email, User.Identity.Name, userName: value);
            return RedirectToAction("About");
        }

        [HttpPost]
        public async Task<ActionResult> UpdateInformation(string email, string value)
        {
            await userService.UpdateUserInformation(email, User.Identity.Name, information: value);
            return RedirectToAction("About");
        }

        public async Task<ActionResult> UserRecipes(string email = null, int page = 1, int pageSize = 4)
        {
            email = email ?? User.Identity.Name;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            var recipes = mapper.Map<IEnumerable<RecipesInfoDTO>, List<RecipesViewModel>>(await recipeService.GetUserRecipesAsync(email));
            PagedList<RecipesViewModel> model = new PagedList<RecipesViewModel>(recipes, page, pageSize);
            return View(model);
        }

        public ActionResult GetRecipe(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            var recipe = mapper.Map<RecipesInfoDTO, RecipesViewModel>(recipeService.Get(id));
            return View(recipe);
        }


    }
}