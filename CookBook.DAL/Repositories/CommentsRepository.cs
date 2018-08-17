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
        readonly MobileContext mobileContext;
        public CommentsRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetComments().Count();
        }

        public void Create(Comment item)
        {
            mobileContext.GetComments().Add(item);
            item.Creator.Comments.Add(item);
            item.Recipe.Comments.Add(item);
        }

        public IEnumerable<Comment> Find(Func<Comment, bool> predicate)
        {
            return mobileContext.GetComments().Where(predicate).ToList();
        }

        public Comment FirstOrDefault(Func<Comment, bool> predicate)
        {
            return mobileContext.GetComments().FirstOrDefault(predicate);
        }

        public Comment Get(int id)
        {
            return mobileContext.GetComments().Find(p => p.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return mobileContext.GetComments();
        }

        public void Remove(int id)
        {
            var comment = mobileContext.GetComments().FirstOrDefault(p => p.Id == id);
            if (comment != null)
            {
                comment.Creator.Comments.Remove(comment);
                comment.Recipe.Comments.Remove(comment);
                mobileContext.GetComments().Remove(comment);
            }
        }

        public void Remove(Comment item)
        {
            var comment = mobileContext.GetComments().FirstOrDefault(p => p == item);
            if (comment != null)
            {
                comment.Creator.Comments.Remove(comment);
                comment.Recipe.Comments.Remove(comment);
                mobileContext.GetComments().Remove(comment);
            }
        }

        public void Update(Comment item)
        {
            var comment = mobileContext.GetComments().FirstOrDefault(p => p.Id == item.Id);
            if (comment != null)
            {
                comment.Content = item.Content;
            }
        }
    }
}
