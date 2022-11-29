using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
   // [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        public DashboardController(IUnitOfWork context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

    
    }
}
