using System.Web.Http;
using FireOnWheels.Messages;
using Order = FireOnWheels.Rest.Models.Order;

namespace FireOnWheels.Rest.Controllers
{
    public class DispatchController : ApiController
    {
        public void Post(Order order)
        {
            ServiceBus.Bus.Send("ProcessOrder", new ProcessOrderCommand
            {
                AddressFrom = order.AddressFrom,
                AddressTo = order.AddressTo,
                Price = order.Price,
                Weight = order.Weight
            });
        }

    }
}