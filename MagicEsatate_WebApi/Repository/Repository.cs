﻿using MagicEsatate_WebApi.Data;
using MagicEsatate_WebApi.Models;
using MagicEsatate_WebApi.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicEsatate_WebApi.Repository
{
    public class Repository<T>: IRepository<T> where T: class
    {
        private readonly ApplcationDbContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplcationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.Where(filter);
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }

        public async Task RemoveAsync(T entity)
        {
            dbSet.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}