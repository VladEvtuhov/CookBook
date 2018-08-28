using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System.Collections.Generic;

namespace CookBook.Console.Controllers
{
    public class CommentController
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService _commentService)
        {
            commentService = _commentService;
        }

        public void AddComment(int id, string email, string content)
        {
            commentService.CreateCommentAsync(id, email, content);
        }

        public List<CommentViewModel> GetCommentsAsync(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentService.GetRecipeComments(id));
        }
    }
}
