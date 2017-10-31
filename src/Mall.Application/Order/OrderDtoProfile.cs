using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Order
{
    public class OrderDtoProfile:Profile
    {
        public OrderDtoProfile()
        {
            CreateMap<Mall_Order, OrderDto>();
        }
    }
}
