using CookBook.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.DTO
{
    public class RecipesInfoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public double AverageRating { get; set; }
        public string CreationDate { get; set; }
        public User Creator { get; set; }
    }
}
