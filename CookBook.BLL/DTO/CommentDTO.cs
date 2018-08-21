using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.DTO
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public UserDTO Creator { get; set; }
    }
}
