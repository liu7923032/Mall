using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Integral
{
    public class IntegralDtoProfile : Profile
    {
        public IntegralDtoProfile()
        {
            CreateMap<CreateIntegralInput, Mall_Integral>();
            CreateMap<Mall_Integral, IntegralDto>();
        }
    }
}
