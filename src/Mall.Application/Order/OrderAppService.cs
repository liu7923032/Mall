﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Linq.Extensions;
using Abp.Net.Mail;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.Timing;
using Abp.UI;
using Mall.Cart;
using Mall.Domain.Entities;
using Mall.Integral;
using Microsoft.EntityFrameworkCore;
using Dark.Common.Extension;
using Mall.UserApp;
using Mall.Domain.Events;
using Mall.Domain.Service;

namespace Mall.Order
{
    #region 1.0 接口 IOrderAppService
    public interface IOrderAppService
    {
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<OrderDto>> GetOrders(GetAllOrderInput input);
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task CacelOrder(int orderId);


        /// <summary>
        /// 接单
        /// </summary>
        /// <param name="orderId">订单的id</param>
        /// <param name="status">变更订单的状态</param>
        /// <returns></returns>
        Task AcceptOrder(ChangeOrderInput changeInput);
        /// <summary>
        ///  获取我的订单的数量统计
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        Task<int> GetMyOrderCount(OrderStatus orderStatus);

        /// <summary>
        /// 获取所有订单的数量统计
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        Task<int> GetOrderCount(OrderStatus orderStatus);

        /// <summary>
        /// 通过订单查询所有采购明细
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        Task<PagedResultDto<CartItemDto>> GetAllCartItems(List<int> orderIds);


    }
    #endregion

    #region 2.0 实现 OrderAppService
    /// <summary>
    /// 订单处理类
    /// </summary>
    public class OrderAppService : MallAppServiceBase, IOrderAppService
    {
        private IRepository<Mall_Order> _orderRepository;
        private IRepository<Mall_Integral> _integralRepository;
        private IRepository<Mall_Product> _productService;
        private IRepository<Mall_CartItem> _cartItemRepository;
        private IRepository<Mall_OrderRecord> _orderRecordRepository;
        
        private IIntegralAppService _integralAppService;
        private IOrderManager _orderManager;

        public OrderAppService(IRepository<Mall_Order> orderRepository,
            IRepository<Mall_Integral> integralRepository,
            INotificationPublisher notificationPublisher,
            IRepository<Mall_Product> productRepository,
            IRepository<Mall_CartItem> cartItemRepository,
            IRepository<Mall_OrderRecord> orderRecordRepository,
            IIntegralAppService integralAppService,
            IEmailSender emailSender,
            IUserAppService userAppService, IOrderManager orderManager)
        {
            _orderRepository = orderRepository;
            _integralRepository = integralRepository;
            _productService = productRepository;
            _cartItemRepository = cartItemRepository;
            _orderRecordRepository = orderRecordRepository;
            _integralAppService = integralAppService;
            _orderManager = orderManager;

        }

        /// <summary>
        /// 通过状态获取订单
        /// </summary>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        private IQueryable<Mall_Order> GetOrders(OrderStatus orderStatus)
        {
            return _orderRepository.GetAll().Where(u => u.OrderStatus.Equals(orderStatus));
        }



        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<OrderDto>> GetOrders(GetAllOrderInput input)
        {

            var orders = GetOrders(input.OrderStatus);
            //获取我的订单
            if (input.OrderType == OrderType.Me)
            {
                orders = orders.Where(u => u.CreatorUserId.Value.Equals(UserId));
            }

            var count = orders.Count();
            //2:获取对数据进行排序和分页处理
            orders = orders.Include("CreatorUser").Include("Address").OrderByDescending(u => u.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount);

            return await Task.FromResult(new PagedResultDto<OrderDto>() { TotalCount = count, Items = orders.MapTo<List<OrderDto>>() });
        }


        public async Task<int> GetMyOrderCount(OrderStatus orderStatus)
        {
            return await GetOrders(orderStatus).Where(u => u.CreatorUserId.Value.Equals(UserId)).CountAsync();
        }

        public async Task<int> GetOrderCount(OrderStatus orderStatus)
        {
            return await GetOrders(orderStatus).CountAsync();
        }

        /// <summary>
        /// 接受订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task AcceptOrder(ChangeOrderInput changeInput)
        {
            //1.找到订单
            var orders = await _orderRepository.GetAllListAsync(u => changeInput.OrderIds.Contains(u.Id));

            Dictionary<string, string> emails = new Dictionary<string, string>();
            foreach (var order in orders)
            {
                await _orderManager.UpdateOrder(order, changeInput.OrderStatus);
            }


            //3:订单的状态采购完成,才能进行对产品的销售数据加1
            //if (changeInput.OrderStatus == OrderStatus.Receive)
            //{
            //    var cartIds = orders.Select(u => u.CartId).ToList();
            //    var products = _cartItemRepository.GetAll().Where(u => cartIds.Contains(u.CartId)).ToList();
            //    products.ForEach(u =>
            //    {
            //        var product = _productService.FirstOrDefault(u.ProductId);
            //        product.SaleNums += u.ItemNum;
            //    });
            //}


            

        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task CacelOrder(int orderId)
        {
            //1:获取订单
            var order = await _orderRepository.GetAsync(orderId);
            if (order.OrderStatus != OrderStatus.Init)
            {
                throw new UserFriendlyException("订单已经再采购,无法再取消");
            }
            //2:添加积分记录
            await _integralAppService.Create(new CreateIntegralInput()
            {
                ValidationCode = MallConsts.SecurityCode,
                TypeName = "人员",
                CostType = CostType.Earn,
                ActDate = Clock.Now,
                DeptId = 0,
                Describe = $"订单:{order.Id}_{order.OrderNo} 退款",
                Integral = order.AllPrice,
                UserId = UserId,
            });

            //3:作废该订单
            await _orderRepository.DeleteAsync(orderId);
        }

        /// <summary>
        /// 通过订单来获取所有明细数据
        /// </summary>
        /// <param name="orderIds"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<CartItemDto>> GetAllCartItems(List<int> orderIds)
        {

            var items = _orderRepository.GetAll()
                            .Include("Cart")
                            .Include("CreatorUser")
                            .Include("CartItems");

            return await Task.FromResult(new PagedResultDto<CartItemDto>() { TotalCount = items.Count(), Items = items.MapTo<List<CartItemDto>>() });
        }
    }
    #endregion

}
