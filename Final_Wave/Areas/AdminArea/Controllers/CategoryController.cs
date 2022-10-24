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
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public CategoryController(IUnitOfWork context, IMapper mapper,INotyfService service)
        {
            _context = context; 
            _mapper = mapper;
            _notify = service;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var category = await _context.categoryUW.GetEntitiesAsync();
            return View(category);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryViewModel model, IFormFile file)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            if (file == null)
            {
                ModelState.AddModelError("CategoryPhoto", "Please choose an image for category.");
                return View(model);

            }

            string imgname = "Img/Category/" + UploadFiles.CreateImg(file, "Category");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            var category = new Category
            {
                CategoryName = model.CategoryName,
                CategoryPhoto = imgname,
                Alt = model.Alt,
                Title = model.Title,

            };
            await _context.categoryUW.Create(category);
            await _context.saveAsync();
            _notify.Success("You successfuly added !", 5);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> EditCategory(int id)
        {
            Category category = await _context.categoryUW.GetByIdAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(Category model, IFormFile file)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            if (file != null)
            {
                string imgname = "Img/Category/" + UploadFiles.CreateImg(file, "Category");
                bool DeleteImage = UploadFiles.DeleteImg("Category", model.CategoryPhoto);
                model.CategoryPhoto = imgname;
            }
            _context.categoryUW.Update(model);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited a category for product!", 5);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.categoryUW.GetByIdAsync(id);
            if (category.IsDelete)
            {
                ViewBag.Message = "You are actvating this Category!";
            }
            else
            {
                ViewBag.Message = "You are InActvating this Category! , you can always undo";
            }
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Category model)
        {
            //if (!ModelState.IsValid)
            //    return View(model);

            if (model.IsDelete)
            {
                model.IsDelete = false;
            }
            else
            {
                model.IsDelete = true;
            }
            _context.categoryUW.Update(model);
            await _context.saveAsync();
            _notify.Error("You  changed the category state !", 5);
            return RedirectToAction(nameof(Index));


        }

    }
}
