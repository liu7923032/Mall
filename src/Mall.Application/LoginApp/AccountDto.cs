using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.AutoMapper;
using Mall.Domain.Entities;

namespace Mall.LoginApp
{
    [AutoMap(typeof(Mall_Account))]
    public class AccountDto
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
    }
}
