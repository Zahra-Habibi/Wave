using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("AdminArea")]
    public class UserHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
