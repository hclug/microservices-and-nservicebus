using System;
using NServiceBus;
using ServiceControl.Contracts;

namespace FireOnWheels.Monitoring
{
    public class CustomCheckFailedHandler: IHandleMessages<CustomCheckFailed>
    {
        public void Handle(CustomCheckFailed message)
        {
            //notify
        }
    }
}
