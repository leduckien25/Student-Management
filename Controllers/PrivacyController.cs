using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
