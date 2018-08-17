using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Console.Models
{
    public class RecipeViewModel
    {
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public double AvgRating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ImageUrl { get; set; }
        public UserDTO Creator { get; set; }
    }
}
