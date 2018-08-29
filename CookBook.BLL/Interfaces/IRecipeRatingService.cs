using CookBook.BLL.Infrastructure;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeRatingService
    {
        Task<OperationDetails> SetRatingAsync(int id, string email, int value);
    }
}
