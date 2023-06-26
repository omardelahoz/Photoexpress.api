using MediatR;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.All
{
    public class GetEventListQuery: IRequest<Response<EventVm>>
    {
        public Paginate? paginate { get; }
        public string orderBy { get; }
        public bool ascendent { get; }

        public GetEventListQuery(string orderBy, bool ascendent, int? pageIndex, int? pageSize)
        {
            this.orderBy = orderBy;
            this.ascendent = ascendent;

            if(pageIndex.HasValue && pageSize.HasValue)
            {
                paginate = new Paginate
                {
                    PageIndex = pageIndex.Value,
                    PageSize = pageSize.Value
                };
            }
        }
    }
}
