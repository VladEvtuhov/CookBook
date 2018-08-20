using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly MobileContext mobileContext;
        private RoleRepository roleRepository;
        private UserRepository userRepository;
        private UserRolesRepository userRolesRepository;
        private ProductsRepository productsRepository;
        private CategoriesRepository categoriesRepository;
        private CookingMethodsRepository cookingMethodsRepository;
        private CountriesRepository countriesRepository;
        private IngridientTypesRepository ingridientTypesRepository;
        private RecipesRepository recipesRepository;
        private RecipeProductsRepository recipeProductsRepository;
        private CommentsRepository commentsRepository;
        private RecipeRatingsRepository recipeRatingsRepository;

        public EFUnitOfWork()
        {
            mobileContext = new MobileContext();
        }
        public IRepository<Role> Roles {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(mobileContext);
                return roleRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(mobileContext);
                return userRepository;
            }
        }

        public IRepository<UserRoles> UsersRoles
        {
            get
            {
                if (userRolesRepository == null)
                    userRolesRepository = new UserRolesRepository(mobileContext);
                return userRolesRepository;
            }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productsRepository == null)
                    productsRepository = new ProductsRepository(mobileContext);
                return productsRepository;
            }
        }

        public IRepository<Category> Categories
        {
            get
            {
                if (categoriesRepository == null)
                    categoriesRepository = new CategoriesRepository(mobileContext);
                return categoriesRepository;
            }
        }

        public IRepository<CookingMethod> CookingMethods
        {
            get
            {
                if (cookingMethodsRepository == null)
                    cookingMethodsRepository = new CookingMethodsRepository(mobileContext);
                return cookingMethodsRepository;
            }
        }

        public IRepository<Country> Countries {
            get
            {
                if (countriesRepository == null)
                    countriesRepository = new CountriesRepository(mobileContext);
                return countriesRepository;
            }
        }

        public IRepository<IngredientType> IngridientTypes
        {
            get
            {
                if (ingridientTypesRepository == null)
                    ingridientTypesRepository = new IngridientTypesRepository(mobileContext);
                return ingridientTypesRepository;
            }
        }

        public IRepository<Recipe> Recipes
        {
            get
            {
                if (recipesRepository == null)
                    recipesRepository = new RecipesRepository(mobileContext);
                return recipesRepository;
            }
        }

        public IRepository<RecipeProduct> RecipeProducts
        {
            get
            {
                if (recipeProductsRepository == null)
                    recipeProductsRepository = new RecipeProductsRepository(mobileContext);
                return recipeProductsRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (commentsRepository == null)
                    commentsRepository = new CommentsRepository(mobileContext);
                return commentsRepository;
            }
        }

        public IRepository<RecipeRating> RecipeRatings
        {
            get
            {
                if (recipeRatingsRepository == null)
                    recipeRatingsRepository = new RecipeRatingsRepository(mobileContext);
                return recipeRatingsRepository;
            }
        }

        public void Save()
        {
            if(roleRepository != null)
                GenericSerializer.Serialize(roleRepository.GetAll());
            if (userRepository != null)
                GenericSerializer.Serialize(userRepository.GetAll());
            if (userRolesRepository != null)
                GenericSerializer.Serialize(userRolesRepository.GetAll());
            if (productsRepository != null)
                GenericSerializer.Serialize(productsRepository.GetAll());
            if (categoriesRepository != null)
                GenericSerializer.Serialize(categoriesRepository.GetAll());
            if (cookingMethodsRepository != null)
                GenericSerializer.Serialize(cookingMethodsRepository.GetAll());
            if (countriesRepository != null)
                GenericSerializer.Serialize(countriesRepository.GetAll());
            if (ingridientTypesRepository != null)
                GenericSerializer.Serialize(ingridientTypesRepository.GetAll());
            if (recipesRepository != null)
                GenericSerializer.Serialize(recipesRepository.GetAll());
            if (recipeProductsRepository != null)
                GenericSerializer.Serialize(recipeProductsRepository.GetAll());
            if (commentsRepository != null)
                GenericSerializer.Serialize(commentsRepository.GetAll());
            if (recipeRatingsRepository != null)
                GenericSerializer.Serialize(recipeRatingsRepository.GetAll());
        }
    }
}
