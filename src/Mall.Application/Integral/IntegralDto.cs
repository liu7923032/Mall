﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Integral
{
    [AutoMapTo(typeof(Mall_Integral))]
    public class CreateIntegralInput
    {
        /// <summary>
        /// 花费
        /// </summary>
        [Required]
        public CostType CostType { get; set; }

        [Required]
        public decimal Integral { get; set; }

        /// <summary>
        /// 消费人员或者部门
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [Required]
        public int DeptId { get; set; }

        [Required]
        public string TypeName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Describe { get; set; }

        /// <summary>
        /// 积分发生的时间
        /// </summary>
        public DateTime ActDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public int? CreatorUserId { get; set; }
    }

    public class UpdateIntegralInput : CreateIntegralInput, IEntityDto<int>
    {
        public int Id { get; set; }

    }


    public class IntegralDto : UpdateIntegralInput
    {

    }

    /// <summary>
    /// 通过人员来获取积分
    /// </summary>
    public class GetIntegralsInput
    {
        //通过人员来获取积分
        public int UserId { get; set; }
    }
}
