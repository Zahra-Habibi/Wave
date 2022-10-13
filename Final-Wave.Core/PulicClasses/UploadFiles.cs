using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Wave.Core.PulicClasses
{
    public static class UploadFiles
    {
        // Create file and store that to server
        public static string CreateImg(IFormFile file, string folder)
        {
            try
            {
                string imgname = GenerateCode.GuidCode() + Path.GetExtension(file.FileName);
                string ImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/" + folder + "/", imgname);

                using (var stream = new FileStream(ImgPath, FileMode.Create))
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


        // Delete the file and it's root from server
        public static bool DeleteImg(string folder, string imgname)
        {
            try
            {
                string Fullpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/" + folder + "/" + imgname);
                if (File.Exists(Fullpath))
                {
                    File.Delete(Fullpath);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }


        // make a random generated numbers

        public class GenerateCode
        {
            public static string ActiveCode()
            {
                Random random = new Random();
                return random.Next(100000, 999000).ToString();
            }

            public static string GuidCode()
            {
                return Guid.NewGuid().ToString().Replace("-", "");
            }
        }
    }
}

