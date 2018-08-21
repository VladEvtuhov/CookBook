using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Console.Models
{
    public class UserViewModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Information { get; set; }
        public double AverageRating { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
    }
}
