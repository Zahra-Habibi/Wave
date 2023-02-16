using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Final_Wave.Core.ViewModels.ChatMessageViewModel;
using static Final_Wave.Core.ViewModels.NotationViewModel;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public MessageController(INotyfService NOTY, IUnitOfWork unit, UserManager<ApplicationUser> user, IMapper mapper)
        {
            _context = unit;
            _userManager = user;
            _mapper = mapper;
            _notify = NOTY;
        }
        public async Task<IActionResult> Index()
        {
            var notations = await _context.ChatMessageUW.GetEntitiesAsync(x => x.UserID_Creator == _userManager.GetUserId(HttpContext.User), null, "User_Creator");
            return View(notations);
        }

        public async Task<IActionResult> GetMessage()
        {
            return View(); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetMessage(MessageSentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            ChatMessage message = new ChatMessage
            {
                Text = model.Text,
                Title = model.Title,
                CreatTime = DateTime.Now,
                UserID_Creator = _userManager.GetUserId(HttpContext.User),
                UserID_Reciever = model.UserID_Reciever
            };
            await _context.ChatMessageUW.Create(message);
            await _context.saveAsync();

            _notify.Success("You successfuly Sent the message !", 5);
            return RedirectToAction(nameof(Index));
        }
    }
}
