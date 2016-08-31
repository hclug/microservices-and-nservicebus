using System.Web.Http;
using FireOnWheelsStage1.Helper;
using FireOnWheelsStage1.Models;

namespace DispatchService.Controllers
{
    public class DispatchController : ApiController
    {
        public void Post(Order order)
        {
            EmailSender.SendEmailToDispatch(order);
        }

    }
}