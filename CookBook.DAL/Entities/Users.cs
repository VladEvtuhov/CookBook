using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Entities
{
    public class Users
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Recipes> UserRecipes { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<RecipeRating> RecipesRatings { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public double AvfRating { get; set; }
        public string About { get; set; }

    }
}
