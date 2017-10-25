using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Mall.Domain.Entities;

namespace Mall.Product
{

    /// <summary>
    /// 创建的dto
    /// </summary>
    [AutoMap(typeof(Mall_Product))]
    public class CreateProductInput
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemNo { get; set; }

        [StringLength(1000)]
        public string Describe { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

    }

    /// <summary>
    /// 更新的dto
    /// </summary>
    public class UpdateProductInput : CreateProductInput,IEntityDto<int>
    {
        [Required]
        public int Id { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ProductDto : UpdateProductInput
    {
        public string CategoryName { get; set; }
    }

    /// <summary>
    /// 查询条件
    /// </summary>
    public class GetAllProductInput: PagedAndSortedResultRequestDto
    {
        /// <summary>
        /// 通过名称来查询产品
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 通过分类来查询产品
        /// </summary>
        public int? CategoryId { get; set; }
    }

}
