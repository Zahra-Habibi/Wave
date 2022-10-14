using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
