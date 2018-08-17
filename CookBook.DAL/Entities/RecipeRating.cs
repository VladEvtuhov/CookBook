using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CookBook.DAL.Entities
{
    public class RecipeRating
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        [XmlIgnore]
        public User Creator { get; set; }
        public int RecipeId { get; set; }
        [XmlIgnore]
        public Recipe Recipe { get; set; }
        public int Rating { get; set; }
    }
}
