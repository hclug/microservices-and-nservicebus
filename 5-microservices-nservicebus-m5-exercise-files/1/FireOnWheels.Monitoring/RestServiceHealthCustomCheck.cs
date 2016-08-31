using System;
using ServiceControl.Plugin.CustomChecks;

namespace FireOnWheels.Monitoring
{
    public class RestServiceHealthCustomCheck: PeriodicCheck
    {
        public RestServiceHealthCustomCheck(): base("RestServiceHealth", "RestService", TimeSpan.FromMinutes(5))
        {
            
        }

        public override CheckResult PerformCheck()
        {
            //Ping service
            return CheckResult.Failed("REST service not reachable");
        }
    }
}