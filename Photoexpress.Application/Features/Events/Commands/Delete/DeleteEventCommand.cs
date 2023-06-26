using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Application.Features.Events.Commands.Delete
{
    public class DeleteEventCommand : IRequest<bool>
    {
        public Guid? Id { get; set; }   
    }
}
