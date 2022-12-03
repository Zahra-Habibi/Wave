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
    public class ProductGalleryController : Controller
    {

        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public ProductGalleryController(IUnitOfWork context, IMapper mapper, INotyfService notyf)
        {
            _context = context;
            _mapper = mapper;
            _notify = notyf;

        }
        public async Task<IActionResult> Index(int id)
        {
            var product = await _context.productUW.GetEntitiesAsync();
            ViewBag.ProductId = id;
            var mapModel = _mapper.Map<IEnumerable<ProductViewModel>>(product);
            return View(mapModel);

        }

        public async Task<IActionResult> AddPhoto(int id)
        {
            var product = await _context.productUW.GetByIdAsync(id);
            ViewBag.ProductId = id;
            ViewBag.Photo = product.ProductImage;
            ViewBag.Alt = product.Alt;
            ViewBag.title = product.Title;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPhoto(IFormFile file, ProductGalleryViewModel gallery)
        {
            if (!ModelState.IsValid)
                return View(gallery);

            if (file != null)
            {
                string imgname = "Img/Product/" + UploadFiles.CreateImg(file, "Product");
                if (imgname == "false")
                {
                    return View(gallery);
                }
                var photo = new ProductGallery
                {
                    ImageUrl = imgname,
                    ProductId = gallery.ProductId,
                    Alt = gallery.Alt,
                    Title = gallery.Title,
                };

                await _context.galleryUW.Create(photo);
                await _context.saveAsync();
                _notify.Success("You add a photo for product Gallery  !", 5);
                return RedirectToAction(nameof(AddPhoto));
            }
            return View(gallery);
        }


        public async Task<IActionResult> Delete(int id, string url, int productId)
        {
            var pic = await _context.galleryUW.GetByIdAsync(id);
            UploadFiles.DeleteImg("Product", pic.ImageUrl);
            await _context.galleryUW.DeleteByIdAsync(id);
            await _context.saveAsync();
            ViewBag.ProductId = productId;
            ViewBag.Photo = url;
            _notify.Error("You deleted a photo from product Gallery  !", 5);
            return RedirectToAction(nameof(Index));
        }


    }
}
