﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Mall.Domain.Entities;

namespace Mall.Category
{
    /// <summary>
    /// 创建
    /// </summary>
    [AutoMapTo(typeof(Mall_Category))]
    public class CreateCategoryInput
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryNo { get; set; }

        [StringLength(400)]
        public string Describe { get; set; }
    }

    /// <summary>
    /// 更新的
    /// </summary>
    [AutoMapTo(typeof(Mall_Category))]
    public class UpdateCategoryInput : CreateCategoryInput, IEntityDto<int>
    {
        [Required]
        public int Id { get; set; }
    }

    [AutoMap(typeof(Mall_Category))]
    public class CategoryDto: UpdateCategoryInput
    {

    }

    public class GetAllCategoryInput : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }

}
