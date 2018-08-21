using System.Collections.Generic;

namespace CookBook.DAL.Entities
{
    public class IngredientType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> UserRecipes { get; set; }

        public IngredientType()
        {
            UserRecipes = new List<Recipe>();
        }
    }
}
