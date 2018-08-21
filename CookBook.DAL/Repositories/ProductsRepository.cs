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
        readonly ApplicationDbContext mobileContext;
        public ProductsRepository(ApplicationDbContext _mc)
        {
            mobileContext = _mc;
        }
        public int Count()
        {
            return mobileContext.Products.Count();
        }

        public void Create(Product item)
        {
            var product = mobileContext.Products.FirstOrDefault(p => p.Name == item.Name);
            if (product == null)
                mobileContext.Products.Add(item);
        }

        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return mobileContext.Products.Where(predicate).ToList();
        }

        public Product FirstOrDefault(Func<Product, bool> predicate)
        {
            return mobileContext.Products.FirstOrDefault(predicate);
        }

        public Product Get(int id)
        {
            return mobileContext.Products.First(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return mobileContext.Products;
        }

        public void Remove(int id)
        {
            var product = mobileContext.Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
                mobileContext.Products.Remove(product);
        }

        public void Remove(Product item)
        {
            var product = mobileContext.Products.FirstOrDefault(p => p == item);
            if (product != null)
                mobileContext.Products.Remove(product);
        }

        public void Update(Product item)
        {
            var product = mobileContext.Products.FirstOrDefault(p => p.Id == item.Id);
            if(product != null)
            {
                product.Name = item.Name;
            }
        }
    }
}
