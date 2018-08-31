using System.Collections.Generic;

namespace CookBook.Domain.Entities
{
    public class CuisineСountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> UserRecipes { get; set; }

        public CuisineСountry()
        {
            UserRecipes = new List<Recipe>();
        }
    }
}
