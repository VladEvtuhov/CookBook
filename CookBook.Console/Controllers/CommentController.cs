using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Interfaces;
using CookBook.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            commentService.CreateComment(id, email, content);
        }

        public List<CommentViewModel> GetComments(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentDTO, CommentViewModel>()).CreateMapper();
            return mapper.Map<IEnumerable<CommentDTO>, List<CommentViewModel>>(commentService.GetRecipeComments(id));
        }
    }
}
