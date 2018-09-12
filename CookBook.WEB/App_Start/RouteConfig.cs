using System.Web.Mvc;
using System.Web.Routing;

namespace CookBook.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Profile",
                url: "Profile",
                defaults: new { controller = "Profile", action = "UserProfile", email = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Login",
                url: "Login",
                defaults: new { controller = "Account", action = "Login", email = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Logout",
                url: "Logout",
                defaults: new { controller = "Account", action = "Logout", email = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Register",
                url: "Registration",
                defaults: new { controller = "Account", action = "Register", email = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Recipes", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
