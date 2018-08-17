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
    public class CountriesRepository : IRepository<Country>
    {
        readonly MobileContext mobileContext;
        public CountriesRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetCountries().Count();
        }

        public void Create(Country item)
        {
            var country = mobileContext.GetCountries().FirstOrDefault(p => p.Name == item.Name);
            if (country == null)
                mobileContext.GetCountries().Add(item);
        }

        public IEnumerable<Country> Find(Func<Country, bool> predicate)
        {
            return mobileContext.GetCountries().Where(predicate).ToList();
        }

        public Country FirstOrDefault(Func<Country, bool> predicate)
        {
            return mobileContext.GetCountries().FirstOrDefault(predicate);
        }

        public Country Get(int id)
        {
            return mobileContext.GetCountries().Find(p => p.Id == id);
        }

        public IEnumerable<Country> GetAll()
        {
            return mobileContext.GetCountries();
        }

        public void Remove(int id)
        {
            if (mobileContext.GetRecipes().FirstOrDefault(c => c.CountryId == id) == null)
            {
                var country = mobileContext.GetCountries().FirstOrDefault(p => p.Id == id);
                if (country != null)
                    mobileContext.GetCountries().Remove(country);
            }
        }

        public void Remove(Country item)
        {
            if (mobileContext.GetRecipes().FirstOrDefault(c => c.CountryId == item.Id) == null)
            {
                var country = mobileContext.GetCountries().FirstOrDefault(p => p == item);
                if (country != null)
                    mobileContext.GetCountries().Remove(country);
            }
        }

        public void Update(Country item)
        {
            var country = mobileContext.GetCountries().FirstOrDefault(p => p.Id == item.Id);
            if (country != null)
            {
                country.Name = item.Name;
            }
        }
    }
}
