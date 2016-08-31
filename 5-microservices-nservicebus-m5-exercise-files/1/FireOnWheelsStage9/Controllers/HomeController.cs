using System;
using System.Web.Mvc;
using FireOnWheels.Messages;
using NServiceBus;
using Order = FireOnWheels.Web.Models.Order;

namespace FireOnWheels.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Order order)
        {
            var callback = ServiceBus.Bus.Send(new PriceRequest { Weight = order.Weight })
                .Register(result =>
                {
                    var localResult = (CompletionResult)result.AsyncState;
                    var reply = (PriceResponse)localResult.Messages[0];
                    order.Price = reply.Price;
                }, null);
            callback.AsyncWaitHandle.WaitOne();

            return View("Review", order);
        }

        public ActionResult Confirm(Order order)
        {
            ServiceBus.Bus.Send(new ProcessOrderCommand
            {
                OrderId = Guid.NewGuid(),
                AddressFrom = order.AddressFrom,
                AddressTo = order.AddressTo,
                Price = order.Price,
                Weight = order.Weight
            });

            return View();
        }
    }
}
