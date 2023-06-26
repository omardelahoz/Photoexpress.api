using AutoMapper;
using FluentValidation;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Features.Events.Validators;
using Photoexpress.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Application.Features.Events.Commands.Delete
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IGenericRepository<Event> _event;
        private readonly IMapper _mapper;
        private readonly IValidator<Event> _eventValidator;

        public DeleteEventCommandHandler(IGenericRepository<Event> @event, IMapper mapper, IValidator<Event> eventValidator)
        {
            _event = @event;
            _mapper = mapper;
            _eventValidator = eventValidator;
        }

        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            if (!request.Id.HasValue)
            {
                throw new PhotoexpressException("Debe enviar un id");
            }

            return await _event.Delete(request.Id.Value);
        }
    }
}
