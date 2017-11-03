using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    public class Mall_Integral: CreationAuditedEntity
    {
        /// <summary>
        /// 花费
        /// </summary>
        [Required]
        public CostType CostType { get; set; }

        [Required]
        public decimal Integral { get; set; }

        /// <summary>
        /// 消费人员
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string IntergralDesc { get; set; }

        [ForeignKey("UserId")]
        public virtual Mall_Account Account { get; set; }
    }


    public enum CostType
    {
        /// <summary>
        /// 获得
        /// </summary>
        Earn,
        /// <summary>
        /// 花费
        /// </summary>
        Cost
    }
}
