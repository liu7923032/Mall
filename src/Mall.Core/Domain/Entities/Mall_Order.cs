using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// 购物车总金额
        /// </summary>
        [Required]
        public decimal AllPrice { get; set; }

        [Required]
        public OrderStatus OrderStatus { get; set; }
        public Mall_Order()
        {
            OrderStatus = OrderStatus.Init;
            AllPrice = 0;
        }


    }


    /// <summary>
    /// 货物状态
    /// </summary>
    public enum OrderStatus
    {
        //未发货
        Init=0,
        

        //发货完成
        Complete
    }

   
}
