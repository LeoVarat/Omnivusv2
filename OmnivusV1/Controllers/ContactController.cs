using Microsoft.AspNetCore.Mvc;

namespace OmnivusV1.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
