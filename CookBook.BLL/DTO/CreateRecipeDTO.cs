using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.DTO
{
    public class CreateRecipeDTO
    {
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string CreatorEmail { get; set; }
        public string Country { get; set; }
        public string CookingMethod { get; set; }
        public string IngredientType { get; set; }
    }
}
