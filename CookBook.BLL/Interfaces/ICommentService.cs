using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Interfaces
{
    public interface ICommentService
    {
        Task<OperationDetails> CreateCommentAsync(int id, string email, string comment);
        List<CommentDTO> GetRecipeComments(int id);
    }
}
