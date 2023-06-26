using Photoexpress.Domain.Entities.Base;

namespace Photoexpress.Application.Contracts.Base
{
    public interface IUpdate<T> where T : EntityBase
    {
        Task<bool> Update(T entity);
    }
}
