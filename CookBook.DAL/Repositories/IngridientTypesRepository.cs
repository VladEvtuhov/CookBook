using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class IngridientTypesRepository : IRepository<IngredientType>
    {
        readonly ApplicationDbContext mobileContext;
        public IngridientTypesRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.IngredientTypes.Count();
        }

        public void Create(IngredientType item)
        {
            var ingridientType = mobileContext.IngredientTypes.FirstOrDefault(p => p.Name == item.Name);
            if (ingridientType == null)
                mobileContext.IngredientTypes.Add(item);
        }

        public IEnumerable<IngredientType> Find(Func<IngredientType, bool> predicate)
        {
            return mobileContext.IngredientTypes.Where(predicate).ToList();
        }

        public IngredientType FirstOrDefault(Func<IngredientType, bool> predicate)
        {
            return mobileContext.IngredientTypes.FirstOrDefault(predicate);
        }

        public IngredientType Get(int id)
        {
            return mobileContext.IngredientTypes.First(p => p.Id == id);
        }

        public IEnumerable<IngredientType> GetAll()
        {
            return mobileContext.IngredientTypes;
        }

        public void Remove(int id)
        {
            var ingridientType = mobileContext.IngredientTypes.FirstOrDefault(p => p.Id == id);
            if (ingridientType != null)
                mobileContext.IngredientTypes.Remove(ingridientType);
        }

        public void Remove(IngredientType item)
        {
            var ingridientType = mobileContext.IngredientTypes.FirstOrDefault(p => p == item);
            if (ingridientType != null)
                mobileContext.IngredientTypes.Remove(ingridientType);
        }

        public void Update(IngredientType item)
        {
            var ingridientType = mobileContext.IngredientTypes.FirstOrDefault(p => p.Id == item.Id);
            if (ingridientType != null)
            {
                ingridientType.Name = item.Name;
            }
        }
    }
}
