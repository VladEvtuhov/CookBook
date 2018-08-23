using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CookBook.DAL.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public double AverageRating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ImageUrl { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        [XmlIgnore]
        public List<RecipeRating> RecipesRatings { get; set; }
        [XmlIgnore]
        public List<Comment> Comments { get; set; }
        [XmlIgnore]
        public List<RecipeProduct> Products { get; set; }
        public int CookingMethodId { get; set; }
        public CookingMethod CookingMethod { get; set; }
        public int CountryId { get; set; }
        public СuisineСountry Country { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientType IngredientType { get; set; }

        public Recipe()
        {
            RecipesRatings = new List<RecipeRating>();
            Comments = new List<Comment>();
            Products = new List<RecipeProduct>();
            CreationDate = DateTime.Now;
            UpdateDate = DateTime.Now;
            AverageRating = 0;
        }
    }
}
