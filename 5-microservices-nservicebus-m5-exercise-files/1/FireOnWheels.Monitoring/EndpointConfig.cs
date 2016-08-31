
namespace FireOnWheels.Monitoring
{
    using NServiceBus;
    public class EndpointConfig : IConfigureThisEndpoint
    {
        public void Customize(BusConfiguration configuration)
        {
            configuration.UsePersistence<InMemoryPersistence>();

            configuration.UseSerialization<JsonSerializer>();

            configuration.Conventions()
                .DefiningEventsAs(t => 
                    t.Namespace != null && t.Namespace.StartsWith("ServiceControl.Contracts"));
        }
    }
}
