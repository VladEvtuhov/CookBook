using System.Collections.Generic;

namespace CookBook.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Recipe> UserRecipes { get; set; }

        public Category()
        {
            UserRecipes = new List<Recipe>();
        }
    }
}
