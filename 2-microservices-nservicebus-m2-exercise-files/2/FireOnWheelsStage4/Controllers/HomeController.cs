using System.Web.Mvc;
using FireOnWheels.Messages;
using FireOnWheels.Web.Helper;
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
            order.Price = PriceCalculator.GetPrice(order);
            return View("Review", order);
        }

        public ActionResult Confirm(Order order)
        {
            ServiceBus.Bus.Send("fireonwheels.order", new ProcessOrderCommand
            {
                AddressFrom = order.AddressFrom,
                AddressTo = order.AddressTo,
                Price = order.Price,
                Weight = order.Weight
            });

            return View();
        }
    }
}
