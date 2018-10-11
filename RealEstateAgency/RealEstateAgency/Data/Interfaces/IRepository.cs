using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Interfaces
{
    interface IRepository<T> where T:class
    {
        IQueryable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        int Count(Func<T, bool> predicate);
    }
}
