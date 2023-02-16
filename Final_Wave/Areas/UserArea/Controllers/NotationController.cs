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
    public class NotationController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public NotationController(INotyfService NOTY, IUnitOfWork unit, UserManager<ApplicationUser> user, IMapper mapper)
        {
            _context = unit;
            _userManager = user;
            _mapper = mapper;
            _notify = NOTY;
        }
        public async Task<IActionResult> Index()
        {
            var notations = await _context.NotationUW.GetEntitiesAsync(x => x.UserID_Reciever == _userManager.GetUserId(HttpContext.User), null, "User_Creator");
            return View(notations);
        }

        public async Task<IActionResult> Accept(int notationId)
        {
            var notaton = await _context.NotationUW.GetByIdAsync(notationId);
            notaton.IsAccept = true;
             _context.NotationUW.Update(notaton);
            await _context.saveAsync();
            _notify.Information("You accepted  the notation form !", 5);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Read(int id)
        {
            var notation = await _context.NotationUW.GetByIdAsync(id);
            _notify.Information("You checked all the notation !", 5);
            return View(notation);
        }
    }
}
