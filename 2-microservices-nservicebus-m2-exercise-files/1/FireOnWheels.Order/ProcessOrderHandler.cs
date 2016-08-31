using FireOnWheels.Messages;
using FireOnWheels.Order.Helper;
using NServiceBus;
using NServiceBus.Logging;

namespace FireOnWheels.Order
{
    public class ProcessOrderHandler:IHandleMessages<ProcessOrderCommand>
    {

        public ProcessOrderHandler(IBus bus)
        {
            
        }
        private static readonly ILog Logger = 
            LogManager.GetLogger(typeof(ProcessOrderHandler));
        public void Handle(ProcessOrderCommand order)
        {
            Logger.InfoFormat("Order received! From address: {0}, To address: {1}", 
                order.AddressFrom, order.AddressTo);
            EmailSender.SendEmailToDispatch(order);
        }
    }
}
