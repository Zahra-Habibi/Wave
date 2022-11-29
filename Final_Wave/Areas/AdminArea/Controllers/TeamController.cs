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
   // [Authorize]
    public class TeamController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notify;
        public TeamController(IUnitOfWork context , IMapper mapper , INotyfService service)
        {
            _context = context;
            _mapper = mapper;   
            _notify = service;
                
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var team = await _context.teamUW.GetEntitiesAsync();
            return View(team);
        }


        [HttpGet]
        public async Task<IActionResult> AddTeam()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTeam(TeamViewModel model, IFormFile file)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgname = "Img/Team/" + UploadFiles.CreateImg(file, "Team");
            if (imgname == "false")
            {
                TempData["Result"] = "false";
                return RedirectToAction(nameof(Index));
            }
            Team team = new Team
            {
                Name = model.Name,
                PositionName = model.PositionName,
                ImageUrl = imgname,
                Title = model.Title,
                Alt = model.Alt,
                ShortDesc=model.ShortDesc,
                LastName=model.LastName,
            };
            await _context.teamUW.Create(team);
            await _context.saveAsync();
            _notify.Success("You successfuly Added  !", 5);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> EditTeam(int id)
        {
            Team team = await _context.teamUW.GetByIdAsync(id);
            var mapUser = _mapper.Map<TeamViewModel>(team);
            return View(mapUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeam(TeamViewModel team, IFormFile file)
        {

            if (file != null)
            {
                string imgname = "Img/Team/" + UploadFiles.CreateImg(file, "Team");

                bool DeleteImage = UploadFiles.DeleteImg("Social",team.ImageUrl );
                team.ImageUrl = imgname;
            }

            //if (!ModelState.IsValid)
            //    return View(about);

            var ser = await _context.teamUW.GetByIdAsync(team.Id);
            var mapModel = _mapper.Map(team, ser);
            _context.teamUW.Update(mapModel);
            await _context.saveAsync();
            _notify.Success("You successfuly Edited !", 5);
            return RedirectToAction(nameof(Index));
        }



        public async Task<IActionResult> Delete(int id)
        {
            var team = await _context.teamUW.GetByIdAsync(id);
            if (team.IsDelete)
            {
                ViewBag.Message = "You are actvating this information!";
            }
            else
            {
                ViewBag.Message = "You are InActvating it! , you can always undo";
            }
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Team model)
        {

            if (model.IsDelete)
            {
                model.IsDelete = false;
            }
            else
            {
                model.IsDelete = true;
            }
            _context.teamUW.Update(model);
            await _context.saveAsync();
            _notify.Error("You  changed the info of Social page!", 5);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Detials(int id)
        {
            var team = await _context.teamUW.GetByIdAsync(id);
            _notify.Information("You checked all the information of team page !", 5);
            return View(team);
        }


    }
}
