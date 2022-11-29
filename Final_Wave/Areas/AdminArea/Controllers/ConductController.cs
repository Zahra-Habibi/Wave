using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    //[Authorize]
    public class ConductController : Controller
    {

        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public ConductController(IUnitOfWork context, IMapper mapper, INotyfService service)
        {
            _context = context;
            _mapper = mapper;
            _notify = service;
        }
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.conductUW.GetEntitiesAsync(null, x => x.OrderByDescending(c => c.Id));
            return View(contacts);
        }

        public async Task<IActionResult> Detials(int id)
        {
            var contact = await _context.conductUW.GetByIdAsync(id);
            _notify.Information("You check all information of contact us !", 5);
            return View(contact);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _context.conductUW.DeleteByIdAsync(id);
            await _context.saveAsync();
            _notify.Error("You Deleted   a contact !", 5);
            return RedirectToAction(nameof(Index));
        }
    }
}

