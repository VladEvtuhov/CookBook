using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public class CookingMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> UserRecipes { get; set; }

        public CookingMethod()
        {
            UserRecipes = new List<Recipe>();
        }
    }
}
