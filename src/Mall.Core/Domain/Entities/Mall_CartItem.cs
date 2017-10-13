using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public int ProductId { get; set; }

        [Required]
        public int ItemNum { get; set; }

        [Required]
        public decimal ItemPrice { get; set; }

        /// <summary>
        /// 购物车的主键
        /// </summary>
        [Required]
        public int CartId { get; set; }

    }
}
