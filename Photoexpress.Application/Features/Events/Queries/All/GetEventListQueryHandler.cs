using AutoMapper;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.All
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, Response<EventVm>>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IGenericRepository<Event> @event, IMapper mapper)
        {
            _eventRepository = @event;
            _mapper = mapper;
        }

        public async Task<Response<EventVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var orderBy = CommonQueryUtil.GetOrderBy(request.orderBy, request.ascendent);
            var paginate = request.paginate == null ? new Paginate() : request.paginate;

            Response<EventVm> result = new Response<EventVm>();
            result.Total = await _eventRepository.GetTotal();
            var eventList = await _eventRepository.GetAll(
                    orderBy,
                    paginate
                );
            result.ResultList = _mapper.Map<List<EventVm>>(eventList);

            return result;
        }
    }
}
