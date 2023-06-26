using Photoexpress.Domain.Entities.Base;

namespace Photoexpress.Application.Contracts.Base
{
    public interface IDelete<T> where T : EntityBase
    {
        Task<bool> Delete(Guid id);
    }
}
