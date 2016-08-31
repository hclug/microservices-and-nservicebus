using NServiceBus;

namespace FireOnWheels.Messages
{
    public interface IOrderProcessedEvent: IOrderActivityEvent
    {
    }
}