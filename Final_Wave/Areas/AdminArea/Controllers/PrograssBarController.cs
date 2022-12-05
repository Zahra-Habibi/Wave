using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class PrograssBarController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public PrograssBarController(UserManager<ApplicationUser> userManager,IUnitOfWork unitOfWork,IMapper mapper,INotyfService NOTY)
        {
            _userManager = userManager;
            _context = unitOfWork;
            _mapper = mapper;
            _notify = NOTY;
        }

        public async Task<IActionResult> Index(int id)
        {
            var order = await _context.orderUW.GetEntitiesAsync();
            ViewBag.order = id;
            var mapModel = _mapper.Map<IEnumerable<OrderViewModel>>(order);
            return View(mapModel);
        }

        public async Task<IActionResult> AddPrograss(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPrograss(PrograssBarViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            model.UserId = _userManager.GetUserId(HttpContext.User);
            model.OrderTime = DateTime.Now;
            var mapModel = _mapper.Map<PrograssBar>(model);
            await _context.PrograssUW.Create(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfully orderd!", 5);
            return RedirectToAction(nameof(Order));
        }
    }
}
