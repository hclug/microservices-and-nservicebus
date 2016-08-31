using FireOnWheels.Messages;
using NServiceBus;

namespace FireOnWheels.OrderActivity
{
    public class OrderActivityHandler: IHandleMessages<IOrderActivityEvent>
    {
        public void Handle(IOrderActivityEvent message)
        {
            //store activity
        }
    }
}
