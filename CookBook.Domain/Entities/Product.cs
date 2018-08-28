using System.Collections.Generic;

namespace CookBook.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<RecipeProduct> UserRecipes { get; set; }

        public Product()
        {
            UserRecipes = new List<RecipeProduct>();
        }
    }
}
