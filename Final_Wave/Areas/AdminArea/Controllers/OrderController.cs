using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
   // [Authorize]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        private readonly IProductRepasitory _productRepository;
        public OrderController(IUnitOfWork context, IMapper mapper, INotyfService notify, IProductRepasitory productRepository)
        {
            _context = context;
            _mapper = mapper;
            _notify = notify;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var order = await _context.orderUW.GetEntitiesAsync();
            return View(order);
        }

        public async Task<IActionResult> AddOrder()
        {
            ViewBag.CategoryId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ", "CategoryId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(OrderViewModel model)
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



        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.orderUW.GetByIdAsync(id);
            _notify.Information("You checked all the information of order page !", 5);
            return View(order);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ", "CategoryId");
            Order order = await _context.orderUW.GetByIdAsync(id);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Order model)
        {

            if (!ModelState.IsValid)
                return View(model);
            ViewBag.CategoryId = new SelectList(await _context.productUW.GetEntitiesAsync(), "Id", "ProductName", "ProductImage ", "CategoryId");
            _context.orderUW.Update(model);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited the socialMedia!", 5);
            return RedirectToAction(nameof(Index));
        }
    }
}
