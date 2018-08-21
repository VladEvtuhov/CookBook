using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Console.Models
{
    public class CommentViewModel
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public UserDTO Creator { get; set; }
    }
}
