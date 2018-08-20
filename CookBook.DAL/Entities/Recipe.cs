using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CookBook.DAL.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public double AvgRating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        [XmlIgnore]
        public List<RecipeRating> RecipesRatings { get; set; }
        [XmlIgnore]
        public List<Comment> Comments { get; set; }
        [XmlIgnore]
        public List<Product> Products { get; set; }
        public int CookingMethodId { get; set; }
        public CookingMethod CookingMethod { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientType IngredientType { get; set; }

        public Recipe()
        {
            RecipesRatings = new List<RecipeRating>();
            Comments = new List<Comment>();
            Products = new List<Product>();
            CreatedDate = DateTime.Now;
            AvgRating = 0;
        }
    }
}
