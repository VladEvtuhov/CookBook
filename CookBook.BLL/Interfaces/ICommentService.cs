using CookBook.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface ICommentService
    {
        Task CreateCommentAsync(int id, string email, string comment);
        List<CommentDTO> GetRecipeComments(int id);
    }
}
