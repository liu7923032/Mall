﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Mall.Domain.Entities;

namespace Mall.UserApp
{
    public class UserDtoProfile:Profile
    {
        public UserDtoProfile()
        {
            CreateMap<Mall_Account, UserDto>();
            CreateMap<UserDto, Mall_Account>();
        }
    }
}
