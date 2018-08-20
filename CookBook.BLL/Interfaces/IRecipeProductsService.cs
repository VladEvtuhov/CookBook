using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface IRecipeProductsService
    {
        IEnumerable<string> GetProducts(int id);
        void UpdateProducts(int id, List<string> products);
    }
}
