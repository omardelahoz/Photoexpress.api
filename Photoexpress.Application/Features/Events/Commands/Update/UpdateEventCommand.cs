using MediatR;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Commands.Update
{
    public class UpdateEventCommand: IRequest<bool>
    {
        public EventVm? Event { get; }

        public UpdateEventCommand(EventVm? @event)
        {
            Event = @event;
        }
    }
}
