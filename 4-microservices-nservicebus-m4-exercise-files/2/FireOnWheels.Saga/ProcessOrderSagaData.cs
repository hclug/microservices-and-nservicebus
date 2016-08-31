using System;
using NServiceBus.Saga;

namespace FireOnWheels.Saga
{
    public class ProcessOrderSagaData : ContainSagaData
    {
        //Unique = not needed in version 6 or higher
        [Unique]
        public Guid OrderId { get; set; }
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}