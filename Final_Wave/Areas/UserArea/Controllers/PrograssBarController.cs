using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class PrograssBarController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public PrograssBarController(INotyfService NOTY, IUnitOfWork unit, UserManager<ApplicationUser> user, IMapper mapper)
        {
            _context = unit;
            _userManager = user;
            _mapper = mapper;
            _notify = NOTY;
        }
        public async Task<IActionResult> Index()
        {
            var notations = await _context.PrograssUW.GetEntitiesAsync(x => x.UserID_Reciever == _userManager.GetUserId(HttpContext.User), null, "User_Creator");
            return View(notations);
        }
    }
}
