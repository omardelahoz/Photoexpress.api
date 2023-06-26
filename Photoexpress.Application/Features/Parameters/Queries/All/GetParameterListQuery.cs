using MediatR;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Parameters.Queries.All
{
    public class GetParameterListQuery : IRequest<Response<ParameterVm>>
    {
    }
}
