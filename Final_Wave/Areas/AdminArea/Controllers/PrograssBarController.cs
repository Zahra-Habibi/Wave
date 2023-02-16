using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
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
            var prograss = await _context.PrograssUW.GetEntitiesAsync(x => x.UserID_Creator == _userManager.GetUserId(HttpContext.User), null, "User_Creator");
            return View(prograss);
        }

        public async Task<IActionResult> AddPrograss(int orderId)
        {
             var order = await _context.orderUW.GetByIdAsync(orderId);
            ViewBag.orderId = order.Id;
            ViewBag.reciever = order.UserId;
            return View(); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPrograss(PrograssBarViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            PrograssBar prograss = new PrograssBar
            {
                Requirement = model.Requirement,
                Design=model.Design,
                Maintenance=model.Maintenance,
                Testing=model.Testing,
                Codind=model.Codind,
                OrderTime=model.OrderTime,
                UserID_Creator = _userManager.GetUserId(HttpContext.User),
                UserID_Reciever = model.UserID_Reciever
            };
            await _context.PrograssUW.Create(prograss);
            await _context.saveAsync();
            _notify.Success("You successfuly Sent prograss  !", 5);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var prograss = await _context.PrograssUW.GetByIdAsync(id);
            var maper=_mapper.Map<PrograssBar>(prograss);
            return View(maper); ;

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PrograssBarViewModel model)
        {



            if (!ModelState.IsValid)
                return View(model);

            PrograssBar prograss = new PrograssBar
            {
                PrograssId=model.PrograssId,
                Requirement = model.Requirement,
                Design = model.Design,
                Maintenance = model.Maintenance,
                Testing = model.Testing,
                Codind = model.Codind,
                OrderTime = model.OrderTime,
                UserID_Creator = _userManager.GetUserId(HttpContext.User),
                UserID_Reciever = model.UserID_Reciever
            };
            _context.PrograssUW.Update(prograss);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited !", 5);
            return RedirectToAction(nameof(Index));
        }

    }
}
