using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
