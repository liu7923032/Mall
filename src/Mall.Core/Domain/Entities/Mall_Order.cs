﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    public class Mall_Order : FullAuditedEntity
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        [Required]
        [StringLength(20)]
        public string OrderNo { get; set; }

        /// <summary>
        /// 购物车对应的Id
        /// </summary>
        [Required]
        public int CartId { get; set; }

        /// <summary>
        /// 导航属性
        /// </summary>
        [ForeignKey("CartId")]
        public virtual Mall_Cart Cart { get; set; }

        /// <summary>
        /// 购物车总金额
        /// </summary>
        [Required]
        public decimal AllPrice { get; set; }

        [Required]
        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public virtual Mall_Address Address { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }

        public Mall_Order()
        {
            OrderStatus = OrderStatus.Init;
            AllPrice = 0;
        }


        /// <summary>
        /// 通过串联创建人和修改人
        /// </summary>
        [ForeignKey("CreatorUserId")]
        public virtual Mall_Account CreatorUser { get; set; }

        [ForeignKey("LastModifierUserId")]
        public virtual Mall_Account LastModifierUser { get; set; }
    }


    /// <summary>
    /// 货物状态
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// 待接收
        /// </summary>
        [Description("初始")]
        Init = 0,
        /// <summary>
        /// 采购中
        /// </summary>
        [Description("采购中")]
        Purchase,
        /// <summary>
        /// 到货
        /// </summary>
        [Description("到货")]
        Receive,
        /// <summary>
        /// 已收货
        /// </summary>
        [Description("完成")]
        Complete
    }

}
