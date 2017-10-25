using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 商品分类
    /// </summary>
    public class Mall_Category : AuditedEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 对应物料的上级
        /// </summary>
        public int? ParentId { get; set; }


        [Required]
        [StringLength(20)]
        public string CategoryNo { get; set; }

        [StringLength(1000)]
        public string Describe { get; set; }

    }
}
