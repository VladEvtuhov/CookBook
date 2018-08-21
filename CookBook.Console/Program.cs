using System;
using Ninject;
using Ninject.Modules;
using CookBook.Console.Util;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Services;
using CookBook.Console.Controllers;
using CookBook.Console.Models;
using System.Collections.Generic;

namespace CookBook.Console
{
    class Program
    {
        private static string userEmail = null;
        private static List<string> userRoles = new List<string>();
        
        static void Main(string[] args)
        {
            Logger.InitLogger();
            var kernel = Binding();
            Menu(kernel);
        }

        public static void Menu(IKernel kernel)
        {
            int input = -1;
            while(input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("Menu\n");
                System.Console.WriteLine("1 - get recipes");
                System.Console.WriteLine("2 - get recipe");
                System.Console.WriteLine("3 - register");
                System.Console.WriteLine("4 - login");
                System.Console.WriteLine("5 - get user profile info");
                if(userEmail != null)
                    System.Console.WriteLine("6 - auth menu");
                if (userRoles.Contains("admin"))
                    System.Console.WriteLine("7 - admin menu");
                System.Console.WriteLine("0 - exit");
                int.TryParse(System.Console.ReadLine(), out input);
                switch (input)
                {
                    case 1:
                        {
                            RecipeController recipeController = new RecipeController(kernel.Get<RecipeService>());
                            var recipes = recipeController.GetAll();
                            foreach(var recipe in recipes)
                            {
                                System.Console.WriteLine(recipe.Id);
                                System.Console.WriteLine(recipe.Title);
                                System.Console.WriteLine(recipe.ShortDescription);
                                System.Console.WriteLine(recipe.AverageRating);
                                System.Console.WriteLine("--------------------------------------------------------");
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            RecipeController recipeController = new RecipeController(kernel.Get<RecipeService>());
                            System.Console.WriteLine("Enter id:");
                            int.TryParse(System.Console.ReadLine(), out int id);
                            try
                            {
                                var recipe = recipeController.Get(id);
                                System.Console.WriteLine(recipe.Creator.Email);
                                System.Console.WriteLine(recipe.CreationDate);
                                System.Console.WriteLine(recipe.Title);
                                System.Console.WriteLine(recipe.ShortDescription);
                                System.Console.WriteLine(recipe.Content);
                                System.Console.WriteLine(recipe.AverageRating);
                                System.Console.WriteLine("Comments:");
                                CommentController commentController = new CommentController(kernel.Get<CommentService>());
                                var comments = commentController.GetComments(id);
                                foreach (var comment in comments)
                                {
                                    System.Console.WriteLine("--------------------------------------------------------");
                                    System.Console.WriteLine(comment.Creator.Email);
                                    System.Console.WriteLine(comment.Content);
                                    System.Console.WriteLine(comment.CreationDate);
                                }
                                if(userRoles.Count != 0)
                                {
                                    System.Console.WriteLine("Do you want comment this recipe?(y - yes)");
                                    var answer = System.Console.ReadLine();
                                    while (answer == "y")
                                    {
                                        System.Console.WriteLine("--------------------------------------------------------");
                                        System.Console.WriteLine("Enter your comment");
                                        var comment = System.Console.ReadLine();
                                        commentController.AddComment(id, userEmail, comment);
                                        System.Console.WriteLine("Do you want comment this recipe?(y - yes)");
                                        answer = System.Console.ReadLine();
                                    }
                                    
                                }
                            }
                            catch (Exception e)
                            {
                                System.Console.WriteLine(e.Message);
                                Logger.Log.Error(e);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            UsersController usersController = new UsersController(kernel.Get<UserService>());
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter password:");
                            var password = System.Console.ReadLine();
                            RegisterViewModel register = new RegisterViewModel()
                            {
                                Email = email,
                                Password = password
                            };
                            try
                            {
                                usersController.CreateUser(register);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            UsersController usersController = new UsersController(kernel.Get<UserService>());
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter password:");
                            var password = System.Console.ReadLine();
                            try
                            {
                                if (usersController.Login(email, password))
                                {
                                    UsersRolesController usersRolesController = new UsersRolesController(kernel.Get<UserRoleService>());
                                    userEmail = email;
                                    userRoles = usersRolesController.GetUserRoles(email);
                                    System.Console.WriteLine("Login was successfull");
                                }
                                else
                                    System.Console.WriteLine("Incorrect data");
                            }catch(Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            UsersController usersController = new UsersController(kernel.Get<UserService>());
                            RecipeController recipeController = new RecipeController(kernel.Get<RecipeService>());
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                var user = usersController.Get(email);
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AverageRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.Information);
                                System.Console.WriteLine("Recipes:");
                                var recipes = recipeController.GetUserRecipes(email);
                                foreach (var recipe in recipes)
                                {
                                    System.Console.WriteLine(recipe.Id);
                                    System.Console.WriteLine(recipe.Title);
                                    System.Console.WriteLine(recipe.ShortDescription);
                                    System.Console.WriteLine(recipe.AverageRating);
                                    System.Console.WriteLine("--------------------------------------------------------");
                                }
                            }catch(Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            if(userEmail != null)
                            {
                                AuthMenu(kernel);
                            }
                            break;
                        }
                    case 7:
                        {
                            if(userRoles.Contains("admin"))
                                AdminMenu(kernel);
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
            }
        }

        public static void AuthMenu(IKernel kernel)
        {
            int input = -1;
            while (input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - set recipe rating");
                System.Console.WriteLine("2 - change profile");
                if (userRoles.Contains("writer"))
                {
                    System.Console.WriteLine("3 - set recipe");
                    System.Console.WriteLine("4 - edit recipe");
                    System.Console.WriteLine("5 - remove recipe");
                    System.Console.WriteLine("6 - set products for recipe");
                }
                System.Console.WriteLine("0 - back");
                int.TryParse(System.Console.ReadLine(), out input);
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            RatingController ratingController = new RatingController(kernel.Get<RecipeRatingService>());
                            System.Console.WriteLine("Enter recipe id:");
                            int.TryParse(System.Console.ReadLine(), out int id);
                            System.Console.WriteLine("Enter rating value(1-5):");
                            int.TryParse(System.Console.ReadLine(), out int value);
                            try
                            {
                                ratingController.SetRaiting(id, value, userEmail);
                            }catch(Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            UsersController usersController = new UsersController(kernel.Get<UserService>());
                            System.Console.WriteLine("About:");
                            var about = System.Console.ReadLine();
                            try
                            {
                                usersController.SetAbout(userEmail, about);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            if (userRoles.Contains("writer"))
                            {
                                RecipeController recipeController = new RecipeController(kernel.Get<RecipeService>());
                                System.Console.WriteLine("For whom write the recipe (email):");
                                var email = System.Console.ReadLine();
                                if (email == userEmail || userRoles.Contains("admin"))
                                {
                                    var createRecipe = CreateRecipe();
                                    createRecipe.CreatorEmail = email;
                                    try
                                    {
                                        recipeController.Create(createRecipe);
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.Log.Error(e);
                                        System.Console.WriteLine(e.Message);
                                    }
                                }else
                                    System.Console.WriteLine("Dificiency rights");
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            if (userRoles.Contains("writer"))
                            {
                                RecipeController recipeController = new RecipeController(kernel.Get<RecipeService>());
                                System.Console.WriteLine("For whom edit the recipe (email):");
                                var email = System.Console.ReadLine();
                                if (email == userEmail || userRoles.Contains("admin"))
                                {
                                    System.Console.WriteLine("Enter id:");
                                    int.TryParse(System.Console.ReadLine(), out int id);
                                    var editRecipe = CreateRecipe();
                                    editRecipe.CreatorEmail = email;
                                    try
                                    {
                                        recipeController.Update(id, editRecipe);
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.Log.Error(e);
                                        System.Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                    System.Console.WriteLine("Dificiency rights");
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 5:
                        {
                            if (userRoles.Contains("writer"))
                            {
                                RecipeController recipeController = new RecipeController(kernel.Get<RecipeService>());
                                System.Console.WriteLine("For whom remove the recipe (email):");
                                var email = System.Console.ReadLine();
                                if (email == userEmail || userRoles.Contains("admin"))
                                {
                                    System.Console.WriteLine("Enter id:");
                                    int.TryParse(System.Console.ReadLine(), out int id);
                                    try
                                    {
                                        recipeController.Remove(id);
                                    }
                                    catch (Exception e)
                                    {
                                        Logger.Log.Error(e);
                                        System.Console.WriteLine(e.Message);
                                    }
                                }
                                else
                                    System.Console.WriteLine("Dificiency rights");
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 6:
                        {
                            if (userRoles.Contains("writer"))
                            {
                                System.Console.WriteLine("For whom remove the recipe (email):");
                                var email = System.Console.ReadLine();
                                if (email == userEmail || userRoles.Contains("admin"))
                                {
                                    ProductController productController = new ProductController(kernel.Get<RecipeProductsService>());
                                    System.Console.WriteLine("Enter id:");
                                    int.TryParse(System.Console.ReadLine(), out int id);
                                    System.Console.WriteLine("Enter products through a space:");
                                    var _products = System.Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                                    List<ProductViewModel> products = new List<ProductViewModel>();
                                    foreach(var product in _products)
                                    {
                                        var productQuantity = product.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                                        var recipeProduct = new ProductViewModel() { Name = productQuantity[0], Quantity = productQuantity[1] };
                                        products.Add(recipeProduct);
                                    }
                                    productController.UpdateProducts(id, products);
                                }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void AdminMenu(IKernel kernel)
        {
            UsersRolesController usersRolesController = new UsersRolesController(kernel.Get<UserRoleService>());
            int input = -1;
            while (input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get user roles");
                System.Console.WriteLine("2 - set role");
                System.Console.WriteLine("3 - pick up a role");
                System.Console.WriteLine("4 - users menu");
                System.Console.WriteLine("5 - roles menu");
                System.Console.WriteLine("6 - info menu");
                System.Console.WriteLine("0 - back");
                int.TryParse(System.Console.ReadLine(), out input);
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            var roles = usersRolesController.GetUserRoles(email);
                            System.Console.WriteLine(email + " roles: ");
                            foreach (var role in roles)
                            {
                                System.Console.WriteLine(role);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter role:");
                            var role = System.Console.ReadLine();
                            try
                            {
                                usersRolesController.SetRole(email, role);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            System.Console.WriteLine("Enter role:");
                            var role = System.Console.ReadLine();
                            try
                            {
                                usersRolesController.PickUpRole(email, role);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            UsersMenu(kernel);
                            break;
                        }
                    case 5:
                        {
                            RolesMenu(kernel);
                            break;
                        }
                    case 6:
                        {
                            InfoMenu(kernel);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void InfoMenu(IKernel kernel)
        {
            int input = -1;
            while (input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get cooking methods");
                System.Console.WriteLine("2 - get countries");
                System.Console.WriteLine("3 - get ingredient types");
                System.Console.WriteLine("4 - get categories");
                System.Console.WriteLine("5 - set cooking methods");
                System.Console.WriteLine("6 - set countries");
                System.Console.WriteLine("7 - set ingredient types");
                System.Console.WriteLine("8 - set categories");
                System.Console.WriteLine("0 - back");
                int.TryParse(System.Console.ReadLine(), out input);
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            CookingMethodController cookingMethodController = new CookingMethodController(kernel.Get<CookingMethodService>());
                            var cookingMethods = cookingMethodController.GetAll();
                            foreach(var cookingMethod in cookingMethods)
                            {
                                System.Console.WriteLine(cookingMethod.Name);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            CountryController countryController = new CountryController(kernel.Get<CountryService>());
                            var countries = countryController.GetAll();
                            foreach (var country in countries)
                            {
                                System.Console.WriteLine(country.Name);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            IngredientTypeController ingredientTypeController = new IngredientTypeController(kernel.Get<IngredientTypeService>());
                            var ingredientTypes = ingredientTypeController.GetAll();
                            foreach (var ingredientType in ingredientTypes)
                            {
                                System.Console.WriteLine(ingredientType.Name);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            CategoryController categoryController = new CategoryController(kernel.Get<CategoryService>());
                            var categories = categoryController.GetAll();
                            foreach (var category in categories)
                            {
                                System.Console.WriteLine(category.Name);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Enter a new cooking method:");
                            var value = System.Console.ReadLine();
                            CookingMethodController cookingMethodController = new CookingMethodController(kernel.Get<CookingMethodService>());
                            try
                            {
                                cookingMethodController.SetCookingMethod(value);
                            }catch(Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("Enter a new country:");
                            var value = System.Console.ReadLine();
                            CountryController countryController = new CountryController(kernel.Get<CountryService>());
                            try
                            {
                                countryController.SetCountry(value);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 7:
                        {
                            System.Console.WriteLine("Enter a new ingredient type:");
                            var value = System.Console.ReadLine();
                            IngredientTypeController ingredientTypeController = new IngredientTypeController(kernel.Get<IngredientTypeService>());
                            try
                            {
                                ingredientTypeController.SetIngredientType(value);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 8:
                        {
                            System.Console.WriteLine("Enter a new category:");
                            var value = System.Console.ReadLine();
                            CategoryController categoryController = new CategoryController(kernel.Get<CategoryService>());
                            try
                            {
                                categoryController.SetCategory(value);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void RolesMenu(IKernel kernel)
        {
            int input = -1;
            RolesController rolesController = new RolesController(kernel.Get<RoleService>());
            while (input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get roles");
                System.Console.WriteLine("2 - add role");
                System.Console.WriteLine("3 - remove role");
                System.Console.WriteLine("0 - back");
                int.TryParse(System.Console.ReadLine(), out input);
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            var roles = rolesController.GetAll();
                            System.Console.WriteLine("Roles: ");
                            foreach (var role in roles)
                            {
                                System.Console.WriteLine(role.Name);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Enter a name of adding role:");
                            var name = System.Console.ReadLine();
                            try
                            {
                                rolesController.Add(name);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Enter a name of rempoing role:");
                            var name = System.Console.ReadLine();
                            try
                            {
                                rolesController.Remove(name);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        public static void UsersMenu(IKernel kernel)
        {
            int input = -1;
            UsersController usersController = new UsersController(kernel.Get<UserService>());
            while(input != 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("1 - get users");
                System.Console.WriteLine("2 - delete user");
                System.Console.WriteLine("3 - confirm email");
                System.Console.WriteLine("4 - get user by id");
                System.Console.WriteLine("5 - get user by email");
                System.Console.WriteLine("6 - restore user");
                System.Console.WriteLine("0 - back");
                int.TryParse(System.Console.ReadLine(), out input);
                System.Console.Clear();
                switch (input)
                {
                    case 1:
                        {
                            var users = usersController.GetAll();
                            System.Console.WriteLine("Users: ");
                            foreach (var user in users)
                            {
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AverageRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.Information);
                            }
                            System.Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("Enter a email of removing user:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                usersController.DeleteUser(email);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                usersController.ConfirmEmail(email);
                            }catch(Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            System.Console.WriteLine("Enter id:");
                            int.TryParse(System.Console.ReadLine(), out int id);
                            var user = usersController.Get(id);
                            if(user != null)
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AverageRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.Information);
                            System.Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                            System.Console.WriteLine("Enter email:");
                            var email = System.Console.ReadLine();
                            var user = usersController.Get(email);
                            if(user != null)
                                System.Console.WriteLine(user.Email + "  |  " + user.UserName + "  |  " + user.AverageRating + "  |  " + user.IsDeleted.ToString() + "  |  " + user.Information);
                            System.Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            System.Console.WriteLine("Enter a email of restoring user:");
                            var email = System.Console.ReadLine();
                            try
                            {
                                usersController.RestoreUser(email);
                            }
                            catch (Exception e)
                            {
                                Logger.Log.Error(e);
                                System.Console.WriteLine(e.Message);
                                System.Console.ReadKey();
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private static CreateRecipeViewModel CreateRecipe()
        {
            CreateRecipeViewModel createRecipe = new CreateRecipeViewModel();
            System.Console.WriteLine("Enter Title:");
            createRecipe.Title = System.Console.ReadLine();
            System.Console.WriteLine("Enter short description:");
            createRecipe.ShortDescription = System.Console.ReadLine();
            System.Console.WriteLine("Enter Content:");
            createRecipe.Content = System.Console.ReadLine();
            System.Console.WriteLine("Enter ImageUrl:");
            createRecipe.ImageUrl = System.Console.ReadLine();
            System.Console.WriteLine("Enter Category name:");
            createRecipe.Category = System.Console.ReadLine();
            System.Console.WriteLine("Enter country:");
            createRecipe.Country = System.Console.ReadLine();
            System.Console.WriteLine("Enter cooking method:");
            createRecipe.CookingMethod = System.Console.ReadLine();
            System.Console.WriteLine("Enter ingridient type:");
            createRecipe.IngredientType = System.Console.ReadLine();
            return createRecipe;
        }

        public static IKernel Binding()
        {
            NinjectModule roleModule = new BindModule();
            NinjectModule serviceModule = new ServiceModule();
            return new StandardKernel(roleModule, serviceModule);
        }
    }
}
