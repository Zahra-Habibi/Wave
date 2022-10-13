using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.PublicFile.Services
{
    public interface IUploadFiels
    {
        string UploadFileFunc(IEnumerable<IFormFile> files, string uploadPath);
        string UploadAttachmentFunc(IEnumerable<IFormFile> files, string uploadPath, string username);
    }
}
