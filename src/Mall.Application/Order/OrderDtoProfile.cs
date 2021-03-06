﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Order
{
    public class OrderDtoProfile : Profile
    {
        public OrderDtoProfile()
        {
            CreateMap<Mall_Order, OrderDto>();
            CreateMap<Mall_Order, OrderDto>().ForMember(u => u.CreatorName, opts => opts.MapFrom(p => p.CreatorUser.UserName))
                .ForMember(u => u.ApproveUName, opts => opts.MapFrom(p => p.LastModifierUser.UserName))
                .ForMember(u => u.AddressInfo, opts => opts.MapFrom(p => p.Address.ToString()));
        }

        /// <summary>
        /// 处理购物状态
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>

    }
}
