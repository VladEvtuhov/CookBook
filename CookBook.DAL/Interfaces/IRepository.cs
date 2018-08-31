using System;
using System.Collections.Generic;

namespace CookBook.DAL.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T FirstOrDefault(Func<T, Boolean> predicate);

        IEnumerable<T> Take(Func<T, bool> predicate, int skipCount, int takeCount);
        void Create(T item);
        void Update(T item);
        void Remove(int id);
        void Remove(T item);
        int Count();
    }
}
