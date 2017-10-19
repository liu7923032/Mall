using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace Mall.Category
{
    /// <summary>
    /// 
    /// </summary>
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
    public class UpdateCategoryInput : CreateCategoryInput, IEntityDto<int>
    {
        [Required]
        public int Id { get; set; }
    }

    public class CategoryDto: UpdateCategoryInput
    {

    }

    public class GetAllCategoryInput : PagedAndSortedResultRequestDto
    {
        public string Name { get; set; }
    }






}
