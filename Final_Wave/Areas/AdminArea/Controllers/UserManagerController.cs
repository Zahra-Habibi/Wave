using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class UserManagerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly INotyfService _notify;
        public UserManagerController(IUnitOfWork context, IMapper mapper, UserManager<ApplicationUser> manager, INotyfService service)
        {
            _context = context;
            _mapper = mapper;
            _usermanager = manager;
            _notify = service;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _context.UserUW.GetEntitiesAsync();
            return View(model);
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            if (await _usermanager.FindByNameAsync(model.UserName) != null)
                {
                    ModelState.AddModelError("UserName", "The username is invalid!");
                }
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    IsActive = true,
                    IsAdmin = model.IsAdmin,
                };
                IdentityResult result = await _usermanager.CreateAsync(user, model.PasswordHash);
                if (result.Succeeded)
                {             
                    return RedirectToAction(nameof(Index));
                }
            return View(model);
        }



        [HttpGet]
        public  async Task<IActionResult> EditUser(string userId)
        {
           if(userId == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
             var user = await _context.UserUW.GetByIdAsync(userId);
             var mapuser =  _mapper.Map<UserViewModel>(user);
            return View(mapuser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserViewModel model)
        {
           var user = await _usermanager.FindByIdAsync(model.Id);
                IdentityResult result = await _usermanager.UpdateAsync(_mapper.Map(model, user));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "UserManager");
                  _notify.Success("You successfuly Edited !", 5);
            }
            return View(model);
        }



  
        public async Task<IActionResult> UserDetails(string userId)
        {
            var model = await _context.UserUW.GetByIdAsync(userId);
            _notify.Information("You checked all the information  !", 5);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordByAdminViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            var user = await _usermanager.FindByIdAsync(model.Id);
            user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, model.NewPassword);
            var result = await _usermanager.UpdateAsync(user);
            await _context.saveAsync();
            _notify.Information("You  changed the User Password!", 5);
            }
        }
    }
}
