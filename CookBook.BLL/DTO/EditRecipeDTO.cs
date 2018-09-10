using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.DTO
{
    public class EditRecipeDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string CuisineCountry { get; set; }
        public string CookingMethod { get; set; }
        public string IngredientType { get; set; }
    }
}
