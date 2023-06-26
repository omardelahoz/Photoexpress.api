using AutoMapper;
using MediatR;
using Photoexpress.Application.Contracts.Database;
using Photoexpress.Application.Exceptions;
using Photoexpress.Application.Responses;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Application.Features.Parameters.Queries.ById
{
    public class GetParamaterByIdQueryHandler : IRequestHandler<GetParamaterByIdQuery, Response<ParameterVm>>
    {
        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;

        public GetParamaterByIdQueryHandler(IParameterRepository paramRepository, IMapper mapper)
        {
            _parameterRepository = paramRepository;
            _mapper = mapper;
        }

        public async Task<Response<ParameterVm>> Handle(GetParamaterByIdQuery request, CancellationToken cancellationToken)
        {
            var parameter = await _parameterRepository.GetById(request.Id);

            if (parameter == null)
            {
                throw new PhotoexpressException("No se encontró un parámetro con la información ingresada");
            }

            Response<ParameterVm> result = new Response<ParameterVm>();

            result.ResultObject = _mapper.Map<ParameterVm>(parameter);

            return result;
        }
    }
}
