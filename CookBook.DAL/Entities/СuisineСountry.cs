using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public class СuisineСountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> UserRecipes { get; set; }

        public СuisineСountry()
        {
            UserRecipes = new List<Recipe>();
        }
    }
}
