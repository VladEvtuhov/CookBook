using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.WEB.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using PagedList;
using System.Web.Script.Services;
using Newtonsoft.Json;

namespace CookBook.WEB.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IRecipeService recipeService;
        private readonly ICategoryService categoryService;
        private readonly IIngredientTypeService ingredientTypeService;
        private readonly ICuisineСountryService cuisineСountryService;
        private readonly ICookingMethodService cookingMethodService;

        public ProfileController(IUserService _userService, IRecipeService _recipeService, ICategoryService _categoryService, IIngredientTypeService _ingredientTypeService,
            ICuisineСountryService _cuisineСountryService, ICookingMethodService _cookingMethodService)
        {
            userService = _userService;
            recipeService = _recipeService;
            categoryService = _categoryService;
            ingredientTypeService = _ingredientTypeService;
            cuisineСountryService = _cuisineСountryService;
            cookingMethodService = _cookingMethodService;
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

        [HttpGet]
        public ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRecipe(CreateRecipeViewModel model)
        {
            if(User.Identity.Name != model.CreatorEmail && !User.IsInRole("admin"))
                return RedirectToAction("About");

            //await recipeService.CreateAsync()
            return RedirectToAction("AddRecipe");
        }

        [HttpGet]
        public string GetCategories()
        {
            var mapper = new MapperConfiguration(cfg =>
            cfg.CreateMap<CategoryDTO, string>().ConvertUsing(u => u.Name)).CreateMapper();
            var categories = mapper.Map<IEnumerable<CategoryDTO>, List<string>>(categoryService.GetAll());
            return JsonConvert.SerializeObject(categories);
        }

        [HttpGet]
        public string GetIngredientTypes()
        {
            var mapper = new MapperConfiguration(cfg =>
            cfg.CreateMap<IngredientTypeDTO, string>().ConvertUsing(u => u.Name)).CreateMapper();
            var ingredientTypes = mapper.Map<IEnumerable<IngredientTypeDTO>, List<string>>(ingredientTypeService.GetAll());
            return JsonConvert.SerializeObject(ingredientTypes);
        }

        [HttpGet]
        public string GetCuisineCountries()
        {
            var mapper = new MapperConfiguration(cfg =>
            cfg.CreateMap<CuisineСountryDTO, string>().ConvertUsing(u => u.Name)).CreateMapper();
            var cuisineCountries = mapper.Map<IEnumerable<CuisineСountryDTO>, List<string>>(cuisineСountryService.GetAll());
            return JsonConvert.SerializeObject(cuisineCountries);
        }

        [HttpGet]
        public string GetCookingMethods()
        {
            var mapper = new MapperConfiguration(cfg =>
            cfg.CreateMap<CookingMethodDTO, string>().ConvertUsing(u => u.Name)).CreateMapper();
            var cookingMethods = mapper.Map<IEnumerable<CookingMethodDTO>, List<string>>(cookingMethodService.GetAll());
            return JsonConvert.SerializeObject(cookingMethods);
        }
    }
}