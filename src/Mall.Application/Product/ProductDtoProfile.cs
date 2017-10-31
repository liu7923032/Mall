using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Product
{
    public class ProductDtoProfile:Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<ProductDto, Mall_Product>();
        }
    }
}
