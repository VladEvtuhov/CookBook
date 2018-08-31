using CookBook.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CookBook.Domain.EF
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(string connectionString)
            : base(connectionString)
        {
            if(!Database.Exists(connectionString))
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, DataContextConfiguration>());
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }
        public DbSet<RecipeProduct> RecipeProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<CookingMethod> CookingMethods { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CuisineСountry> CuisineСountries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<Category>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<CuisineСountry>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<CookingMethod>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<IngredientType>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<Recipe>().Property(e => e.Title).IsRequired();

            modelBuilder.Entity<Recipe>().Property(e => e.ShortDescription).IsRequired();

            modelBuilder.Entity<Recipe>().Property(e => e.Content).IsRequired();

            modelBuilder.Entity<Recipe>().HasRequired(e => e.Creator).WithMany(e => e.UserRecipes).HasForeignKey(e => e.CreatorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Recipe>().HasRequired(e => e.Category).WithMany(e => e.UserRecipes).HasForeignKey(e => e.CategoryId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Recipe>().HasRequired(e => e.CookingMethod).WithMany(e => e.UserRecipes).HasForeignKey(e => e.CookingMethodId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Recipe>().HasRequired(e => e.Country).WithMany(e => e.UserRecipes).HasForeignKey(e => e.CountryId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Recipe>().HasRequired(e => e.IngredientType).WithMany(e => e.UserRecipes).HasForeignKey(e => e.IngredientTypeId).WillCascadeOnDelete(true);

            modelBuilder.Entity<Comment>().Property(e => e.Content).IsRequired();

            modelBuilder.Entity<Comment>().HasRequired(e => e.Creator).WithMany(e => e.Comments).HasForeignKey(e => e.CreatorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Comment>().HasRequired(e => e.Recipe).WithMany(e => e.Comments).HasForeignKey(e => e.RecipeId).WillCascadeOnDelete(true);

            modelBuilder.Entity<RecipeProduct>().HasRequired(e => e.UserProduct).WithMany(e => e.UserRecipes).HasForeignKey(e => e.ProductId).WillCascadeOnDelete(true);

            modelBuilder.Entity<RecipeProduct>().HasRequired(e => e.UserRecipe).WithMany(e => e.Products).HasForeignKey(e => e.RecipeId).WillCascadeOnDelete(true);

            modelBuilder.Entity<RecipeRating>().HasRequired(e => e.Creator).WithMany(e => e.RecipesRatings).HasForeignKey(e => e.CreatorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<RecipeRating>().HasRequired(e => e.Recipe).WithMany(e => e.RecipesRatings).HasForeignKey(e => e.RecipeId).WillCascadeOnDelete(true);

            modelBuilder.Entity<RecipeRating>().Property(e => e.Rating).IsRequired();
        }
    }
}
