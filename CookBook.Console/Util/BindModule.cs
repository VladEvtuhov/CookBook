using Ninject.Modules;
using CookBook.BLL.Interfaces;
using CookBook.BLL.Services;

namespace CookBook.Console.Util
{
    public class BindModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            Bind<IUserRoleService>().To<UserRoleService>();
            Bind<IRecipeService>().To<RecipeService>();
            Bind<ICategoryService>().To<CategoryService>();
            Bind<ICommentService>().To<CommentService>();
            Bind<ICookingMethodService>().To<CookingMethodService>();
            Bind<ICuisineСountryService>().To<CuisineСountryService>();
            Bind<IIngredientTypeService>().To<IngredientTypeService>();
            Bind<IProductService>().To<ProductService>();
            Bind<IRecipeProductsService>().To<RecipeProductsService>();
            Bind<IRecipeRatingService>().To<RecipeRatingService>();
        }
    }
}
