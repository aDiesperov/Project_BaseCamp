﻿using RealEstateAgency.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAgency.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T:class
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context) => _context = context;
        public int Count(Func<T, bool> predicate) => _context.Set<T>().Count(predicate);

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await SaveAsync();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate) => _context.Set<T>().Where(predicate);

        public IQueryable<T> GetAll() => _context.Set<T>();

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await SaveAsync();
        }

        private async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
