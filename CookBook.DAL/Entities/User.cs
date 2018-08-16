using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CookBook.DAL.Entities
{
    [XmlRoot(ElementName = "embellishments", IsNullable = false)]
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsDeleted { get; set; }
        public string ImageUrl { get; set; }
        [XmlIgnore]
        public ICollection<Recipes> UserRecipes { get; set; }
        [XmlIgnore]
        public ICollection<Comment> Comments { get; set; }
        [XmlIgnore]
        public ICollection<RecipeRating> RecipesRatings { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public double AvgRating { get; set; }
        public string About { get; set; }

        public User()
        {
            EmailConfirmed = false;
            IsDeleted = false;
            UserRecipes = new List<Recipes>();
            Comments = new List<Comment>();
            RecipesRatings = new List<RecipeRating>();
            AvgRating = 0;
        }
    }
}
