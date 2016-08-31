using NServiceBus;
using ServiceControl.Contracts;

namespace FireOnWheels.Monitoring
{
    public class MessageFailedHandler: IHandleMessages<MessageFailed>
    {
        public void Handle(MessageFailed message)
        {
            string failedMessageId = message.FailedMessageId;
            string exceptionMessage = message.FailureDetails.Exception.Message;

            //notify
        }
    }
}
