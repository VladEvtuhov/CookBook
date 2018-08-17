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
    public class IngridientTypesRepository : IRepository<IngredientType>
    {
        readonly MobileContext mobileContext;
        public IngridientTypesRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetIngredientTypes().Count();
        }

        public void Create(IngredientType item)
        {
            var ingridientType = mobileContext.GetIngredientTypes().FirstOrDefault(p => p.Name == item.Name);
            if (ingridientType == null)
                mobileContext.GetIngredientTypes().Add(item);
        }

        public IEnumerable<IngredientType> Find(Func<IngredientType, bool> predicate)
        {
            return mobileContext.GetIngredientTypes().Where(predicate).ToList();
        }

        public IngredientType FirstOrDefault(Func<IngredientType, bool> predicate)
        {
            return mobileContext.GetIngredientTypes().FirstOrDefault(predicate);
        }

        public IngredientType Get(int id)
        {
            return mobileContext.GetIngredientTypes().Find(p => p.Id == id);
        }

        public IEnumerable<IngredientType> GetAll()
        {
            return mobileContext.GetIngredientTypes();
        }

        public void Remove(int id)
        {
            if (mobileContext.GetRecipes().FirstOrDefault(r => r.IngredientTypeId == id) == null)
            {
                var ingridientType = mobileContext.GetIngredientTypes().FirstOrDefault(p => p.Id == id);
                if (ingridientType != null)
                    mobileContext.GetIngredientTypes().Remove(ingridientType);
            }
        }

        public void Remove(IngredientType item)
        {
            if (mobileContext.GetRecipes().FirstOrDefault(r => r.IngredientTypeId == item.Id) == null)
            {
                var ingridientType = mobileContext.GetIngredientTypes().FirstOrDefault(p => p == item);
                if (ingridientType != null)
                    mobileContext.GetIngredientTypes().Remove(ingridientType);
            }
        }

        public void Update(IngredientType item)
        {
            var ingridientType = mobileContext.GetIngredientTypes().FirstOrDefault(p => p.Id == item.Id);
            if (ingridientType != null)
            {
                ingridientType.Name = item.Name;
            }
        }
    }
}
