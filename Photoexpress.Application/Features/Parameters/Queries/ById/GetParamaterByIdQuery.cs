using MediatR;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Parameters.Queries.ById
{
    public class GetParamaterByIdQuery : IRequest<Response<ParameterVm>>
    {
        public Guid Id { get; }

        public GetParamaterByIdQuery(Guid? id)
        {
            Id = id.HasValue ? id.Value : throw new PhotoexpressException("Debe enviar el valor del id") ;
        }
    }
}
