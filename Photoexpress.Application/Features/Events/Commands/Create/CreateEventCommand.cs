using MediatR;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Commands.Create
{
    public class CreateEventCommand : IRequest<bool>
    {
        public EventVm? Event { get; }

        public CreateEventCommand(EventVm? @event)
        {
            Event = @event;
        }
    }
}
