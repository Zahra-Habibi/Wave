using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public AboutController(IUnitOfWork context, IMapper mapper, INotyfService notyf)
        {
            _context = context;
            _mapper = mapper;
            _notify=notyf;
                
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var about = await _context.AboutUW.GetEntitiesAsync();
            return View(about);
        }




        [HttpGet]
        public async Task<IActionResult> AddAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAbout(AboutViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/About/" + UploadFiles.CreateImg(file, "About");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            About about = new About
            {
             Address=model.Address,
             Descriptions=model.Descriptions,
             Email=model.Email,
             Title=model.Title,
             PhoneNumber=model.PhoneNumber,
             Image=imgname,
             Alt=model.Alt,
            };
            await _context.AboutUW.Create(about);
            await _context.saveAsync();
           _notify.Success("You successfuly Added  !", 5);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> EditAbout(int id)
        {
            About about = await _context.AboutUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<AboutViewModel>(about);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAbout(AboutViewModel about, IFormFile file)
        {

            if (file != null)
            {
                string imgname = "Img/About/" + UploadFiles.CreateImg(file, "About");

                bool DeleteImage = UploadFiles.DeleteImg("About", about.Image);
                about.Image = imgname;
            }

            //if (!ModelState.IsValid)
            //    return View(about);

            var ser = await _context.AboutUW.GetByIdAsync(about.Id);
            var mapModel = _mapper.Map(about, ser);
            _context.AboutUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited !", 5);
            return RedirectToAction(nameof(Index));
        }





        public async Task<IActionResult> Delete(int id)
        {
            var about = await _context.AboutUW.GetByIdAsync(id);
            if (about.IsDelete)
            {
                ViewBag.Message = "You are actvating this information!";
            }
            else
            {
                ViewBag.Message = "You are InActvating it! , you can always undo";
            }
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(About model)
        {

            if (model.IsDelete)
            {
                model.IsDelete = false;
            }
            else
            {
                model.IsDelete = true;
            }
            _context.AboutUW.Update(model);
            await _context.saveAsync();
            _notify.Error("You  changed the info of about page!", 5);
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Detials(int id)
        {
            var about = await _context.AboutUW.GetByIdAsync(id);
            _notify.Information("You checked all the information of about us page !", 5);
            return View(about);
        }
    }
}
