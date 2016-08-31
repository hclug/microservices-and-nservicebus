using System.Web.Mvc;
using FireOnWheelsStage1.Helper;
using FireOnWheelsStage1.Models;

namespace FireOnWheelsStage1.Controllers
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
            EmailSender.SendEmailToDispatch(order);
            return View();
        }
    }
}
