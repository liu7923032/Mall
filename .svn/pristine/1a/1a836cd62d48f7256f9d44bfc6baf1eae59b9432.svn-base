using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Cart
{
    public class CartDtoProfile : Profile
    {

        public CartDtoProfile()
        {

            CreateMap<Mall_CartItem, CartItemDto>()
                .ForMember(u => u.Name, opts => opts.MapFrom(p => p.Product.Name))
                .ForMember(u => u.ItemSpecs, opts => opts.MapFrom(p => p.Product.Describe))
                .ForMember(u => u.ProductId, opts => opts.MapFrom(p => p.Id));

        }
    }
}
