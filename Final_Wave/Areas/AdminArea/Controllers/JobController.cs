using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class JobController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        private readonly IProductRepasitory _productRepository;
        public JobController(IUnitOfWork context, IMapper mapper, INotyfService notify, IProductRepasitory repasitory)
        {
            _context = context;
            _mapper = mapper;
            _notify = notify;
            _productRepository = repasitory;
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
        public async Task<IActionResult> AddJob(JobViewModel model, IFormFile file,IFormFile file1)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (file == null)
            {
                ModelState.AddModelError("Image", "Please choose your image .");
                return View(model);

            }

            string imgname = "Img/Job/" + UploadFiles.CreateImg(file, "Job");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }

            if (file1 == null)
            {
                ModelState.AddModelError("Resume", "Please choose your resume.");
                return View(model);

            }
            string imgname1 = "Img/Resume/" + UploadFiles.CreateImg(file1, "Resume");
            if (imgname1 == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
           
            Job jabb = new Job
            {
                Name=model.Name,
                LastName=model.LastName,
                PhoneNumber=model.PhoneNumber,
                EmailAddress=model.EmailAddress,
                Image=imgname,
                Resume=imgname1,
                Description=model.Description,
                JobName=model.JobName,
        
            
        };
            await _context.JobUW.Create(jabb);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  !", 5);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Job jobs = await _context.JobUW.GetByIdAsync(id);
            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobViewModel model, IFormFile file)
        {

            if (file != null)
            {
                string imgname = "Img/Job/" + UploadFiles.CreateImg(file, "Job");
                bool DeleteImage = UploadFiles.DeleteImg("Job", model.Image);
                model.Image = imgname;
            }

          if(file != null)
            {
                string imgname1 = "Img/Resume/" + UploadFiles.CreateImg(file, "Resume");
                bool DeleteImages = UploadFiles.DeleteImg("Resume", model.Resume);
                model.Resume = imgname1;
            }

            var ser = await _context.JobUW.GetByIdAsync(model.Id);
            var mapModel = _mapper.Map(model, ser);
            _context.JobUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You updated  !", 5);
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



    }
}
