using System;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Mall.Domain.Entities;

namespace Mall.Order
{
    /// <summary>
    /// 返回订单列表
    /// </summary>
    public class OrderDto : IEntityDto<int>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public string OrderNo { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        [Required]
        public decimal AllPrice { get; set; }
    }


    public class GetAllOrderInput : PagedAndSortedResultRequestDto
    {
        public OrderStatus? OrderStatus { get; set; }
    }
}
