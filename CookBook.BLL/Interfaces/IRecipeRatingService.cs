using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeRatingService
    {
        void SetRating(int id, string email, int value);
    }
}
