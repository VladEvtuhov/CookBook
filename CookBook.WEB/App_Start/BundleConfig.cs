using System.Web;
using System.Web.Optimization;

namespace CookBook.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/unobtrusive").Include(
                 "~/Scripts/jquery.unobtrusive*"));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-editable/js").Include(
                      "~/Scripts/bootstrap-editable/js/bootstrap-editable.js"));
            bundles.Add(new ScriptBundle("~/bundles/profile/about/js").Include(
                      "~/Scripts/profile/about.js"));
            bundles.Add(new ScriptBundle("~/bundles/profile/create-recipe").Include(
                      "~/Scripts/profile/create-recipe.js"));
            bundles.Add(new ScriptBundle("~/bundles/profile").Include(
                      "~/Scripts/profile/profile.js"));
            bundles.Add(new ScriptBundle("~/bundles/profile/user-recipes/js").Include(
                      "~/Scripts/profile/user-recipes.js"));
            bundles.Add(new ScriptBundle("~/bundles/profile/edit-values/js").Include(
                      "~/Scripts/profile/edit-recipe-values.js"));
            bundles.Add(new ScriptBundle("~/bundles/profile/refresh-profile-recipes").Include(
                      "~/Scripts/profile/refr-rec-profile.js"));
            bundles.Add(new ScriptBundle("~/bundles/recipes").Include(
                      "~/Scripts/recipes.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/Account").Include(
                "~/Content/Account/account.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap-editable/css").Include(
                "~/Content/bootstrap-editable/css/bootstrap-editable.css"));
            bundles.Add(new StyleBundle("~/Content/profile/cr").Include(
                "~/Content/profile/create-recipe.css"));
            bundles.Add(new StyleBundle("~/Content/profile/about/css").Include(
                "~/Content/profile/about.css"));
            bundles.Add(new StyleBundle("~/Content/profile/user-profile").Include(
                "~/Content/profile/user-profile.css"));
            bundles.Add(new StyleBundle("~/Content/profile/user-recipes/css").Include(
                "~/Content/profile/user-recipes.css"));
            bundles.Add(new StyleBundle("~/Content/pageList").Include(
                "~/Content/PagedList.css"));
            bundles.Add(new StyleBundle("~/Content/recipes").Include(
                "~/Content/recipes.css"));
        }
    }
}
