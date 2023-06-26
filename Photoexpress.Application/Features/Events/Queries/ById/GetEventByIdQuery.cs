using MediatR;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.ById
{
    public class GetEventByIdQuery : IRequest<Response<EventVm>>
    {
        public Guid Id { get; }

        public GetEventByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
