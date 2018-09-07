using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.WEB.Models;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CookBook.WEB.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                ClaimsIdentity claim = await userService.LoginAsync(model.Email, model.Password);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction(MVC.Home.Index());
                }
            }
            return View(model);
        }

        public virtual ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction(MVC.Account.Login());
        }

        [HttpGet]
        public virtual ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<RegisterViewModel, RegisterUserDTO>()).CreateMapper();
                var registerModel = mapper.Map<RegisterViewModel, RegisterUserDTO>(model);
                var modelState = await userService.CreateUserAsync(registerModel);
                if (!modelState.Succedeed)
                    ViewData["error"] = modelState.Message;
            }
            return View(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}