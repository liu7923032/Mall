﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Mall.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
        Task<PagedResultDto<OrderDto>> GetMyOrders(GetAllOrderInput input);
        /// <summary>
        /// 确认订单
        /// </summary>
        /// <returns></returns>
        Task<Mall_Order> AcceptOrder(int orderId);

        Task<int> GetMyOrderCount(OrderStatus orderStatus);

        Task<int> GetOrderCount(OrderStatus orderStatus);

    }
    #endregion

    #region 2.0 实现 OrderAppService
    /// <summary>
    /// 订单处理类
    /// </summary>
    public class OrderAppService : MallAppServiceBase, IOrderAppService
    {
        private IRepository<Mall_Order> _orderRepository;
        private IRepository<Mall_Account> _accountRepository;
        public OrderAppService(IRepository<Mall_Order> orderRepository, IRepository<Mall_Account> accountRepository)
        {
            this._accountRepository = accountRepository;
            this._orderRepository = orderRepository;
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
        public async Task<PagedResultDto<OrderDto>> GetMyOrders(GetAllOrderInput input)
        {

            var orders = GetOrders(input.OrderStatus);
            //获取我的订单
            if (input.OrderType == OrderType.Me)
            {
                orders = orders.Where(u => u.CreatorUserId.Value.Equals(UserId));
            }
            var data = from a in orders
                       join b in _accountRepository.GetAll()
                       on a.CreatorUserId.Value equals b.Id
                       join c in _accountRepository.GetAll()
                       on a.LastModifierUserId.Value equals c.Id into leftJoin
                       from c in leftJoin.DefaultIfEmpty()
                       select new OrderDto
                       {
                           Id = a.Id,
                           OrderNo = a.OrderNo,
                           OrderStatus = a.OrderStatus,
                           CreationTime = a.CreationTime,
                           CreatorName = b.Account,
                           AllPrice = a.AllPrice,
                           CartId = a.CartId,
                           ApproveTime = a.LastModificationTime,
                           ApproveUName = c == null ? "" : c.Account
                       };
            //2:获取对数据进行排序和分页处理
            data = data.OrderByDescending(u => u.CreationTime).Skip(input.SkipCount).Take(input.MaxResultCount);

            return await Task.FromResult(new PagedResultDto<OrderDto>() { TotalCount = data.Count(), Items = data.ToList() });
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
        public async Task<Mall_Order> AcceptOrder(int orderId)
        {
            //1.找到订单
            var order = await _orderRepository.FirstOrDefaultAsync(u => u.Id.Equals(orderId));
            //2.更新订单状态
            order.OrderStatus = OrderStatus.Complete;
            //3.更新
            return await _orderRepository.UpdateAsync(order);
        }

    }
    #endregion

}
