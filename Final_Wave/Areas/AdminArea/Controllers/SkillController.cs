using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Final_Wave.Core.ViewModels;
using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Final_Wave.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class SkillController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public SkillController(IUnitOfWork context, IMapper mapper, INotyfService notify)
        {
            _context = context;
            _mapper = mapper;
            _notify = notify;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<TreeViewModel> node = new List<TreeViewModel>();

            node.Add(new TreeViewModel
            {
                id = "1",
                text = "Skills",
                parent = "#"
            });

            foreach (Skills job in await _context.skillUW.GetEntitiesAsync(j => j.level != 0))
            {
                node.Add(new TreeViewModel
                {
                    id = job.Id.ToString(),
                    parent = job.level.ToString(),
                    text = job.SkillName

                });
            }
            ViewBag.JobJson = JsonConvert.SerializeObject(node);
            return View();
        }





        [HttpGet]
        public async Task<IActionResult> AddSkill(int id, string parentname)
        {
            @ViewBag.parentname = parentname;
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSkill(SkillsViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

                var jobmodel = _mapper.Map<Skills>(model);
                await _context.skillUW.Create(jobmodel);
                await _context.saveAsync();
            _notify.Success("You successfuly added !", 5);
            return RedirectToAction(nameof(Index));
            

           
        }


        [HttpGet]
        public async Task<IActionResult> EditSkill(int id, string parentname)
        {
            if (id == 0)
            {
                return RedirectToAction("ErrorView", "Home");
            }
            var jobsChart = await _context.skillUW.GetByIdAsync(id);
            var mapModel = _mapper.Map<SkillsViewModel>(jobsChart);
            if (mapModel != null)
            {
                return View(mapModel);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSkill(SkillsViewModel myskill)
        {


            var jobmapper = _mapper.Map<Skills>(myskill);
            _context.skillUW.Update(jobmapper);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited !", 5);
            return RedirectToAction(nameof(Index));
        }


    }
}
