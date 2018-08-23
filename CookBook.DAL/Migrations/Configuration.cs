namespace CookBook.DAL.Migrations
{
    using CookBook.DAL.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CookBook.DAL.EF.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CookBook.DAL.EF.ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            if (!context.Roles.Any(r => r.Name == "reader"))
            {
                var role = new IdentityRole { Name = "reader" };
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "writer"))
            {
                var role = new IdentityRole { Name = "writer" };
                roleManager.Create(role);
            }
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var role = new IdentityRole { Name = "admin" };
                roleManager.Create(role);
            }
            if (!context.Users.Any(u => u.Email == "nyti96@gmail.com"))
            {
                var user = new ApplicationUser()
                {
                    Email = "nyti96@gmail.com",
                    UserName = "nyti96@gmail.com"
                };
                userManager.Create(user, "Qwerty!23");
                userManager.AddToRoles(user.Id, "reader", "writer", "admin");
            }
        }
    }
}
