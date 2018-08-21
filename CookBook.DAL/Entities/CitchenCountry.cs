using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public class CitchenCountry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> UserRecipes { get; set; }

        public CitchenCountry()
        {
            UserRecipes = new List<Recipe>();
        }
    }
}
