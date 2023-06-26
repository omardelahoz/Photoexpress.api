using Photoexpress.Domain.Entities.Base;

namespace Photoexpress.Application.Contracts.Base
{
    public interface IAdd<T> where T : EntityBase
    {
        Task<bool> Add(T entity);
    }
}
