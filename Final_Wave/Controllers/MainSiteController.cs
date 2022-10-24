using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Controllers
{
    public class MainSiteController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly INotyfService _notify;
        private readonly IMapper _mapper;
        private readonly IProductRepasitory _product;
        public MainSiteController(IUnitOfWork context, INotyfService noty,IMapper mapper, IProductRepasitory product)
        {
            _context = context;
            _notify = noty;
            _mapper = mapper;
            _product = product;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Home()
        {
            return View();
        }

        public async Task<IActionResult> ServiceDetials(int id)
        {
            var service = await _context.serviceUW.GetByIdAsync(id);
            return View(service);
        }

        public async Task<IActionResult> ShowService()
        {
            var service = await _context.serviceUW.GetEntitiesAsync();
            return View(service);
        }

        //product
        public async Task<IActionResult> Product()
        {
            var product = await _context.productUW.GetEntitiesAsync();
            return View(product);
        }

        public async Task<IActionResult> ProductDetails(int id)
        {
            var product = await _context.productUW.GetByIdAsync(id);
            return View(product);
        }


        //team
        public async Task<IActionResult> Team()
        {
            var team = await _context.teamUW.GetEntitiesAsync();
            return View(team);
        }

        //about
        public async Task<IActionResult> About()
        {
            var about = await _context.AboutUW.GetEntitiesAsync();
            return View(about);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(ContactViewModel contact)
        {
            //if (!ModelState.IsValid) return View(contact);
            var mapModel = _mapper.Map<ContactUs>(contact);
            await _context.conductUW.Create(mapModel);
            await _context.saveAsync();
            _notify.Success("Your message was sent successfuly!");
            return RedirectToAction(nameof(Contact));
        }

        [Authorize]
        public async Task<IActionResult> Order()
        {
            ViewBag.ProductId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Order(OrderViewModel model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);
            ViewBag.ProductId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ");
            Order order = new Order
            {
                Name = model.Name,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
               Description = model.Description,
               OrderTime=DateTime.Now,
               UserId = model.UserId,
               ProductId=model.ProductId

            };
            await _context.orderUW.Create(order);
            await _context.saveAsync();
            _notify.Success("You Have new order!", 10);
            return RedirectToAction(nameof(Contact));
        }

        //job
        [HttpGet]
        public async Task<IActionResult> AddJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(JobViewModel model, IFormFile file, IFormFile file1)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            if (file == null)
            {
                ModelState.AddModelError("Image", "Please choose an image .");
                return View(model);

            }
            if(file1 == null)
            {
                ModelState.AddModelError("resume", "Please choose your Resume .");
                return View(model);
            }

            string imgname = "Img/Job/" + UploadFiles.CreateImg(file, "Job");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }

            string imgname1 = "Img/Resume/" + UploadFiles.CreateImg(file1, "Resume");
            if (imgname1 == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }

            Job jabb = new Job
            {
                Name = model.Name,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                Image = imgname,
                Resume = imgname1,
                Description = model.Description,
                JobName = model.JobName,

            };
            await _context.JobUW.Create(jabb);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  !", 5);
            return RedirectToAction(nameof(AddJob));
        }





    }
}
