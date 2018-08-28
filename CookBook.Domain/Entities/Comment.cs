using System;

namespace CookBook.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public Comment()
        {
            CreationDate = DateTime.Now;
        }
    }
}
