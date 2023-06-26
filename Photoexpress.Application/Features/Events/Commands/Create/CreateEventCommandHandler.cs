using AutoMapper;
using FluentValidation;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Features.Events.Validators;
using Photoexpress.Domain.Entities;

namespace Photoexpress.Application.Features.Events.Commands.Create
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, bool>
    {
        private readonly IGenericRepository<Event> _eventRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<Event> _eventValidator;

        public CreateEventCommandHandler(IGenericRepository<Event> generic, IMapper mapper, IValidator<Event> eventValidator)
        {
            _eventRepository = generic;
            _mapper = mapper;
            _eventValidator = eventValidator;
        }

        public async Task<bool> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var eventInstance = _mapper.Map<Event>(request.Event);

            ((CreateEventCommandValitor)_eventValidator)
                .Evaluate(eventInstance);

            return await _eventRepository.Add(eventInstance);
        }
    }
}
