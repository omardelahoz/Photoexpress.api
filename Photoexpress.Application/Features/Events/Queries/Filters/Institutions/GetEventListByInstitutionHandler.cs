using AutoMapper;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.Filters.Institutions
{
    public class GetEventListByInstitutionHandler : IRequestHandler<GetEventListByInstitution, Response<EventVm>>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventListByInstitutionHandler(IGenericRepository<Event> @event, IMapper mapper)
        {
            _eventRepository = @event;
            _mapper = mapper;
        }

        public async Task<Response<EventVm>> Handle(GetEventListByInstitution request, CancellationToken cancellationToken)
        {
            var eventList = await _eventRepository.Get(
                    e => e.InstitutionName == request.InstitutionName,
                    e => e.OrderBy(i => i.InstitutionName),
                    new Paginate()
                );

            if(eventList == null || !eventList.Any())
            {
                throw new PhotoexpressException("No se encontró información con la intitución ingresada");
            }

            Response<EventVm> result = new Response<EventVm>();
            result.Total = await _eventRepository.GetTotal(e => e.InstitutionName == request.InstitutionName);
            result.ResultList = _mapper.Map<List<EventVm>>(eventList);

            return result;
        }
    }
}
