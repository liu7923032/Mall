using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using Abp.Events.Bus.Handlers;
using Abp.Net.Mail;
using Mall.Domain.Entities;
using Dark.Common.Extension;
using Abp.Dependency;
using System.Threading.Tasks;

namespace Mall.Domain.Events
{
    public class OrderChangeHandler : IEventHandler<OrderEventData>, ITransientDependency
    {
        private IEmailSender _emailSender;
        private IRepository<Mall_Order> _orderRepository;

        public OrderChangeHandler(IEmailSender emailSender, IRepository<Mall_Order> orderRepository)
        {
            _emailSender = emailSender;
            _orderRepository = orderRepository;
        }

        public  void HandleEvent(OrderEventData eventData)
        {
            var order = _orderRepository.Get(eventData.OrderId);
            //发送邮箱
            if (eventData is OrderEventData)
            {
                var body = $"<div>订单编号:<a href='https://e.mdsd.cn:9100/Order/Index'>{order.OrderNo}</a></div><div>状态变更:<span style='color:blue;'>{eventData.OldStatus.GetDescription()}</span>-><span style='color:blue;'>{order.OrderStatus.GetDescription()}</span></div>";
                Task.Run(() =>
                {
                    _emailSender.Send(eventData.ToEmail, "积分商城-订单到货", body);
                });
            }
        }
    }
}
