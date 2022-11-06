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
using System.Drawing.Drawing2D;

namespace Final_Wave.Controllers
{
    public class MainSiteController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly INotyfService _notify;
        private readonly IMapper _mapper;
        private readonly IProductRepasitory _product;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MainSiteController(IUnitOfWork context, INotyfService noty, IMapper mapper, IProductRepasitory product, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _notify = noty;
            _mapper = mapper;
            _product = product;
            _webHostEnvironment = webHostEnvironment;
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

        public async Task<IActionResult> ProductDetails(int Id)
        {
            var product = await _context.productUW.GetByIdAsync(Id);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ProductSearch(string text)
        {

            if (text != null)
            {
                var product = await _context.productUW.GetEntitiesAsync(x => x.ProductName.Contains(text));
                ViewBag.text = text;
                return View(product);
            }
            else
            {
                var product = await _context.productUW.GetEntitiesAsync();
                return View(product);
            }

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
            ViewBag.CategoryId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ", "CategoryId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Order(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            ViewBag.CategoryId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ", "CategoryId");
            model.OrderTime = DateTime.Now;
            var mapModel = _mapper.Map<Order>(model);
            await _context.orderUW.Create(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfully orderd!", 5);
            return RedirectToAction(nameof(Order));

        }

        //job
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

            string imgname = "Img/Resume/" + UploadFiles.CreateImg(file, "Resume");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));

            }
            Job slider = new Job
            {
                Name = viewmodel.Name,
                LastName = viewmodel.LastName,
                Date = DateTime.Now,
                Description = viewmodel.Description,
                EmailAddress = viewmodel.EmailAddress,
                JobName = viewmodel.JobName,
                PhoneNumber = viewmodel.PhoneNumber,
                Resume = imgname,
            };
            await _context.JobUW.Create(slider);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  a slider !", 5);
            return RedirectToAction(nameof(AddJob));

        }

    }
}