using AutoMapper;
using FluentValidation;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Features.Events.Validators;
using Photoexpress.Domain.Entities;

namespace Photoexpress.Application.Features.Events.Commands.Update
{
    public class UpdateEventCommandhandler : IRequestHandler<UpdateEventCommand, bool>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Event> _eventValidator;

        public UpdateEventCommandhandler(IGenericRepository<Event> @event, IMapper mapper, IValidator<Event> eventValidator)
        {
            _eventRepository = @event;
            _mapper = mapper;
            _eventValidator = eventValidator;
        }

        public async Task<bool> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var eventInstance = _mapper.Map<Event>(request.Event);

            ((CreateEventCommandValitor)_eventValidator)
                .Evaluate(eventInstance);

            return await _eventRepository.Update(eventInstance);
        }
    }
}
