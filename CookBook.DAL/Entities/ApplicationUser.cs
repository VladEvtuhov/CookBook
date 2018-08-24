using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace CookBook.DAL.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        [XmlIgnore]
        public List<Recipe> UserRecipes { get; set; }
        [XmlIgnore]
        public List<Comment> Comments { get; set; }
        [XmlIgnore]
        public List<RecipeRating> RecipesRatings { get; set; }
        [XmlIgnore]
        public double AverageRating { get; set; }
        public string Information { get; set; }

        public ApplicationUser()
        {
            IsDeleted = false;
            UserRecipes = new List<Recipe>();
            Comments = new List<Comment>();
            RecipesRatings = new List<RecipeRating>();
            AverageRating = 0;
        }
    }
}
