using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.WEB.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CookBook.WEB.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;

        public ProfileController(IUserService service)
        {
            userService = service;
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
                var a = await userService.GetUserByEmailAsync(email);
                profile = mapper.Map<UserDTO, UserViewModel>(a);
            }
            catch
            {
                //Todo: change here
                //return RedirectToAction("Index", "Home");
            }
            return View(profile);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateInformation(string name)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserViewModel, UserDTO>()).CreateMapper();
            //var info = mapper.Map<UserViewModel, UserDTO>(model);
            //await userService.UpdateUserInformation(info);
            return RedirectToAction("About");
        }
    }
}