﻿using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public JobController(IUnitOfWork context, IMapper mapper, INotyfService notify, IProductRepasitory repasitory,IWebHostEnvironment environment)
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
        public async Task<IActionResult> AddJob(JobViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (viewmodel.Coverphoto != null)
                {
                    string folder = "Img/Job/";
                    viewmodel.Image = await UploadImage(folder, viewmodel.Coverphoto);
                }
                if (viewmodel.ResumePhoto != null)
                {
                    string folder = "Img/Resume/";
                    viewmodel.Resume = await UploadImage(folder, viewmodel.ResumePhoto);
                }

                Job job = new Job()
                {
                    Name = viewmodel.Name,
                    Image = viewmodel.Image,
                    Description = viewmodel.Description,
                    EmailAddress = viewmodel.EmailAddress,
                    JobName = viewmodel.JobName,
                    LastName = viewmodel.LastName,
                    Resume = viewmodel.Resume,
                    PhoneNumber = viewmodel.PhoneNumber,
                    Date = DateTime.Now,

                };

                await _context.JobUW.Create(job);
                await _context.saveAsync();
                _notify.Success("You sucessfully send your request    !", 5);
                return RedirectToAction(nameof(AddJob));
            }

            return View(viewmodel);

        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Job jobs = await _context.JobUW.GetByIdAsync(id);
            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                if (viewmodel.Coverphoto != null)
                {
                    string folder = "Img/Job/";
                    viewmodel.Image = await UploadImage(folder, viewmodel.Coverphoto);
                }
                if (viewmodel.ResumePhoto != null)
                {
                    string folder = "Img/Resume/";
                    viewmodel.Resume = await UploadImage(folder, viewmodel.ResumePhoto);
                }

                Job job = new Job()
                {
                    Name = viewmodel.Name,
                    Image = viewmodel.Image,
                    Description = viewmodel.Description,
                    EmailAddress = viewmodel.EmailAddress,
                    JobName = viewmodel.JobName,
                    LastName = viewmodel.LastName,
                    Resume = viewmodel.Resume,
                    PhoneNumber = viewmodel.PhoneNumber,
                    Date = DateTime.Now,

                };

                await _context.JobUW.Create(job);
                await _context.saveAsync();
                _notify.Success("You sucessfully send your request    !", 5);
                return RedirectToAction(nameof(AddJob));
            }

            return View(viewmodel);


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
