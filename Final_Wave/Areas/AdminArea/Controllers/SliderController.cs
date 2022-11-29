
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
   // [Authorize]
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public SliderController(IUnitOfWork context, IMapper mapper,INotyfService notyfService)
        {
            _context = context;
            _mapper = mapper;
            _notify = notyfService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.sliderUW.GetEntitiesAsync());
        }



        [HttpGet]
        public async Task<IActionResult> AddSlider()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSlider(SliderViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/Slider/" + UploadFiles.CreateImg(file, "Slider");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            Slider slider = new Slider
            {
                silderName = model.silderName,
                Caption = model.Caption,
                Title = model.Title,
                Alt = model.Alt,
                sliderOrder = model.sliderOrder,
                sliderImage = imgname,
            };
            await _context.sliderUW.Create(slider);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  a slider !", 5);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {  
            Slider mainSlider = await _context.sliderUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<SliderViewModel>(mainSlider);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SliderViewModel model, IFormFile file)
        {
            //if (!ModelState.IsValid)
            //    return View(model);


            if (file != null)
            {
                string imgname = "Img/Slider/" + UploadFiles.CreateImg(file, "Slider");
                bool DeleteImage = UploadFiles.DeleteImg("Slider", model.sliderImage);
                model.sliderImage = imgname;
            }
            var ser = await _context.sliderUW.GetByIdAsync(model.SliderId);
            var mapModel = _mapper.Map(model, ser);
            _context.sliderUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited  a  slider!", 5);
            return RedirectToAction(nameof(Index));
        }




        public async Task<IActionResult> Delete(int id)
        {
            Slider mainSlider = await _context.sliderUW.GetByIdAsync(id);
            if (mainSlider.IsDelete)
            {
                ViewBag.Message = "You are actvating this information!";
            }
            else
            {
                ViewBag.Message = "You are InActvating it! , you can always undo";
            }
            return View(mainSlider);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Slider model)
        {
            if (ModelState.IsValid)
            {
                if (model.IsDelete)
                {
                    model.IsDelete = false;
                }
                else
                {
                    model.IsDelete = true;
                }
                _context.sliderUW.Update(model);
                await _context.saveAsync();
                _notify.Error("You  changed the slider state!", 5);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Detials(int id)
        {
            var slider = await _context.sliderUW.GetByIdAsync(id);
            _notify.Information("You checked all the slider !", 5);
            return View(slider);
        }


    }
}
