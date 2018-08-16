using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DAL.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public User Creator { get; set; }
        public int RecipeId { get; set; }
        public Recipes Recipe { get; set; }
        public string Content { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
