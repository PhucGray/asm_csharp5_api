using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public static class ImageHelper
    {
        public static async Task<string> Upload(IFormFile file, IWebHostEnvironment webHostEnvironment)
        {
            string savePath = webHostEnvironment.ContentRootPath + "\\Images\\";

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            string imageName =
                new string(Path.GetFileNameWithoutExtension(file.FileName)
                    .Take(10).ToArray())
                    .Replace(' ', '-') + Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string imagePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", imageName);

            var stream = new FileStream(imagePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return imageName;
        }
    }
}
