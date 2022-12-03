using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize]
    public class AdministrativeController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IMapper _mapper;
        public AdministrativeController(IUnitOfWork context, UserManager<ApplicationUser> usermanager,
                                 IMapper mapper)
        {
            _context = context;
            _usermanager = usermanager;
            _mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            return View( await  _context.AdministrativeFormUW.GetEntitiesAsync(ad => ad.UserID == _usermanager.GetUserId(HttpContext.User) && ad.AdministrativeFormType == true));
        }




        [HttpGet]
        public IActionResult AddNewDefaultForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewDefaultForm(AdministrativeViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.UserID = _usermanager.GetUserId(HttpContext.User);
                model.AdministrativeFormType = true;
                await _context.AdministrativeFormUW.Create(_mapper.Map<AdministrativeForm>(model));
                await _context.saveAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }





        [HttpGet]
        public async Task<IActionResult> Delete(int AdministrativeFormID)
        {
            if (AdministrativeFormID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var model = _context.AdministrativeFormUW.GetByIdAsync(AdministrativeFormID);
            if (model == null)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            return PartialView("_Deleteform", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> DeleteForm(int AdministrativeFormID)
        {
            if (AdministrativeFormID == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            else
            {
                try
                {
                   await _context.AdministrativeFormUW.DeleteByIdAsync(AdministrativeFormID);
                   await _context.saveAsync();
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    return RedirectToAction("ErrorView", "Home");
                }
            }
        }
    }
}
