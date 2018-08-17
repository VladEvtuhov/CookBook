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
    public class CookingMethodsRepository : IRepository<CookingMethod>
    {
        readonly MobileContext mobileContext;
        public CookingMethodsRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetCookingMethods().Count();
        }

        public void Create(CookingMethod item)
        {
            var cookingMethod = mobileContext.GetCookingMethods().FirstOrDefault(p => p.Name == item.Name);
            if (cookingMethod == null)
                mobileContext.GetCookingMethods().Add(item);
        }

        public IEnumerable<CookingMethod> Find(Func<CookingMethod, bool> predicate)
        {
            return mobileContext.GetCookingMethods().Where(predicate).ToList();
        }

        public CookingMethod FirstOrDefault(Func<CookingMethod, bool> predicate)
        {
            return mobileContext.GetCookingMethods().FirstOrDefault(predicate);
        }

        public CookingMethod Get(int id)
        {
            return mobileContext.GetCookingMethods().Find(p => p.Id == id);
        }

        public IEnumerable<CookingMethod> GetAll()
        {
            return mobileContext.GetCookingMethods();
        }

        public void Remove(int id)
        {
            var cookingMethod = mobileContext.GetCookingMethods().FirstOrDefault(p => p.Id == id);
            if (cookingMethod != null)
                mobileContext.GetCookingMethods().Remove(cookingMethod);
        }

        public void Remove(CookingMethod item)
        {
            var cookingMethod = mobileContext.GetCookingMethods().FirstOrDefault(p => p == item);
            if (cookingMethod != null)
                mobileContext.GetCookingMethods().Remove(cookingMethod);
        }

        public void Update(CookingMethod item)
        {
            var cookingMethod = mobileContext.GetCookingMethods().FirstOrDefault(p => p.Id == item.Id);
            if (cookingMethod != null)
            {
                cookingMethod.Name = item.Name;
            }
        }
    }
}
