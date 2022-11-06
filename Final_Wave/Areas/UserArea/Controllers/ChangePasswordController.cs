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
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public ChangePasswordController(UserManager<ApplicationUser> usermanager,IUnitOfWork context,IMapper map,INotyfService noty)
        {
            _usermanager = usermanager;
            _context = context;
            _mapper = map;
            _notify = noty;        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _usermanager.FindByIdAsync(_usermanager.GetUserId(HttpContext.User));
                PasswordVerificationResult passresult = _usermanager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.CurrentPassword);
                if(passresult== PasswordVerificationResult.Success)
                {
                    user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, model.NewPassword);
                    var result = await _usermanager.UpdateAsync(user);
                    if (!result.Succeeded)
                    {
                        ViewBag.msg = "Opps, Somthing wrong!";
                        ViewBag.alt = "alert-danger";
                        return View("ChangePassword");
                    }
                    ViewBag.msg = "Your password successfully changed!";
                    ViewBag.alt = "alert-success";
                    return View("ChangePassword");
                }

                else
                {
                    ViewBag.msg = "The old password is invalid!";
                    ViewBag.alt = "alert-danger";
                    return View("ChangePassword");
                }
            }
            return View(model);
        }

      
    }

}
