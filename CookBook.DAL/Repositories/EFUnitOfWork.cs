using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Identity;
using CookBook.DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace CookBook.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private ProductsRepository productManager;
        private CategoriesRepository categoryManager;
        private CookingMethodsRepository cookingMethodManager;
        private CitchenCountriesRepository citchenCountryManager;
        private IngridientTypesRepository ingredientTypeManager;
        private RecipesRepository recipeManager;
        private RecipeProductsRepository recipeProductManager;
        private CommentsRepository commentManager;
        private RecipeRatingsRepository recipeRatingManager;

        public EFUnitOfWork(string connectionString)
        {
            applicationDbContext = new ApplicationDbContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(applicationDbContext));
            roleManager = new ApplicationRoleManager(new RoleStore<IdentityRole>(applicationDbContext));
            productManager = new ProductsRepository(applicationDbContext);
            categoryManager = new CategoriesRepository(applicationDbContext);
            cookingMethodManager = new CookingMethodsRepository(applicationDbContext);
            citchenCountryManager = new CitchenCountriesRepository(applicationDbContext);
            ingredientTypeManager = new IngridientTypesRepository(applicationDbContext);
            recipeManager = new RecipesRepository(applicationDbContext);
            recipeProductManager = new RecipeProductsRepository(applicationDbContext);
            commentManager = new CommentsRepository(applicationDbContext);
            recipeRatingManager = new RecipeRatingsRepository(applicationDbContext);
        }

        public UserManager<ApplicationUser> UserManager
        {
            get { return userManager; }
        }

        public RoleManager<IdentityRole> RoleManager
        {
            get { return roleManager; }
        }

        public IRepository<Product> ProductManager
        {
            get { return productManager; }
        }

        public IRepository<Category> CategoryManager
        {
            get { return categoryManager; }
        }

        public IRepository<CookingMethod> CookingMethodManager
        {
            get { return cookingMethodManager; }
        }

        public IRepository<CitchenCountry> CitchenCountryManager
        {
            get { return citchenCountryManager; }
        }

        public IRepository<IngredientType> IngridientTypeManager
        {
            get { return ingredientTypeManager; }
        }
        public IRepository<Recipe> RecipeManager
        {
            get { return recipeManager; }
        }

        public IRepository<RecipeProduct> RecipeProductManager
        {
            get { return recipeProductManager; }
        }

        public IRepository<Comment> CommentManager
        {
            get { return commentManager; }
        }
        public IRepository<RecipeRating> RecipeRatingManager
        {
            get { return recipeRatingManager; }
        }

        public void Save()
        {
            applicationDbContext.SaveChanges();
        }
    }
}
