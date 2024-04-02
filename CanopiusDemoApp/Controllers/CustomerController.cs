using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
