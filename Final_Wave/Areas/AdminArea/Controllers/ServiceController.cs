using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public ServiceController(IUnitOfWork unitOfWork,IMapper mapper,INotyfService notyf)
        {
            _context = unitOfWork;
            _mapper = mapper;
            _notify = notyf;


        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.serviceUW.GetEntitiesAsync());
        }


        [HttpGet]
        public async Task<IActionResult> AddService()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddService(ServicesViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/Service/" + UploadFiles.CreateImg(file, "Service");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            Service service = new Service
            {
                Name = model.Name,
                Descriptions = model.Descriptions,
                Title = model.Title,
                Alt = model.Alt,
                ImageUrl = imgname,
                ShortDescription = model.ShortDescription,
            };
            await _context.serviceUW.Create(service);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  !", 5);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Service service = await _context.serviceUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<ServicesViewModel>(service);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServicesViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (file != null)
            {
                string imgname = "Img/Service/" + UploadFiles.CreateImg(file, "Service");
                bool DeleteImage = UploadFiles.DeleteImg("Service", model.ImageUrl);
                model.ImageUrl = imgname;
            }
            var ser = await _context.serviceUW.GetByIdAsync(model.Id);
            var mapModel = _mapper.Map(model, ser);
            _context.serviceUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited!", 5);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Service service = await _context.serviceUW.GetByIdAsync(id);
            if (service.IsDelete)
            {
                ViewBag.Message = "You are actvating this information!";
            }
            else
            {
                ViewBag.Message = "You are InActvating it! , you can always undo";
            }
            return View(service);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Service model)
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
                _context.serviceUW.Update(model);
                await _context.saveAsync();
                _notify.Error("You  changed the service state!", 5);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Detials(int id)
        {
            var service = await _context.serviceUW.GetByIdAsync(id);
            _notify.Information("You checked all the service !", 5);
            return View(service);
        }
    }
}
