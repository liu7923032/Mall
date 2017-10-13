using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace Mall.Category
{
    public class CategoryDto:EntityDto
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryNo { get; set; }

        [Required]
        public string Creator { get; set; }

        public DateTime CreationTime { get; set; }
    }


    public class CategoryOutput
    {
        public List<CategoryDto> Category { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CategoryInput
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





    
}
