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
    public class CitchenCountriesRepository : IRepository<CitchenCountry>
    {
        readonly ApplicationDbContext mobileContext;
        public CitchenCountriesRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.CitchenCountries.Count();
        }

        public void Create(CitchenCountry item)
        {
            var country = mobileContext.CitchenCountries.FirstOrDefault(p => p.Name == item.Name);
            if (country == null)
                mobileContext.CitchenCountries.Add(item);
        }

        public IEnumerable<CitchenCountry> Find(Func<CitchenCountry, bool> predicate)
        {
            return mobileContext.CitchenCountries.Where(predicate).ToList();
        }

        public CitchenCountry FirstOrDefault(Func<CitchenCountry, bool> predicate)
        {
            return mobileContext.CitchenCountries.FirstOrDefault(predicate);
        }

        public CitchenCountry Get(int id)
        {
            return mobileContext.CitchenCountries.First(p => p.Id == id);
        }

        public IEnumerable<CitchenCountry> GetAll()
        {
            return mobileContext.CitchenCountries;
        }

        public void Remove(int id)
        {
            var country = mobileContext.CitchenCountries.FirstOrDefault(p => p.Id == id);
            if (country != null)
                mobileContext.CitchenCountries.Remove(country);
        }

        public void Remove(CitchenCountry item)
        {
            var country = mobileContext.CitchenCountries.FirstOrDefault(p => p == item);
            if (country != null)
                mobileContext.CitchenCountries.Remove(country);
        }

        public void Update(CitchenCountry item)
        {
            var country = mobileContext.CitchenCountries.FirstOrDefault(p => p.Id == item.Id);
            if (country != null)
            {
                country.Name = item.Name;
            }
        }
    }
}
