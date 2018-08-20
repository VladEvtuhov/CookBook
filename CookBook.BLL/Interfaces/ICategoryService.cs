using CookBook.BLL.DTO;
using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> GetAll();
        void SetCategory(string name);
    }
}
