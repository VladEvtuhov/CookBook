namespace CookBook.Domain.Entities
{
    public class RecipeProduct
    {
        public int Id { get; set; }
        public Recipe UserRecipe { get; set; }
        public int RecipeId { get; set; }
        public Product UserProduct { get; set; }
        public int ProductId { get; set; }
        public string Quantity { get; set; }
    }
}
