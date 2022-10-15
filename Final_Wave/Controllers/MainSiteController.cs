using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Controllers
{
    public class MainSiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
