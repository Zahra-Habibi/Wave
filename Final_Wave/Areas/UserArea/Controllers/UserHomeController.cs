using Final_Wave.DataLayer.Contexxt;
using Final_Wave.DataLayer.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly;
using System.Security.Claims;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class UserHomeController : Controller
    {
        private readonly ApplicationContext _contexts;
        public UserHomeController(ApplicationContext contexts)
        {
            _contexts = contexts;
        }

        public IActionResult Index()
        {
            return View();
        }

        //chat
        [Authorize]
        public IActionResult AdvancedChat()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ChatVM chatVm = new()
            {
                Rooms = _contexts.chatRooms.ToList(),
                MaxRoomAllowed = 4,
                UserId = userId,
            };
            return View(chatVm);
        }
    }
}
