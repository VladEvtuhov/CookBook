using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Interfaces;
using CookBook.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBook.BLL.Services
{
    public class CommentService : ICommentService
    {
        IUnitOfWork database;
        public CommentService(IUnitOfWork _database)
        {
            database = _database;
        }

        public async Task<OperationDetails> CreateCommentAsync(int id, string email, string message)
        {
            var recipe = database.RecipeManager.FirstOrDefault(r => r.Id == id);
            var user = await database.UserManager.FindByEmailAsync(email);
            if (recipe == null || user == null)
                return new OperationDetails(false, "User or recipe not found", "");
            Comment comment = new Comment()
            {
                CreatorId = user.Id,
                Creator = user,
                RecipeId = recipe.Id,
                Recipe = recipe,
                Content = message
            };
            database.CommentManager.Create(comment);
            database.Save();
            return new OperationDetails(true, "Comment created successfully", "");
        }

        public List<CommentDTO> GetRecipeComments(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            var comments = mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(database.CommentManager.Find(p => p.RecipeId == id));
            return comments;
        }
    }
}
