using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Product
{
    public class ProductDtoProfile : Profile
    {
        public ProductDtoProfile()
        {
            CreateMap<UpdateProductInput, Mall_Product>();
            CreateMap<CreateProductInput, Mall_Product>();

            CreateMap<Mall_Product, CreateProductInput>().ForMember(u => u.FileIds, opts => opts.Ignore());

            CreateMap<Mall_Product, ProductDto>().ForMember(u => u.CategoryName, opts => opts.MapFrom(u => u.Category.Name));
        }
    }
}
