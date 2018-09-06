using CookBook.BLL.Interfaces;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CookBook.WEB.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IUserRoleService userRoleService;
        public HomeController(IUserRoleService roleService)
        {
            userRoleService = roleService;
        }
        public virtual ActionResult Index()
        {
            //var a = await userRoleService.GetUserRolesAsync("nyti96@gmail.com");
            return View();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}