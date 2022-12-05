using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static Final_Wave.Core.ViewModels.NotationViewModel;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class NotationController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public NotationController(INotyfService NOTY ,IUnitOfWork unit, UserManager<ApplicationUser> user,IMapper mapper)
        {
            _context = unit;
            _userManager = user;
            _mapper = mapper;
            _notify = NOTY;
        }
        public async Task<IActionResult> Index()
        {

            ViewBag.UserID_Creator = _userManager.GetUserId(HttpContext.User);
            ViewBag.userId_Reciever = new SelectList(await _context.UserUW.GetEntitiesAsync(), "Id", "FullName", "usrimag ");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Index(SentNotationListViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ViewBag.userId_Reciever = new SelectList(await _context.UserUW.GetEntitiesAsync(), "Id", "FullName", "usrimag ");
            model.UserID_Creator = _userManager.GetUserId(HttpContext.User);
            model.NotationDate = DateTime.Now;
            var mapModel = _mapper.Map<Notation>(model);
            await _context.NotationUW.Create(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfully orderd!", 5);
            return RedirectToAction(nameof(Index)); ;


        }

    }
}