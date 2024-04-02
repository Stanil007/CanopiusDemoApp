using Microsoft.AspNetCore.Mvc;

namespace CanopiusDemoApp.Controllers
{
    public class PolicyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
