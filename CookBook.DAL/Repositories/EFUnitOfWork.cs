using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext applicationDbContext;
        private UserRepository userRepository;
        private ProductsRepository productsRepository;
        private CategoriesRepository categoriesRepository;
        private CookingMethodsRepository cookingMethodsRepository;
        private CitchenCountriesRepository countriesRepository;
        private IngridientTypesRepository ingridientTypesRepository;
        private RecipesRepository recipesRepository;
        private RecipeProductsRepository recipeProductsRepository;
        private CommentsRepository commentsRepository;
        private RecipeRatingsRepository recipeRatingsRepository;

        public EFUnitOfWork(DbContextOptions<ApplicationDbContext> options)
        {
            applicationDbContext = new ApplicationDbContext(options);
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(applicationDbContext);
                return userRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new ProductsRepository(applicationDbContext);
                return productsRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepository(applicationDbContext);
                return categoriesRepository;
            }
        }

        public IRepository<CookingMethod> CookingMethods
        {
            get
            {
                if (cookingMethodsRepository == null)
                    cookingMethodsRepository = new CookingMethodsRepository(applicationDbContext);
                return cookingMethodsRepository;
            }
        }

        public IRepository<CitchenCountry> Countries {
            get
            {
                if (countriesRepository == null)
                    countriesRepository = new CitchenCountriesRepository(applicationDbContext);
                return countriesRepository;
            }
        }

        public IRepository<IngredientType> IngridientTypes
        {
            get
            {
                if (ingridientTypesRepository == null)
                    ingridientTypesRepository = new IngridientTypesRepository(applicationDbContext);
                return ingridientTypesRepository;
            }
        }

        public IRepository<Recipe> Recipes
        {
            get
            {
                if (recipesRepository == null)
                    recipesRepository = new RecipesRepository(applicationDbContext);
                return recipesRepository;
            }
        }

        public IRepository<RecipeProduct> RecipeProducts
        {
            get
            {
                if (recipeProductsRepository == null)
                    recipeProductsRepository = new RecipeProductsRepository(applicationDbContext);
                return recipeProductsRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentsRepository == null)
                    commentsRepository = new CommentsRepository(applicationDbContext);
                return commentsRepository;
            }
        }

        public IRepository<RecipeRating> RecipeRatings
        {
            get
            {
                if (recipeRatingsRepository == null)
                    recipeRatingsRepository = new RecipeRatingsRepository(applicationDbContext);
                return recipeRatingsRepository;
            }
        }

        public void Save()
        {
            applicationDbContext.SaveChanges();
        }
    }
}
