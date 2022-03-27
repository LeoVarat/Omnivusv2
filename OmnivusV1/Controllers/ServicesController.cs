using Microsoft.AspNetCore.Mvc;

namespace OmnivusV1.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
