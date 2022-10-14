using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        public ChangePasswordController(UserManager<ApplicationUser> usermanager)
        {
            _usermanager = usermanager;
        }

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
