using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.AutoMapper;

namespace Mall.Cart
{
    public class CartDto
    {

    }

    public class CartItemInput
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int ItemNum { get; set; }
    }
}
