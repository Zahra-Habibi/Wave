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
    public class SocialController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public SocialController(IUnitOfWork context,IMapper mapper, INotyfService noty)
        {
            _context=context;
            _mapper=mapper;
            _notify=noty;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var social = await _context.socialUW.GetEntitiesAsync();
            return View(social);
        }



        [HttpGet]
        public async Task<IActionResult> AddSocial()
        {
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSocial(SocialViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/Social/" + UploadFiles.CreateImg(file, "Social");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            Social social = new Social
            {
                SocialName = model.SocialName,
                SocialLink = model.SocialLink,
                SocailImg =imgname,
                Title = model.Title,
                Alt = model.Alt,
            };
            await _context.socialUW.Create(social);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  !", 5);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> EditSocial(int id)
        {
            Social social = await _context.socialUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<SocialViewModel>(social);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSocial(SocialViewModel social, IFormFile file)
        {

            if (file != null)
            {
                string imgname = "Img/Social/" + UploadFiles.CreateImg(file, "Social");

                bool DeleteImage = UploadFiles.DeleteImg("Social", social.SocailImg);
                social.SocailImg = imgname;
            }

            //if (!ModelState.IsValid)
            //    return View(about);

            var ser = await _context.socialUW.GetByIdAsync(social.Id);
            var mapModel = _mapper.Map(social, ser);
            _context.socialUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited !", 5);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int id)
        {
            var about = await _context.socialUW.GetByIdAsync(id);
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
        public async Task<IActionResult> Delete(Social model)
        {

            if (model.IsDelete)
            {
                model.IsDelete = false;
            }
            else
            {
                model.IsDelete = true;
            }
            _context.socialUW.Update(model);
            await _context.saveAsync();
            _notify.Error("You  changed the info of Social page!", 5);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Detials(int id)
        {
            var social = await _context.socialUW.GetByIdAsync(id);
            _notify.Information("You checked all the information of Social page !", 5);
            return View(social);
        }



    }
}
