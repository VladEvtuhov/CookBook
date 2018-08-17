using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.DTO
{
    public class RecipeInfoDTO
    {
        public string Headline { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public double AvgRating { get; set; }
        public string CreatedDate { get; set; }
        public User Creator { get; set; }
    }
}
