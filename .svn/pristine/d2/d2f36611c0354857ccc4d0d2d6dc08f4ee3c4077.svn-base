using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Events.Bus;
using Mall.Domain.Entities;
using Mall.Domain.Events;

namespace Mall.Domain.Service
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOrderManager : IDomainService
    {
        Task UpdateOrder(Mall_Order order, OrderStatus status);
    }


    /// <summary>
    /// 订单服务
    /// </summary>
    public class OrderManager : DomainService, IOrderManager
    {
        private readonly IRepository<Mall_OrderRecord> _recordRepository;
        private readonly IRepository<Mall_CartItem> _cartItemRepository;
        public OrderManager(IRepository<Mall_OrderRecord> recordRepository, IRepository<Mall_CartItem> cartItemRepository)
        {
            _recordRepository = recordRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task UpdateOrder(Mall_Order order, OrderStatus status)
        {
            //1:添加订单记录
            await _recordRepository.InsertAsync(new Mall_OrderRecord()
            {
                OrderId = order.Id,
                OrderStatus = status
            });
            //2:更新订单记录
            var initStatus = order.OrderStatus;
            order.OrderStatus = status;

            //3:只有在商品发货后,才进行通知和更新产品数量
            if (status == OrderStatus.Receive)
            {
                //更新订单产品的销售记录
                var products = _cartItemRepository.GetAllIncluding((c) => c.Product).Where(u => u.CartId.Equals(order.CartId)).ToList();
                products.ForEach(u =>
                {
                    u.Product.SaleNums += u.ItemNum;
                });
                //通知提醒
                EventBus.Default.Trigger(new OrderEventData() { Order = order, OldStatus = initStatus });
            }
        }
    }

}
