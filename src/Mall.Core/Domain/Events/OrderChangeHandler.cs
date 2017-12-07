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
using Abp.Notifications;

namespace Mall.Domain.Events
{
    public class OrderChangeHandler : IEventHandler<OrderEventData>, ITransientDependency
    {
        private readonly IEmailSender _emailSender;
        private readonly IRepository<Mall_Account, long> _userRepository;
        private readonly INotificationPublisher _notificationPublisher;

        public OrderChangeHandler(IEmailSender emailSender,
            IRepository<Mall_Account, long> userRepository,
            INotificationPublisher notificationPublisher)
        {
            _emailSender = emailSender;
            _userRepository = userRepository;
            _notificationPublisher = notificationPublisher;
        }

        public void HandleEvent(OrderEventData eventData)
        {
            //发送邮箱
            if (eventData is OrderEventData)
            {
                var order = eventData.Order;
                var user =  _userRepository.Get(order.CreatorUserId.Value);
                if (!string.IsNullOrEmpty(user.Email))
                {
                    var body = $"<div>订单编号:<a href='https://e.mdsd.cn:9100/Order/Index'>{order.OrderNo}</a></div><div>状态变更:<span style='color:blue;'>{eventData.OldStatus.GetDescription()}</span>-><span style='color:blue;'>{order.OrderStatus.GetDescription()}</span></div>";
                    Task.Run(() =>
                    {
                        //1：邮箱通知
                        _emailSender.Send(user.Email, "积分商城-商品到货", body);

                        //2.给用户发送邮件通知,提示人员已经接单
                        //_notificationPublisher.Publish("订单审批完成通知", new MessageNotificationData("订单申请已审批通过"), null, NotificationSeverity.Info, new[] { AbpSession.ToUserIdentifier() });
                    });
                }
            }
        }
    }
}
