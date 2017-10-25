using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Mall.Domain.Entities;

namespace Mall.Order
{
    #region 1.0 接口 IOrderAppService
    public interface IOrderAppService
    {
        /// <summary>
        /// 确认订单
        /// </summary>
        /// <returns></returns>
        Task<Mall_Order> AcceptOrder(int orderId);
    }
    #endregion

    #region 2.0 实现 OrderAppService
    /// <summary>
    /// 订单处理类
    /// </summary>
    public class OrderAppService : MallAppServiceBase, IOrderAppService
    {
        private IRepository<Mall_Order> _orderRepository;
        public OrderAppService(IRepository<Mall_Order> orderRepository)
        {
            this._orderRepository = orderRepository;
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
