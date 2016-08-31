using NServiceBus;

namespace FireOnWheels.Messages
{
    public class ProcessOrderCommand: ICommand
    {
        public string AddressFrom { get; set; }
        public string AddressTo { get; set; }
        public int Weight { get; set; }
        public int Price { get; set; }
    }
}
