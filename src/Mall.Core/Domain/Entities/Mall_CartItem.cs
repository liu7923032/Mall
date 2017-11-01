﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 购物车明细
    /// </summary>
    public class Mall_CartItem : CreationAuditedEntity
    {
        [Required]
        public int ItemNum { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// 小计
        /// </summary>
        [Required]
        public decimal AllPrice { get; set; }
        
        [Required]
        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public virtual Mall_Cart Cart { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Mall_Product Product { get; set; }


    }
}
