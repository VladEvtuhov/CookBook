using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class CookingMethodsRepository : IRepository<CookingMethod>
    {
        readonly ApplicationDbContext mobileContext;
        public CookingMethodsRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.CookingMethods.Count();
        }

        public void Create(CookingMethod item)
        {
            var cookingMethod = mobileContext.CookingMethods.FirstOrDefault(p => p.Name == item.Name);
            if (cookingMethod == null)
                mobileContext.CookingMethods.Add(item);
        }

        public IEnumerable<CookingMethod> Take(Func<CookingMethod, bool> predicate, int skipCount, int takeCount)
        {
            return mobileContext.CookingMethods.Where(predicate).OrderBy(s => s.Id).Skip(skipCount).Take(takeCount);
        }

        public IEnumerable<CookingMethod> Find(Func<CookingMethod, bool> predicate)
        {
            return mobileContext.CookingMethods.Where(predicate).ToList();
        }

        public CookingMethod FirstOrDefault(Func<CookingMethod, bool> predicate)
        {
            return mobileContext.CookingMethods.FirstOrDefault(predicate);
        }

        public CookingMethod Get(int id)
        {
            return mobileContext.CookingMethods.First(p => p.Id == id);
        }

        public IEnumerable<CookingMethod> GetAll()
        {
            return mobileContext.CookingMethods;
        }

        public void Remove(int id)
        {
            var cookingMethod = mobileContext.CookingMethods.FirstOrDefault(p => p.Id == id);
            if (cookingMethod != null)
                mobileContext.CookingMethods.Remove(cookingMethod);
        }

        public void Remove(CookingMethod item)
        {
            var cookingMethod = mobileContext.CookingMethods.FirstOrDefault(p => p == item);
            if (cookingMethod != null)
                mobileContext.CookingMethods.Remove(cookingMethod);
        }

        public void Update(CookingMethod item)
        {
            var cookingMethod = mobileContext.CookingMethods.FirstOrDefault(p => p.Id == item.Id);
            if (cookingMethod != null)
            {
                cookingMethod.Name = item.Name;
            }
        }
    }
}
