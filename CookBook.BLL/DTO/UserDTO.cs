using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.DTO
{
    public class UserDTO
    {
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        public string UserName { get; set; }
        public double AvgRating { get; set; }
        public string About { get; set; }
        public bool IsDeleted { get; set; }
    }
}
