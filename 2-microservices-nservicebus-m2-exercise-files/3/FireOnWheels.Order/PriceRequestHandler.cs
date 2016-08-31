using FireOnWheels.Messages;
using FireOnWheels.Order.Helper;
using NServiceBus;

namespace FireOnWheels.Order
{
    public class PriceRequestHandler: IHandleMessages<PriceRequest>
    {
        private readonly IBus bus;

        public PriceRequestHandler(IBus bus)
        {
            this.bus = bus;
        }

        public void Handle(PriceRequest message)
        {
            bus.Reply(new PriceResponse 
                {Price = PriceCalculator.GetPrice(message)});
        }
    }
}
