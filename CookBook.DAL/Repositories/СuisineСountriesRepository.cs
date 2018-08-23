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
    public class СuisineСountriesRepository : IRepository<СuisineСountry>
    {
        readonly ApplicationDbContext mobileContext;
        public СuisineСountriesRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.СuisineСountries.Count();
        }

        public void Create(СuisineСountry item)
        {
            var country = mobileContext.СuisineСountries.FirstOrDefault(p => p.Name == item.Name);
            if (country == null)
                mobileContext.СuisineСountries.Add(item);
        }

        public IEnumerable<СuisineСountry> Find(Func<СuisineСountry, bool> predicate)
        {
            return mobileContext.СuisineСountries.Where(predicate).ToList();
        }

        public СuisineСountry FirstOrDefault(Func<СuisineСountry, bool> predicate)
        {
            return mobileContext.СuisineСountries.FirstOrDefault(predicate);
        }

        public СuisineСountry Get(int id)
        {
            return mobileContext.СuisineСountries.First(p => p.Id == id);
        }

        public IEnumerable<СuisineСountry> GetAll()
        {
            return mobileContext.СuisineСountries;
        }

        public void Remove(int id)
        {
            var country = mobileContext.СuisineСountries.FirstOrDefault(p => p.Id == id);
            if (country != null)
                mobileContext.СuisineСountries.Remove(country);
        }

        public void Remove(СuisineСountry item)
        {
            var country = mobileContext.СuisineСountries.FirstOrDefault(p => p == item);
            if (country != null)
                mobileContext.СuisineСountries.Remove(country);
        }

        public void Update(СuisineСountry item)
        {
            var country = mobileContext.СuisineСountries.FirstOrDefault(p => p.Id == item.Id);
            if (country != null)
            {
                country.Name = item.Name;
            }
        }
    }
}
