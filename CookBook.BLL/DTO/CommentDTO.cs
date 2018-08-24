using System;

namespace CookBook.BLL.DTO
{
    public class CommentDTO
    {
        public string CreatorId { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public UserDTO Creator { get; set; }
    }
}
