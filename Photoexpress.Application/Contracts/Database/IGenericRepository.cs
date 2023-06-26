using Photoexpress.Application.Contracts.Base;
using Photoexpress.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Application.Contracts.Database
{
    public interface IGenericRepository<T> : IAdd<T>, IDelete<T>, IGet<T>, IUpdate<T> where T : EntityBase
    {
    }
}
