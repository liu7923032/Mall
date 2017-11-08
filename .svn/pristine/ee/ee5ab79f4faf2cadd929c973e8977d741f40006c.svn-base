using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.AspNetCore.Mvc.Authorization;
using Mall.Cart;
using Mall.Order;
using Mall.Web.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace Mall.Web.Controllers
{
    public class OrderController : MallControllerBase
    {
        private ICartAppService _cartAppService;
        private IOrderAppService _orderAppService;

        public OrderController(ICartAppService cartAppService, IOrderAppService orderAppService)
        {
            _cartAppService = cartAppService;
            _orderAppService = orderAppService;
        }

        /// <summary>
        /// 订单页面
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            //第一次加载数据
            ViewData["EndOrderNum"]= await _orderAppService.GetMyOrderCount(Domain.Entities.OrderStatus.Complete);

            return View();
        }

        /// <summary>
        /// 查询订单的详细信息
        /// </summary>
        /// <param name="id">购物车的id</param>
        /// <returns></returns>
        public async Task<ActionResult> Details(int id)
        {
            var cartItems = await _cartAppService.GetCartById(id);
            //获取订单详细信息
            return View(new CartItemsViewModel() { CartItems = cartItems });
        }


        
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Approve()
        {
            ViewData["EndOrderNum"] = await _orderAppService.GetMyOrderCount(Domain.Entities.OrderStatus.Complete);
            return View();
        }
    }
}