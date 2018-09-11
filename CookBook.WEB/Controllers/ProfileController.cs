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
using System;

namespace CookBook.WEB.Controllers
{
    public partial class ProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IRecipeService recipeService;
        private readonly ICategoryService categoryService;
        private readonly IIngredientTypeService ingredientTypeService;
        private readonly ICuisineСountryService cuisineСountryService;
        private readonly ICookingMethodService cookingMethodService;
        private readonly IRecipeProductsService recipeProductsService;

        public ProfileController(IUserService _userService, IRecipeService _recipeService, ICategoryService _categoryService, IIngredientTypeService _ingredientTypeService,
            ICuisineСountryService _cuisineСountryService, ICookingMethodService _cookingMethodService, IRecipeProductsService _recipeProductsService)
        {
            userService = _userService;
            recipeService = _recipeService;
            categoryService = _categoryService;
            ingredientTypeService = _ingredientTypeService;
            cuisineСountryService = _cuisineСountryService;
            cookingMethodService = _cookingMethodService;
            recipeProductsService = _recipeProductsService;
        }

        [HttpGet]
        public virtual ActionResult UserProfile(string email = null)
        {
            return View();
        }

        [HttpGet]
        public virtual async Task<ActionResult> About(string email = null)
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
                //TODO: change redirect to error page, or page with text "user not found"
                return RedirectToAction(MVC.Home.Index());
            }
            return View(profile);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateUserName(string email, string value)
        {
            await userService.UpdateUserInformation(email, User.Identity.Name, userName: value);
            return RedirectToAction(MVC.Profile.About());
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateInformation(string email, string value)
        {
            await userService.UpdateUserInformation(email, User.Identity.Name, information: value);
            return RedirectToAction(MVC.Profile.About());
        }

        public virtual async Task<ActionResult> UserRecipes(string email = null, int page = 1, int pageSize = 4)
        {
            email = email ?? User.Identity.Name;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            var recipes = mapper.Map<IEnumerable<RecipesInfoDTO>, List<RecipesViewModel>>(await recipeService.GetUserRecipesAsync(email));
            PagedList<RecipesViewModel> model = new PagedList<RecipesViewModel>(recipes, page, pageSize);
            return View(model);
        }

        [HttpGet]
        public virtual ActionResult EditableRecipe(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EditRecipeDTO, EditRecipeViewModel>()).CreateMapper();
            var recipe = mapper.Map<EditRecipeDTO, EditRecipeViewModel>(recipeService.GetEditableRecipe(id));
            return View(recipe);
        }

        [HttpPost]
        public ActionResult RemoveRecipe(int id, string email = null)
        {
            email = email ?? User.Identity.Name;
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RecipesInfoDTO, RecipesViewModel>()).CreateMapper();
            var recipe = mapper.Map<RecipesInfoDTO, RecipesViewModel>(recipeService.Get(id));
            if(recipe.Creator.Email == email || User.IsInRole("admin"))
                recipeService.Remove(id);
            return RedirectToAction("UserRecipes", email);
        }

        [HttpPost]
        public virtual async Task<ActionResult> EditableRecipe(EditRecipeViewModel model)
        {
            if (User.Identity.Name != model.CreatorEmail && !User.IsInRole("admin"))
                return RedirectToAction(MVC.Profile.About());
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EditRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<EditRecipeViewModel, CreateRecipeDTO>(model);
            await recipeService.EditAsync(model.Id, recipe);
            return RedirectToAction(MVC.Profile.UserProfile(model.CreatorEmail));
        }

        [HttpGet]
        public virtual ActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddRecipe(CreateRecipeViewModel model)
        {
            if (User.Identity.Name != model.CreatorEmail && !User.IsInRole("admin"))
                return RedirectToAction(MVC.Profile.About());
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CreateRecipeViewModel, CreateRecipeDTO>()).CreateMapper();
            var recipe = mapper.Map<CreateRecipeViewModel, CreateRecipeDTO>(model);
            await recipeService.CreateAsync(recipe);
            return RedirectToAction(MVC.Profile.UserProfile(model.CreatorEmail));
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