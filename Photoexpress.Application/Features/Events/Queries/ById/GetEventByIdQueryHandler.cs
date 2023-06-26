using AutoMapper;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.ById
{
    public class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, Response<EventVm>>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(IGenericRepository<Event> @event, IMapper mapper)
        {
            _eventRepository = @event;
            _mapper = mapper;
        }

        public async Task<Response<EventVm>> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var eventInstance = await _eventRepository.GetById(request.Id); 

            if(eventInstance == null)
            {
                throw new PhotoexpressException("No se encontró un evento con la información ingresada");
            }

            Response<EventVm> result = new Response<EventVm>();
            
            result.ResultObject = _mapper.Map<EventVm>(eventInstance); 

            return result;
        }
    }
}
