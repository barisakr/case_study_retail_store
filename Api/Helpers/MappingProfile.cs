using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Api.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerOutputDTO>()
            .ForMember(t => t.CustomerType, f => f.MapFrom(s => s.CustomerType.Name))
             .ForMember(t => t.DiscountType, f => f.MapFrom(s => s.CustomerType.DiscountDefinition.Name));
        }
    }
}