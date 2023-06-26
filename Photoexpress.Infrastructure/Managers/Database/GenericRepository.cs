﻿using Microsoft.EntityFrameworkCore;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Domain.Entities.Base;
using Photoexpress.Domain.Models;
using Photoexpress.Infrastructure.Database;
using System.Xml.Schema;

namespace Photoexpress.Infrastructure.Managers.Database
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly PhotoexpressContext _context;
        public GenericRepository(PhotoexpressContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity!);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<T>> Get(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Paginate? paginate = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            if (paginate != null)
                query = query.Skip((paginate.PageIndex) * paginate.PageSize).Take(paginate.PageSize);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Paginate? paginate = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (orderBy != null)
                query = orderBy(query);
            if (paginate != null)
                query = query.Skip((paginate.PageIndex) * paginate.PageSize).Take(paginate.PageSize);

            return await query.ToListAsync();
        }

        public async Task<int> GetTotal(System.Linq.Expressions.Expression<Func<T, bool>>? predicate = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if(predicate != null)
            {
                query = query.Where(predicate); 
            }

            return await query.CountAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity!;
        }

        public async Task<bool> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
