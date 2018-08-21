using CookBook.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CookBook.DAL.EF
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeRating> RecipeRatings { get; set; }
        public DbSet<RecipeProduct> RecipeProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
        public DbSet<CookingMethod> CookingMethods { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CitchenCountry> CitchenCountries { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Cascade;
            }
            base.OnModelCreating(builder);

            builder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();
            });

            builder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();
            });

            builder.Entity<CitchenCountry>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();
            });

            builder.Entity<CookingMethod>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();
            });

            builder.Entity<IngredientType>(entity =>
            {
                entity.Property(e => e.Name)
                .IsRequired();
            });

            builder.Entity<Recipe>(entity =>
            {
                entity.Property(e => e.Title)
                .IsRequired();

                entity.Property(e => e.ShortDescription)
                .IsRequired();

                entity.Property(e => e.Content)
                .IsRequired();

                entity.HasOne(e => e.Creator)
                .WithMany(e => e.UserRecipes)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Category)
                .WithMany(e => e.UserRecipes)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.CookingMethod)
                .WithMany(e => e.UserRecipes)
                .HasForeignKey(e => e.CookingMethodId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Country)
                .WithMany(e => e.UserRecipes)
                .HasForeignKey(e => e.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.IngredientType)
                .WithMany(e => e.UserRecipes)
                .HasForeignKey(e => e.IngredientTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            builder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Content)
                .IsRequired();

                entity.HasOne(e => e.Creator)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Comments)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<RecipeProduct>(entity =>
            {
                entity.HasOne(e => e.UserProduct)
                .WithMany(e => e.UserRecipes)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.UserRecipe)
                .WithMany(e => e.Products)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            });

            builder.Entity<RecipeRating>(entity =>
            {
                entity.HasOne(e => e.Creator)
                .WithMany(e => e.RecipesRatings)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Recipe)
                .WithMany(e => e.RecipesRatings)
                .HasForeignKey(e => e.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(e => e.Rating)
                .IsRequired();
            }); 
        }
    }
}
