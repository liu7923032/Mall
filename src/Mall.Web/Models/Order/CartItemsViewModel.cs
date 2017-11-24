﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mall.Cart;

namespace Mall.Web.Models.Order
{
    public class CartItemsViewModel
    {
        public List<CartItemDto> CartItems { get; set; }

        public int Total { get; set; }
    }
}
