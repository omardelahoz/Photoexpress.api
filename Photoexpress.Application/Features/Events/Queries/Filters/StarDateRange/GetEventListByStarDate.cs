using MediatR;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.Filters.StarDateRange
{
    public class GetEventListByStarDate : IRequest<Response<EventVm>>
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public GetEventListByStarDate(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate ?? DateTime.MinValue;
            EndDate = endDate ?? DateTime.MaxValue;
        }
    }
}
