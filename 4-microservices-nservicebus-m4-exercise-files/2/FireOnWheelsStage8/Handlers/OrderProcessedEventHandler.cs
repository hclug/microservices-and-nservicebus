using System;
using FireOnWheels.Messages;
using NServiceBus;

namespace FireOnWheels.Web.Handlers
{
    public class OrderProcessedEventHandler: IHandleMessages<OrderProcessedMessage>
    {
        public void Handle(OrderProcessedMessage message)
        {
        }
    }
}
