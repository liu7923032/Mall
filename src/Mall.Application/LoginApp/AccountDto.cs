﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mall.Domain.Entities;

namespace Mall.LoginApp
{
    [AutoMapFrom(typeof(Mall_Account))]
    public class AccountDto : CreateAccountInput,IEntityDto<int>
    {
        public int Id { get; set; }

    }

    [AutoMapFrom(typeof(Mall_Account))]
    public class CreateAccountInput 
    {

        [StringLength(20)]
        public string Account { get; set; }

        [StringLength(10)]
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// 个人积分
        /// </summary>
        public decimal? Integral { get; set; }
    }
}
