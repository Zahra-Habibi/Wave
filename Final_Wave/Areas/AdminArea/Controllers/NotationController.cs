using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Migrations;
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
            var notations = await _context.NotationUW.GetEntitiesAsync(x => x.UserID_Creator == _userManager.GetUserId(HttpContext.User), null, "User_Creator");
            return View(notations);
        }

        public async Task<IActionResult> GetNotation(int orderId)
        {
            var order = await _context.orderUW.GetByIdAsync(orderId);
            ViewBag.orderId = order.Id;
            ViewBag.reciever = order.UserId;
            return View(); ;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetNotation(NotationSentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            Notation notation = new Notation
            {
                NotationContent = model.NotationContent,
                NotationTitle = model.NotationTitle,
                NotationDate = DateTime.Now,
               UserID_Creator = _userManager.GetUserId(HttpContext.User),
               UserID_Reciever = model.UserID_Reciever
            };
            await _context.NotationUW.Create(notation);
            await _context.saveAsync();

            _notify.Success("You successfuly Sent  !", 5);
            return RedirectToAction(nameof(Index));
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


        public async Task<IActionResult> Read(int id)
        {
            var notation = await _context.NotationUW.GetByIdAsync(id);
            notation.IsAccept = true; 
            _notify.Information("You checked all the notation !", 5);
            return View(notation);
        }
    }
}