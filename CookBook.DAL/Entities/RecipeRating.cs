namespace CookBook.DAL.Entities
{
    public class RecipeRating
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int Rating { get; set; }
    }
}
