using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Entities
{
    public class Recipes
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public double AvgRating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public List<RecipeRating> RecipesRatings { get; set; }
        public List<Comment> Comments { get; set; }
        public int CookingMethodId { get; set; }
        public CookingMethod CookingMethod { get; set; }
        public int CountryId { get; set; }
        public Countries Country { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientTypes IngredientType { get; set; }
    }
}
