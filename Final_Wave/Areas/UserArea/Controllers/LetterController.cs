using Final_Wave.DataLayer.Entites;
using Final_Wave.DataLayer.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Final_Wave.Core.PulicClasses;
using AutoMapper;
using Final_Wave.Core.PublicFile.Services;
using Final_Wave.Core.ViewModels;

namespace Final_Wave.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    public class LetterController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IUploadFiels _upload;
        private readonly IMapper _mapper;
        public LetterController(IUnitOfWork context, UserManager<ApplicationUser> usermanager, IUploadFiels upload, IMapper mapper)
        {
            _context = context;
            _usermanager = usermanager;
            _upload = upload;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CreatLetter()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> CreateLetter(LetterViewModel model, string newfilePathName, string LetterNo, string LetterDate)
        {
            if (ModelState.IsValid)
            {
                if (model.ReplyStatus == 1)
                {
                    model.ReplyDate = DateTime.Now;
                }
                if (model.AttachmentLetter == 1)
                {
                    model.AttachmentFile = newfilePathName;
                }
                model.UserId = _usermanager.GetUserId(HttpContext.User);
                model.CreatLetterDate = DateTime.Now;
                await _context.LetterUW.Create(_mapper.Map<Latter>(model));
                await _context.saveAsync();
                return RedirectToAction("Index", "Draft");
            }
            if (model.ClassificationStatus == 2)
            {
                ViewBag.msg = "The answer of letter with the number of " + LetterNo + "and date " + LetterDate;
            }
            ViewBag.LetterType = model.ClassificationStatus;
            //ViewBag.MainLetterID = model.MainLetterID;
            ViewBag.LetterNo = LetterNo;
            ViewBag.LetterDate = LetterDate;
            return View(model);
        }
 

        public async Task<IActionResult> UploadAttachmentFile(IEnumerable<IFormFile> filearray, string path, long filesize)
        {
            if (filesize > 512000)
            {
                return Json(new { status = "badsize" });
            }
            var user = _context.UserUW.GetByIdAsync(_usermanager.GetUserId(HttpContext.User));
            string filename = _upload.UploadAttachmentFunc(filearray, path, user.Id.ToString());
            return Json(new { status = "success", imagename = filename });
        }
    }
}
