using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class CommentsRepository : IRepository<Comment>
    {
        readonly ApplicationDbContext mobileContext;
        public CommentsRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.Comments.Count();
        }

        public void Create(Comment item)
        {
            mobileContext.Comments.Add(item);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            var comments = mobileContext.Comments.Where(predicate).ToList();
            foreach(var comment in comments)
            {
                SetCommentRelationship(comment);
            }
            return comments;
        }

        public IEnumerable<Comment> Take(Func<Comment, bool> predicate, int skipCount, int takeCount)
        {
            return mobileContext.Comments.Where(predicate).OrderBy(s => s.Id).Skip(skipCount).Take(takeCount);
        }
        public Comment FirstOrDefault(Func<Comment, bool> predicate)
        {
            var comment = mobileContext.Comments.FirstOrDefault(predicate);
            SetCommentRelationship(comment);
            return comment;
        }

        public Comment Get(int id)
        {
            var comment = mobileContext.Comments.First(p => p.Id == id);
            SetCommentRelationship(comment);
            return comment;
        }

        public IEnumerable<Comment> GetAll()
        {
            var comments = mobileContext.Comments;
            foreach (var comment in comments)
            {
                SetCommentRelationship(comment);
            }
            return comments;
        }

        public void Remove(int id)
        {
            var comment = mobileContext.Comments.FirstOrDefault(p => p.Id == id);
            if (comment != null)
            {
                mobileContext.Comments.Remove(comment);
            }
        }

        public void Remove(Comment item)
        {
            var comment = mobileContext.Comments.FirstOrDefault(p => p == item);
            if (comment != null)
            {
                mobileContext.Comments.Remove(comment);
            }
        }

        public void Update(Comment item)
        {
            var comment = mobileContext.Comments.FirstOrDefault(p => p.Id == item.Id);
            if (comment != null)
            {
                comment.Content = item.Content;
            }
        }

        private Comment SetCommentRelationship(Comment comment)
        {
            comment.Creator = mobileContext.Users.First(p => p.Id == comment.CreatorId);
            comment.Recipe = mobileContext.Recipes.First(p => p.Id == comment.RecipeId);
            return comment;
        }
    }
}
