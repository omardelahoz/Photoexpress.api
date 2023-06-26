using AutoMapper;
using Photoexpress.Domain.Entities;
using Photoexpress.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photoexpress.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventVm>().ReverseMap();
            CreateMap<Parameter, ParameterVm>().ReverseMap();
        }
    }
}
