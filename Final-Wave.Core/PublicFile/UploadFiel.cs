using Final_Wave.Core.PublicFile.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.PublicFile
{
    public class UploadFiel:IUploadFiels
    {
        private readonly IHostingEnvironment _appEnvironment;
        public UploadFiel(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }
        public string UploadFileFunc(IEnumerable<IFormFile> files, string uploadPath)
        {
            var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
            var fileName = "";
            foreach (var item in files)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", " ") + Path.GetExtension(item.FileName);
                using (var fs = new FileStream(Path.Combine(upload, fileName), FileMode.Create))
                {
                    item.CopyTo(fs);
                }
            }
            return fileName;
        }

        public string UploadAttachmentFunc(IEnumerable<IFormFile> files, string uploadPath, string username)
        {
            var upload = Path.Combine(_appEnvironment.WebRootPath, uploadPath);
            if (!Directory.Exists(upload + username))
            {
                Directory.CreateDirectory(upload + username);
            }
            upload = upload + username;

            var fileName = "";
            foreach (var item in files)
            {
                fileName = Guid.NewGuid().ToString().Replace("-", " ") + Path.GetExtension(item.FileName);
                using (var fs = new FileStream(Path.Combine(upload, fileName), FileMode.Create))
                {
                    item.CopyTo(fs);
                }
            }
            return fileName;
        }
    }
}

