using Photoexpress.Domain.Entities.Base;
using Photoexpress.Domain.Models;
using System.Linq.Expressions;

namespace Photoexpress.Application.Contracts.Base
{
    public interface IGet<T> where T : EntityBase
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Paginate? paginate = null);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, Paginate? paginate = null);
        Task<int> GetTotal(Expression<Func<T, bool>>? predicate = null);
    }
}
