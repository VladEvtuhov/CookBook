using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.WEB.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CookBook.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if(model.Password == model.ConfirmPassword)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegisterViewModel, RegisterUserDTO>()).CreateMapper();
                var registerModel = mapper.Map<RegisterViewModel, RegisterUserDTO>(model);
                try
                {
                    await userService.CreateUserAsync(registerModel);
                }catch(Exception e)
                {
                    ViewData["error"] = e.Message;
                }
            }else
                ViewData["error"] = "Passwords don't match";
            return View();
        }
    }
}