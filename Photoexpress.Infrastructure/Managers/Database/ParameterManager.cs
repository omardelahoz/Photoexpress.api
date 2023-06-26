using Microsoft.EntityFrameworkCore;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;
using Photoexpress.Infrastructure.Database;
using System.Linq.Expressions;

namespace Photoexpress.Infrastructure.Managers.Database
{
    public class ParameterManager : IParameterRepository
    {
        private readonly PhotoexpressContext _context;

        public ParameterManager(PhotoexpressContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parameter>> Get(Expression<Func<Parameter, bool>>? predicate, Func<IQueryable<Parameter>, IOrderedQueryable<Parameter>>? orderBy = null, Paginate? paginate = null)
        {
            IQueryable<Parameter> query = _context.Parameters.AsQueryable();
            if (predicate != null)
                query = query.Where(predicate);
            if (orderBy != null)
                query = orderBy(query);
            if (paginate != null)
                query = query.Skip((paginate.PageIndex) * paginate.PageSize).Take(paginate.PageSize);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Parameter>> GetAll(Func<IQueryable<Parameter>, IOrderedQueryable<Parameter>>? orderBy = null, Paginate? paginate = null)
        {
            IQueryable<Parameter> query = _context.Parameters.AsQueryable();
            if (orderBy != null)
                query = orderBy(query);
            if (paginate != null)
                query = query.Skip((paginate.PageIndex) * paginate.PageSize).Take(paginate.PageSize);

            return await query.ToListAsync();
        }

        public async Task<int> GetTotal(Expression<Func<Parameter, bool>>? predicate = null)
        {
            IQueryable<Parameter> query = _context.Parameters.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.CountAsync();
        }


        public async Task<Parameter> GetById(Guid id)
        {
            Parameter? entity = await _context.Parameters.FirstOrDefaultAsync(x => x.Id == id);

            return entity!;
        }
    }
}
