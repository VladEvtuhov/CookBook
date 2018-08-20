using AutoMapper;
using CookBook.BLL.DTO;
using CookBook.BLL.Infrastructure;
using CookBook.BLL.Interfaces;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BLL.Services
{
    public class CommentService : ICommentService
    {
        IUnitOfWork database;
        public CommentService(IUnitOfWork _database)
        {
            database = _database;
        }

        public void CreateComment(int id, string email, string message)
        {
            var recipe = database.Recipes.FirstOrDefault(r => r.Id == id);
            var user = database.Users.FirstOrDefault(u => u.Email == email);
            if (recipe == null || user == null)
                throw new ValidationException("Unknown information", "");
            Comment comment = new Comment()
            {
                Id = database.Comments.Count() == 0 ? 1 : database.Comments.GetAll().OrderBy(o => o.Id).Last().Id + 1,
                CreatorId = user.Id,
                Creator = user,
                RecipeId = recipe.Id,
                Recipe = recipe,
                Content = message
            };
            database.Comments.Create(comment);
            database.Save();
        }

        public List<CommentDTO> GetRecipeComments(int id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Comment, CommentDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Comment>, List<CommentDTO>>(database.Recipes.Get(id).Comments);
        }
    }
}
