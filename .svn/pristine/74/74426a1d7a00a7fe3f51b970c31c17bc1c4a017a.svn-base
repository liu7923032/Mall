using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class Mall_Cart : AuditedEntity
    {
        /// <summary>
        /// 结算状态
        /// </summary>
        [Required]
        public CartStatus ItemStatus { get; set; }

        /// <summary>
        /// 购物车明细
        /// </summary>
        public List<Mall_CartItem> _cartItemList { get; }

        /// <summary>
        /// 初始化状态
        /// </summary>
        public Mall_Cart()
        {

            ItemStatus = CartStatus.Init;

            _cartItemList = new List<Mall_CartItem>();
        }

    }

    

    /// <summary>
    /// 购物车中物料的状态
    /// </summary>
    public enum CartStatus
    {
        //初始状态
        Init = 0,
        //付款
        Pay,
    }
}
