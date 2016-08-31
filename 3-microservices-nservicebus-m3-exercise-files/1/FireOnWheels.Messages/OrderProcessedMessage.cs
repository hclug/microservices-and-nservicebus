using NServiceBus;

namespace FireOnWheels.Messages
{
    public class OrderProcessedMessage: IMessage
    {
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}