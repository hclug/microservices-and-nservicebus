using System;
using NServiceBus;

namespace FireOnWheels.Messages
{
    public class PlanOrderCommand: ICommand
    {
        public Guid OrderId { get; set; }
        public string AddressTo { get; set; }
    }
}
