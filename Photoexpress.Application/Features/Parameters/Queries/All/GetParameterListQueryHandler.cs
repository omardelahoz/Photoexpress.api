using AutoMapper;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Models;

namespace Photoexpress.Application.Features.Parameters.Queries.All
{
    public class GetParameterListQueryHandler : IRequestHandler<GetParameterListQuery, Response<ParameterVm>>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;

        public GetParameterListQueryHandler(IParameterRepository paramRepository, IMapper mapper)
        {
            _parameterRepository = paramRepository;
            _mapper = mapper;
        }

        public async Task<Response<ParameterVm>> Handle(GetParameterListQuery request, CancellationToken cancellationToken)
        {
            var parameterList = await _parameterRepository.GetAll();


            Response<ParameterVm> result = new Response<ParameterVm>();

            result.ResultList = _mapper.Map<List<ParameterVm>>(parameterList);
            return result; 
        }
    }
}
