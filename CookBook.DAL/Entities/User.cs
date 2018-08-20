using System.Collections.Generic;
using System.Xml.Serialization;

namespace CookBook.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        [XmlIgnore]
        public List<Recipe> UserRecipes { get; set; }
        [XmlIgnore]
        public List<Comment> Comments { get; set; }
        [XmlIgnore]
        public List<RecipeRating> RecipesRatings { get; set; }
        [XmlIgnore]
        public List<Role> Roles { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public double AvgRating { get; set; }
        public string About { get; set; }

        public User()
        {
            EmailConfirmed = false;
            IsDeleted = false;
            UserRecipes = new List<Recipe>();
            Comments = new List<Comment>();
            RecipesRatings = new List<RecipeRating>();
            Roles = new List<Role>();
            AvgRating = 0;
        }
    }
}
