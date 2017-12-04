﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Mall.Domain.Entities;
using Newtonsoft.Json;

namespace Mall.Cart
{


    [AutoMapTo(typeof(Mall_CartItem))]
    public class CartItemInput
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "物品数量要大于0")]
        public int ItemNum { get; set; }

        /// <summary>
        /// 商品的额外说明
        /// </summary>
        public string Describe { get; set; }

    }


    [AutoMap(typeof(Mall_CartItem))]
    public class CartItemDto : CartItemInput, IEntityDto<int>
    {
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// 产品名称
        /// </summary>
        [Required]
        public string ItemName { get; set; }


        public string ItemSpecs { get; set; }

        /// <summary>
        /// 产品价格
        /// </summary>
        [Range(1, Int32.MaxValue, ErrorMessage = "物品金额要大于0")]
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        //[Range(0, Int32.MaxValue, ErrorMessage = "数量要大于0")]
        public decimal AllPrice { get; set; }

        /// <summary>
        /// 请购人
        /// </summary>
        public string CreatorUserName { get; set; }

        /// <summary>
        /// 请购时间
        /// </summary>
        [JsonConverter(typeof(MallDateFormat))]
        public DateTime ApplyDate { get; set; }

        public string LinkAddr { get; set; }

    }

    public class GetItemsInput : PagedAndSortedResultRequestDto
    {
        public List<int> CartIds { get; set; }


        public string StrCartIds { get; set; }

    }

}
