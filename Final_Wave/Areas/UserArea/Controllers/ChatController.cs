using Final_Wave.DataLayer.Contexxt;
using Final_Wave.DataLayer.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<ApplicationUser> _usermager;

        public ChatController(ApplicationContext context, UserManager<ApplicationUser> usermager)
        {
            _context = context;
            _usermager = usermager;
        }
    
        public IActionResult Index()
        {
            return View();
        }
 

    }
}
