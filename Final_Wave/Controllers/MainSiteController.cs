using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Controllers
{
    public class MainSiteController : Controller
    {
        private readonly IUnitOfWork _context;
        public MainSiteController(IUnitOfWork context)
        {
            _context = context;
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
    }
}
