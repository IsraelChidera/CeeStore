using CeeStore.BLL.ServicesContract;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeeStore.BLL.Services
{
    public class FileService : IFileService
    {
        private readonly IHostEnvironment _environment;
        public FileService(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public bool DeleteImage(string imageFile)
        {
            var wwwPath = _environment.ContentRootPath;
            var path = Path.Combine(wwwPath, "UploadedFiles\\" ,imageFile);

            if(File.Exists(path))
            {
                File.Delete(path);
                return true;
            }

            return false;
        }

        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var file = imageFile;

            if (file == null || file.Length == 0)
            {
                throw new NotImplementedException("No file has been uploaded");
            }

            string path = "";
            if (file.Length > 0)
            {
                path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles"));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    
                    await file.CopyToAsync(fileStream);
                }
            }

            return path;

        }
    }
}
