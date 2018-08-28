namespace CookBook.BLL.DTO
{
    public class CreateRecipeDTO
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string CreatorEmail { get; set; }
        public string Country { get; set; }
        public string CookingMethod { get; set; }
        public string IngredientType { get; set; }
    }
}
