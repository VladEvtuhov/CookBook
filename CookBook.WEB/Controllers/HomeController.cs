using CookBook.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CookBook.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        public HomeController(ICategoryService service)
        {
            categoryService = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}