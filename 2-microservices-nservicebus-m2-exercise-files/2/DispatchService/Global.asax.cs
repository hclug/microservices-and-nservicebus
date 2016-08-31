using System.Web.Http;
using FireOnWheels.Messages;

namespace FireOnWheels.Rest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ServiceBus.Initialize("FireOnWheels.Rest");
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}