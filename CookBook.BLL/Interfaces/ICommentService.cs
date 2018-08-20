using CookBook.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface ICommentService
    {
        void CreateComment(int id, string email, string comment);
        List<CommentDTO> GetRecipeComments(int id);
    }
}
