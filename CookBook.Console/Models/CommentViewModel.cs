using CookBook.BLL.DTO;
using System;

namespace CookBook.Console.Models
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public UserDTO Creator { get; set; }
    }
}
