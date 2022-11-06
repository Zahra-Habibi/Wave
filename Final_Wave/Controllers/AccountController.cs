using AspNetCoreHero.ToastNotification.Abstractions;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Controllers
{

    public class AccountController : Controller
    {

        private readonly IUnitOfWork _context;
        private readonly INotyfService _notify;
        private readonly SignInManager<ApplicationUser> _signinmanager;
        private readonly UserManager<ApplicationUser> _usermanager;
        public AccountController( IUnitOfWork context , INotyfService service, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _notify = service;
            _signinmanager = signInManager;
            _usermanager = usermanager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/UserProfile/" + UploadFiles.CreateImg(file, "UserProfile");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Register));
            }

            if (await _usermanager.FindByNameAsync(model.Email) != null)
            {
                ModelState.AddModelError("UserName", "The username is invalid!");
            }
            var user = new ApplicationUser
            {
                FullName = model.FullName,
                UserName = model.Email,
                Email = model.Email,
                PasswordHash = model.PasswordHash,
                IsActive = true,
                IsAdmin = 2,
                usrimag = imgname,
            };
            IdentityResult result = await _usermanager.CreateAsync(user, model.PasswordHash);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));   
            }
            _notify.Success("You successfuly Registerd  !");
            return RedirectToAction(nameof(Login));
            
        }


        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _usermanager.GetUserAsync(HttpContext.User);
                if (user.IsAdmin == 1)
                {
                    return Redirect("/AdminArea/DashBoard/Index");
                }
                else
                {
                    return Redirect("/UserArea/UserHome/Index");
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _usermanager.FindByNameAsync(model.UserName);

                if (user == null)
                {
                    ModelState.AddModelError("Password", "Invaled information!");
                    return View(model);
                }

                    var result = await _signinmanager.PasswordSignInAsync(model.UserName, model.Password, true, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {

                    if (user.IsAdmin == 1)
                    {
                        //Admin
                        return Redirect("/AdminArea/DashBoard/Index");
                    }
                    else if (user.IsAdmin == 2)
                    {
                        //User
                        return Redirect("/MainSite/Home");
                    }

                }
                    else
                    {
                        ModelState.AddModelError("Password" ,"Oops, your information is invalid!  ");
                        return View(model);
                    }

            }

            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signinmanager.SignOutAsync();
            return Redirect("/Account/Login");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
