using System;
using System.Net.Http;
using System.Threading.Tasks;
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

        public async Task<ActionResult> Confirm(Order order)
        {
            var client = new HttpClient {BaseAddress = new Uri("http://localhost:14043/")};
            var response = await client.PostAsJsonAsync("api/Dispatch", order);
            response.EnsureSuccessStatusCode();

            return View();
        }
    }
}
