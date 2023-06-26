using MediatR;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Events.Queries.Filters.Institutions
{
    public class GetEventListByInstitution: IRequest<Response<EventVm>>
    {
        public string? InstitutionName { get; }

        public GetEventListByInstitution(string? institutionName)
        {
            InstitutionName = institutionName ?? throw new PhotoexpressException("Debe ingrear el nombre de la institución");
        }
    }
}
