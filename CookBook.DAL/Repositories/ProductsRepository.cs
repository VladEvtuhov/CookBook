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
    public class ProductsRepository : IRepository<Product>
    {
        readonly MobileContext mobileContext;
        public ProductsRepository(MobileContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.GetProducts().Count();
        }

        public void Create(Product item)
        {
            var product = mobileContext.GetProducts().FirstOrDefault(p => p.Name == item.Name);
            if (product == null)
                mobileContext.GetProducts().Add(item);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return mobileContext.GetProducts().Where(predicate).ToList();
        }

        public Product FirstOrDefault(Func<Product, bool> predicate)
        {
            return mobileContext.GetProducts().FirstOrDefault(predicate);
        }

        public Product Get(int id)
        {
            return mobileContext.GetProducts().Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return mobileContext.GetProducts();
        }

        public void Remove(int id)
        {
            var product = mobileContext.GetProducts().FirstOrDefault(p => p.Id == id);
            if (product != null)
                mobileContext.GetProducts().Remove(product);
        }

        public void Remove(Product item)
        {
            var product = mobileContext.GetProducts().FirstOrDefault(p => p == item);
            if (product != null)
                mobileContext.GetProducts().Remove(product);
        }

        public void Update(Product item)
        {
            var product = mobileContext.GetProducts().FirstOrDefault(p => p.Id == item.Id);
            if(product != null)
            {
                product.Name = item.Name;
            }
        }
    }
}
