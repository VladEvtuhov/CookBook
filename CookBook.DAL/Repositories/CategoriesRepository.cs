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
    public class CategoriesRepository : IRepository<Category>
    {
        readonly MobileContext mobileContext;
        public CategoriesRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetCategories().Count();
        }

        public void Create(Category item)
        {
            var category = mobileContext.GetCategories().FirstOrDefault(p => p.Name == item.Name);
            if (category == null)
                mobileContext.GetCategories().Add(item);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return mobileContext.GetCategories().Where(predicate).ToList();
        }

        public Category FirstOrDefault(Func<Category, bool> predicate)
        {
            return mobileContext.GetCategories().FirstOrDefault(predicate);
        }

        public Category Get(int id)
        {
            return mobileContext.GetCategories().Find(p => p.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return mobileContext.GetCategories();
        }

        public void Remove(int id)
        {
            var category = mobileContext.GetCategories().FirstOrDefault(p => p.Id == id);
            if (category != null)
                mobileContext.GetCategories().Remove(category);
        }

        public void Remove(Category item)
        {
            var category = mobileContext.GetCategories().FirstOrDefault(p => p == item);
            if (category != null)
                mobileContext.GetCategories().Remove(category);
        }

        public void Update(Category item)
        {
            var category = mobileContext.GetCategories().FirstOrDefault(p => p.Id == item.Id);
            if (category != null)
            {
                category.Name = item.Name;
            }
        }
    }
}
