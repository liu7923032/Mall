using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 产品名称
    /// </summary>
    public class Mall_Product : FullAuditedEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string ItemNo { get; set; }

        [StringLength(1000)]
        public string Describe { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Mall_Product()
        {
            Price = 0;
        }
    }
}
