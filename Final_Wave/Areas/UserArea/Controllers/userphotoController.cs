using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class userphotoController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public userphotoController(UserManager<ApplicationUser> usermanager, IUnitOfWork context, IMapper mapper, INotyfService notify)
        {
            _usermanager = usermanager;
            _context = context;
            _mapper = mapper;
            _notify = notify;
        }

        public async Task<IActionResult> changefoto(string? userId)
        {
            if (userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var user = await _context.UserUW.GetByIdAsync(userId);
            var mapuser = _mapper.Map<UserViewModel>(user);
            return View(mapuser);
        }

        [HttpPost]
        public async Task<IActionResult> changefoto(UserViewModel model, IFormFile file)
        {
                if (file != null)
                {
                    string imgname = "Img/UserProfile/" + UploadFiles.CreateImg(file, "UserProfile");

                    bool DeleteImage = UploadFiles.DeleteImg("UserProfile", model.usrimag);
                    model.usrimag = imgname;
                }
                var user = await _usermanager.FindByIdAsync(model.Id);
                IdentityResult result = await _usermanager.UpdateAsync(_mapper.Map(model, user));
                if (!result.Succeeded)
                {
                    return View(model);
                }
                _notify.Success("You successfuly Edited !", 5);

                 return RedirectToAction("Index", "UserHome");
  
        }
    }
}
