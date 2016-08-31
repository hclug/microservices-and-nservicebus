using System;
using NServiceBus;

namespace FireOnWheels.Dispatch
{
    /*
		This class configures this endpoint as a Server. More information about how to configure the NServiceBus host
		can be found here: http://particular.net/articles/the-nservicebus-host
	*/
	public class EndpointConfig : IConfigureThisEndpoint
	{
		public void Customize(BusConfiguration configuration)
		{
			if (Environment.UserInteractive)
				Console.Title = "Dispatch";
			configuration.UsePersistence<InMemoryPersistence>();
		}
	}
}
