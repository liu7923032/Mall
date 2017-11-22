﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 订单状态变更记录表
    /// </summary>
    public class Mall_OrderRecord : CreationAuditedEntity
    {
        /// <summary>
        /// 订单的状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }


        public int OrderId { get; set; }

        /// <summary>
        /// 对应的订单
        /// </summary>
        [ForeignKey("OrderId")]
        public virtual Mall_Order Order { get; set; }
    }
}
