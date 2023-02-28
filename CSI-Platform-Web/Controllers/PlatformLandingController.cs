using Microsoft.AspNetCore.Mvc;

namespace CSI_Platform_Web.Controllers
{
    public class PlatformLandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
