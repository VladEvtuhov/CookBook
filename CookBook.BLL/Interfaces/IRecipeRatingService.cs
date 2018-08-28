using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeRatingService
    {
        Task SetRatingAsync(int id, string email, int value);
    }
}
