using CookBook.DAL.EF;
using CookBook.DAL.Entities;
using CookBook.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return mobileContext.Comments.Where(predicate).ToList();
        }

        public Comment FirstOrDefault(Func<Comment, bool> predicate)
        {
            return mobileContext.Comments.FirstOrDefault(predicate);
        }

        public Comment Get(int id)
        {
            return mobileContext.Comments.First(p => p.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return mobileContext.Comments;
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
    }
}
