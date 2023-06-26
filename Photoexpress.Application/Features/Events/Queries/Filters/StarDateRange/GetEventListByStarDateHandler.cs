using AutoMapper;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.Filters.StarDateRange
{
    public class GetEventListByStarDateHandler : IRequestHandler<GetEventListByStarDate, Response<EventVm>>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventListByStarDateHandler(IGenericRepository<Event> @event, IMapper mapper)
        {
            _eventRepository = @event;
            _mapper = mapper;
        }

        public async Task<Response<EventVm>> Handle(GetEventListByStarDate request, CancellationToken cancellationToken)
        {
            var eventList = await _eventRepository.Get(
                    e => e.StartTime > request.StartDate && e.StartTime < request.EndDate,
                    e => e.OrderBy(i => i.StartTime),
                    new Paginate()
                );

            if (eventList == null || !eventList.Any())
            {
                throw new PhotoexpressException("No se encontró información con el rango de fechas igresado");
            }
            Response<EventVm> result = new Response<EventVm>();
            result.Total = await _eventRepository.GetTotal(e => e.StartTime > request.StartDate && e.StartTime < request.EndDate); ;

            result.ResultList = _mapper.Map<List<EventVm>>(eventList);

            return result;
        }
    }
}
