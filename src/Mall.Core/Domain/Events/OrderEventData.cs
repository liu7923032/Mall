using System;
using System.Collections.Generic;
using System.Text;
using Abp.Events.Bus;
using Mall.Domain.Entities;

namespace Mall.Domain.Events
{
    public class OrderEventData : EventData
    {

        public int OrderId { get; set; }

        public string ToEmail { get; set; }

        public OrderStatus OldStatus { get; set; }


    }
}
