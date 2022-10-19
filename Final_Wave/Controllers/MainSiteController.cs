using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Controllers
{
    public class MainSiteController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly ApplicationUser _user;
        public MainSiteController(IUnitOfWork context,ApplicationUser user)
        {
            _context = context;
            _user = user;
        }

        public IActionResult Index()
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
        public async Task<IActionResult> Product()
        {
            var product = await _context.productUW.GetEntitiesAsync();
            return View(product);
        }
    }
}
