using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.PulicClasses;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Final_Wave.DataLayer.Repository.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        private readonly IProductRepasitory _productRepository;
        private readonly IProductPrice _productservice;
        public ProductController(IUnitOfWork context, IMapper mapper, INotyfService notify, IProductRepasitory productRepository, IProductPrice productservice)
        {
            _context = context;
            _mapper = mapper;
            _notify = notify;
            _productRepository = productRepository;
            _productservice = productservice;
        }

        public async Task<IActionResult> ShowProduct()
        {
            return View(await _context.productUW.GetEntitiesAsync());
        }



        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.CategoryId = new SelectList(await _context.categoryUW.GetEntitiesAsync(), "Id", "CategoryName", "CategoryPhoto ");
            

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (file == null)
            {
                ModelState.AddModelError("ProductImage", "Please choose an image for product.");
                return View(model);

            }

            if (await _productRepository.GetProductByProductNameAsync(model.ProductName, 0))
            {
                ModelState.AddModelError("ProductName", "This product is already available in the system!");
                ViewBag.CategoryId = new SelectList(await _context.categoryUW.GetEntitiesAsync(), "Id", "CategoryName", "CategoryPhoto ");
                return View(model);
            }

            model.ProductCreate = DateTime.Now;
            var imagename = "Img/Product/" + UploadFiles.CreateImg(file, "Product");
            var mapModel = _mapper.Map<Product>(model);
            mapModel.ProductImage = imagename;
            await _context.productUW.Create(mapModel);
            await _context.saveAsync();
            _notify.Success("You Added a new product    !", 5);
            return RedirectToAction(nameof(ShowProduct));

        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.CategoryId = new SelectList(await _context.categoryUW.GetEntitiesAsync(), "Id", "CategoryName", "CategoryPhoto ");
            Product product = await _context.productUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<ProductViewModel>(product);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model, IFormFile file)
        {

            if (!ModelState.IsValid)
                return View(model);

            if (await _productRepository.GetProductByProductNameAsync(model.ProductName, model.Id))
            {
                ModelState.AddModelError("Name", "This product is already available in the system!");
                ViewBag.CategoryId = new SelectList(await _context.categoryUW.GetEntitiesAsync(), "Id", "CategoryName", "CategoryPhoto ");
                return View(model);
            }

            if (file != null)
            {
                string imgname = "Img/Product/" + UploadFiles.CreateImg(file, "Product");
                bool DeleteImage = UploadFiles.DeleteImg("Product", model.ProductImage);
                model.ProductImage = imgname;
            }
            var ser = await _context.productUW.GetByIdAsync(model.Id);
            var mapModel = _mapper.Map(model, ser);
            _context.productUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You updated  the product !", 5);
            return RedirectToAction(nameof(ShowProduct));

        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.productUW.GetByIdAsync(id);
            if (product.IsDelete)
            {
                ViewBag.Message = "You are actvating this product!";
            }
            else
            {
                ViewBag.Message = "You are InActvating this product! , you can always undo";
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Product model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.IsDelete)
            {
                model.IsDelete = false;
            }
            else
            {
                model.IsDelete = true;
            }
            _context.productUW.Update(model);
            await _context.saveAsync();
            _notify.Error("You  changed the product state!", 5);
            return RedirectToAction(nameof(ShowProduct));
        }



        public async Task<IActionResult> Detials(int id)
        {
            var product = await _context.productUW.GetByIdAsync(id);
            _notify.Information("You checked all the information of product page !", 5);
            return View(product);
        }


        //add pricce

        public async Task<IActionResult> ShowAllPrice(int id)
        {
            var product = await _context.productUW.GetByIdAsync(id);
            _notify.Information("You checked all the product price !", 5);
            return View(product);
        }

        public IActionResult AddPrice(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddPrice(ProductPrice productPrice)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.id = productPrice.ProductId;
                return View(productPrice);
            }
            productPrice.CreatDate = DateTime.Now;
            int priceid = _productservice.AddPriceForProduct(productPrice);
            TempData["Result"] = priceid > 0 ? "true" : "false";
            return RedirectToAction(nameof(ShowProduct));

        }
    }
}
