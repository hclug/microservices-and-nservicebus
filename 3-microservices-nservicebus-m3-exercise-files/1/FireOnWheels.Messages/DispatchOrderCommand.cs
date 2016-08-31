using NServiceBus;

namespace FireOnWheels.Messages
{
    public class DispatchOrderCommand : ICommand
    {
        public string AddressTo { get; set; }
        public int Weight { get; set; }
    }
}