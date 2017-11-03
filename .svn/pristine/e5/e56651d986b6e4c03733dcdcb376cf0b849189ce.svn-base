using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    public class Mall_Account:AuditedEntity
    {
        [Required]
        [StringLength(20)]
        public string Account { get; set; }

        [Required]
        [StringLength(10)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// 个人积分
        /// </summary>
        public decimal? Integral { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsLock { get; set; }

        public Mall_Account()
        {
            IsActive = true;
            IsLock = false;
        }
    }
}
