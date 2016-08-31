using FireOnWheels.Dispatch.Helper;
using FireOnWheels.Messages;
using NServiceBus;

namespace FireOnWheels.Dispatch
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
