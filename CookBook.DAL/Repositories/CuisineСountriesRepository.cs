using CookBook.DAL.Interfaces;
using CookBook.Domain.EF;
using CookBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.DAL.Repositories
{
    public class CuisineСountriesRepository : IRepository<CuisineСountry>
    {
        readonly ApplicationDbContext mobileContext;
        public CuisineСountriesRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.CuisineСountries.Count();
        }

        public void Create(CuisineСountry item)
        {
            var country = mobileContext.CuisineСountries.FirstOrDefault(p => p.Name == item.Name);
            if (country == null)
                mobileContext.CuisineСountries.Add(item);
        }

        public IEnumerable<CuisineСountry> Find(Func<CuisineСountry, bool> predicate)
        {
            return mobileContext.CuisineСountries.Where(predicate).ToList();
        }

        public CuisineСountry FirstOrDefault(Func<CuisineСountry, bool> predicate)
        {
            return mobileContext.CuisineСountries.FirstOrDefault(predicate);
        }

        public IEnumerable<CuisineСountry> Take(Func<CuisineСountry, bool> predicate, int skipCount, int takeCount)
        {
            return mobileContext.CuisineСountries.Where(predicate).OrderBy(s => s.Id).Skip(skipCount).Take(takeCount);
        }

        public CuisineСountry Get(int id)
        {
            return mobileContext.CuisineСountries.First(p => p.Id == id);
        }

        public IEnumerable<CuisineСountry> GetAll()
        {
            return mobileContext.CuisineСountries;
        }

        public void Remove(int id)
        {
            var country = mobileContext.CuisineСountries.FirstOrDefault(p => p.Id == id);
            if (country != null)
                mobileContext.CuisineСountries.Remove(country);
        }

        public void Remove(CuisineСountry item)
        {
            var country = mobileContext.CuisineСountries.FirstOrDefault(p => p == item);
            if (country != null)
                mobileContext.CuisineСountries.Remove(country);
        }

        public void Update(CuisineСountry item)
        {
            var country = mobileContext.CuisineСountries.FirstOrDefault(p => p.Id == item.Id);
            if (country != null)
            {
                country.Name = item.Name;
            }
        }
    }
}
