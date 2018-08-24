using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DAL.Entities;

namespace CookBook.BLL.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public double AverageRating { get; set; }
        public string Information { get; set; }
        public bool IsDeleted { get; set; }
    }
}
