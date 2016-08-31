using FireOnWheels.Messages;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Saga;

namespace FireOnWheels.Saga
{
    public class ProcessOrderSaga: Saga<ProcessOrderSagaData>,
        IAmStartedByMessages<ProcessOrderCommand>,
        IHandleMessages<IOrderPlannedMessage>,
        IHandleMessages<IOrderDispatchedMessage>
    {
        private static readonly ILog Logger =
              LogManager.GetLogger(typeof(ProcessOrderSaga));
        protected override void ConfigureHowToFindSaga
            (SagaPropertyMapper<ProcessOrderSagaData> mapper)
        {
            mapper.ConfigureMapping<ProcessOrderCommand>(msg => msg.OrderId)
                .ToSaga(s => s.OrderId);
        }

        public void Handle(ProcessOrderCommand message)
        {
            Logger.InfoFormat("ProcessOrder command received. Starting saga for orderid {0}."
                , message.OrderId);
            Data.OrderId = message.OrderId;
            Data.AddressFrom = message.AddressFrom;
            Data.AddressTo = message.AddressTo;
            Data.Price = message.Price;
            Data.Weight = message.Weight;
            Bus.Send(new PlanOrderCommand{AddressTo = Data.AddressTo});
        }

        public void Handle(IOrderPlannedMessage message)
        {
            Logger.InfoFormat("Order {0} has been planned. Sending dispatch command.", 
                Data.OrderId);
            Bus.Send(new DispatchOrderCommand
            {
                AddressTo = Data.AddressTo,
                Weight = Data.Weight
            });
        }

        public void Handle(IOrderDispatchedMessage message)
        {
            Logger.InfoFormat("Order {0} has been dispatched. Notifying originator and ending saga.",
                Data.OrderId);
            ReplyToOriginator(new OrderProcessedMessage());
            MarkAsComplete();
        }
    }
}
