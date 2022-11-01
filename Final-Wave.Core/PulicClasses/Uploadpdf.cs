using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Final_Wave.Core.PulicClasses.UploadFiles;

namespace Final_Wave.Core.PulicClasses
{
    public static class Uploadpdf
    {

        public static string CreateImage(IFormFile file)
        {
            try
            {
                string imgname = GenerateCode.GuidCode() + Path.GetExtension(file.FileName);
                string Pathimg = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", imgname);

                using (var stream = new FileStream(Pathimg, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return imgname;
            }
            catch (Exception)
            {
                return "false";
            }

        }

        public static bool DeleteImg(string path, string imagename)
        {
            try
            {
                string FullPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/" + path + "/" + imagename);
                if (File.Exists(FullPath))
                {
                    File.Delete(FullPath);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
