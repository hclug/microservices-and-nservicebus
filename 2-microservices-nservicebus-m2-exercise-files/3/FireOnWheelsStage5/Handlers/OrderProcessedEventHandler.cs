using System;
using FireOnWheels.Messages;
using NServiceBus;

namespace FireOnWheels.Web.Handlers
{
    public class OrderProcessedEventHandler: IHandleMessages<IOrderProcessedEvent>
    {
        public void Handle(IOrderProcessedEvent message)
        {
        }
    }
}
