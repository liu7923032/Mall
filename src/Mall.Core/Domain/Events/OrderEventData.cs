using System;
using System.Collections.Generic;
using System.Text;
using Abp.Events.Bus;
using Mall.Domain.Entities;

namespace Mall.Domain.Events
{
    public class OrderEventData : EventData
    {

        public OrderStatus OldStatus { get; set; }

        public Mall_Order Order { get; set; }
    }
}
