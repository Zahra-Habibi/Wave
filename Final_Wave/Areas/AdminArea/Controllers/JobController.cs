using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class JobController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        private readonly IProductRepasitory _productRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public JobController(IUnitOfWork context, IMapper mapper, INotyfService notify, IProductRepasitory repasitory, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _notify = notify;
            _productRepository = repasitory;
            _webHostEnvironment = environment;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var job = await _context.JobUW.GetEntitiesAsync();
            return View(job);
        }

        [HttpGet]
        public async Task<IActionResult> AddJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(JobViewModel viewmodel, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            if (file == null)
            {
                ModelState.AddModelError("Image", "Please choose an image for product.");
                return View(viewmodel);

            }


            viewmodel.Date = DateTime.Now;
            var imagename = "Img/Job/" + UploadFiles.CreateImg(file, "Job");
            var mapModel = _mapper.Map<Job>(viewmodel);
            mapModel.Image = imagename;
            await _context.JobUW.Create(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfully Requested!", 5);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Job job = await _context.JobUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<JobViewModel>(job);
            return View(mapUser);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobViewModel viewmodel)
        {
            if (!ModelState.IsValid)
                return View(viewmodel);

            var ser = await _context.JobUW.GetByIdAsync(viewmodel.Id);
            var mapModel = _mapper.Map(viewmodel, ser);
            _context.JobUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited!", 5);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Job job = await _context.JobUW.GetByIdAsync(id);
            if (job.IsDelete)
            {
                ViewBag.Message = "You are actvating this information!";
            }
            else
            {
                ViewBag.Message = "You are InActvating it! , you can always undo";
            }
            return View(job);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Job model)
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
                _context.JobUW.Update(model);
                await _context.saveAsync();
                _notify.Error("You  changed the job state!", 5);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        public async Task<IActionResult> Detials(int id)
        {
            var job = await _context.JobUW.GetByIdAsync(id);
            _notify.Information("You checked all the job !", 5);
            return View(job);
        }


        public async Task<IActionResult> IsRead(int id)
        {

            var read =  await _context.JobUW.GetByIdAsync(id);
            if (read.IsRead)
            {
                ViewBag.Message1 = "Are you suer , you want to accept this user?";
            }
            else
            {
                ViewBag.Message1 = "You can change your decision.";
            }
            return View(read);
        }



        [HttpPost]
        public async Task<IActionResult> IsRead(Job model1)
        {
            if (ModelState.IsValid)
            {
                if (model1.IsRead)
                {
                    model1.IsRead = false;
                }
                else
                {
                    model1.IsRead = true;
                }
                _context.JobUW.Update(model1);
                await _context.saveAsync();
                _notify.Success("You  changed the job accepting!", 5);
                return RedirectToAction(nameof(Index));
            }
            return View(model1);
        }



    }
}
