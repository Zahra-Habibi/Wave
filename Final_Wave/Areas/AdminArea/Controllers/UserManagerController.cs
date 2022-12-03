using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Contexxt;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using NuGet.Protocol.Plugins;
using Polly;
using System.Security.Claims;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class UserManagerController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly INotyfService _notify;
        private readonly ApplicationContext _contexts;
        private readonly IProductRepasitory _usermessage;
        public UserManagerController(IUnitOfWork context, IMapper mapper, UserManager<ApplicationUser> manager, INotyfService service,ApplicationContext co, IProductRepasitory usermessage)
        {
            _context = context;
            _mapper = mapper;
            _usermanager = manager;
            _notify = service;
            _contexts = co;
            _usermessage = usermessage;
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
        public async Task<IActionResult> AddUser(UserViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/UserProfile/" + UploadFiles.CreateImg(file, "UserProfile");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(AddUser));
            }
            if (file == null)
            {
                ModelState.AddModelError("usrimag", "Please choose your image.");
                return View(model);

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
                IsActive = model.IsActive,
                IsAdmin = model.IsAdmin,
                usrimag = imgname,
                IsDelete = false,
            };


            IdentityResult result = await _usermanager.CreateAsync(user, model.PasswordHash);
            if (result.Succeeded)
            {
                _notify.Success("You successfuly added a new user  !");
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
        public async Task<IActionResult> EditUser(UserViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);
 
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
              return RedirectToAction("Index", "UserManager");
        }

        public async Task<IActionResult> UserDetails(string userId)
        {
            var model = await _context.UserUW.GetByIdAsync(userId);
            _notify.Information("You checked all the information  !", 5);
            return View(model);
        }

        public async Task<IActionResult> Delete(string userId)
        {
            var team = await _context.UserUW.GetByIdAsync(userId);
            if (team.IsDelete)
            {
                ViewBag.Message = "You are actvating this information!";
            }
            else
            {
                ViewBag.Message = "You are InActvating it! , you can always undo";
            }
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ApplicationUser model)
        {

            if (model.IsDelete)
            {
                model.IsDelete = false;
            }
            else
            {
                model.IsDelete = true;
            }
            _context.UserUW.Update(model);
            await _context.saveAsync();
            _notify.Error("You  changed the status!", 5);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public IActionResult ChangePassword(string id , string UserName)
        {
            if(id == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            ViewBag.Id = id;
            ViewBag.UserName = UserName;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordByAdminViewModel model)
        {
           if (!ModelState.IsValid)
             return View(model);

            var user = await _usermanager.FindByIdAsync(model.Id);
            user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, model.NewPassword);
            var result = await _usermanager.UpdateAsync(user);
            await _context.saveAsync();
            _notify.Information("You  changed the User Password!", 5);
            return RedirectToAction(nameof(Index));

 
        }





        //chat
        public IActionResult AdvancedChat()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ChatVM chatVm = new()
            {
                Rooms = _contexts.chatRooms.ToList(),
                MaxRoomAllowed = 4,
                UserId = userId,
            };
            return View(chatVm);
        }

        public IActionResult Notification()
        {
            return View();
        }
    }
}
